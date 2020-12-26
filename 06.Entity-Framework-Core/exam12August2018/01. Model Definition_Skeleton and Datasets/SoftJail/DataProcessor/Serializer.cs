namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(prisoner => new
                {
                    Id = prisoner.Id,
                    Name = prisoner.FullName,
                    CellNumber = prisoner.Cell.CellNumber,
                    Officers = prisoner.PrisonerOfficers.Select(po => po.Officer).Select(o => new
                    {
                        OfficerName = o.FullName,
                        Department = o.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = prisoner.PrisonerOfficers.Select(po => po.Officer).Sum(o => o.Salary)//MidpointRounding.AwayFromZero
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            //var prisoners = context
            //    .Prisoners
            //    .Where(p => ids.Contains(p.Id))
            //    .Select(p => new 
            //    {
            //        Id = p.Id,
            //        Name = p.FullName,
            //        CellNumber = p.Cell.CellNumber,
            //        Officers = p.PrisonerOfficers
            //            .Select(po => new 
            //            {
            //                OfficerName = po.Officer.FullName,
            //                Department = po.Officer.Department.Name
            //            })
            //            .OrderBy(o => o.OfficerName)
            //            .ToArray(),
            //        TotalOfficerSalary = p.PrisonerOfficers.Sum(po => po.Officer.Salary)
            //    })
            //    .OrderBy(p => p.Name)
            //    .ThenBy(p => p.Id)
            //    .ToArray();

            return JsonConvert.SerializeObject(prisoners, Newtonsoft.Json.Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] searchedPrisoners = prisonersNames.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context
                .Prisoners
                .Where(p => searchedPrisoners.Contains(p.FullName))
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Messages = p.Mails
                        .Select(m => new ExportMailDto()
                        {
                            Description = ReverseAlgorithm(m.Description)//Reverse not working!
                        })
                        .ToArray()
                })
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportPrisonerDto[]), new XmlRootAttribute("Prisoners"));
            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            serializer.Serialize(new StringWriter(sb), prisoners, xmlNamespaces);

            return sb.ToString().Trim();
        }

        private static string ReverseAlgorithm(string description)
        {
            string result = string.Empty;
            for (int i = description.Length - 1; i >= 0; i--)
            {
                result += description[i];
            }

            return result;
        }
    }
}