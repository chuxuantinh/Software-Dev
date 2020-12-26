namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context
                .Animals
                .Where(a => a.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(animal => new
                {
                    OwnerName = animal.Passport.OwnerName,
                    AnimalName = animal.Name,
                    Age = animal.Age,
                    SerialNumber = animal.PassportSerialNumber,
                    RegisteredOn = animal.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                })
                .OrderBy(animal => animal.Age)
                .ThenBy(animal => animal.SerialNumber)
                .ToArray();

            return JsonConvert.SerializeObject(animals, Newtonsoft.Json.Formatting.Indented);
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context
                .Procedures
                .Select(p => new ExportProcedureDto
                {
                    SerialNumber = p.Animal.Passport.SerialNumber,
                    OwnerNumber = p.Animal.Passport.OwnerPhoneNumber,
                    DateTime = p.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    DateTimeDT = p.DateTime,
                    AnimalAids = p.ProcedureAnimalAids.Select(paa => new ExportAnimalAidsDto
                    {
                        Name = paa.AnimalAid.Name,
                        Price = paa.AnimalAid.Price.ToString("f2")
                    })
                    .ToArray(),
                    TotalPrice = p.Cost.ToString("f2")
                })
                .OrderBy(p => p.DateTimeDT)
                .ThenBy(p => p.SerialNumber)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProcedureDto[]), new XmlRootAttribute("Procedures"));
            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            serializer.Serialize(new StringWriter(sb), procedures, xmlNamespaces);

            return sb.ToString().Trim();
        }
    }
}
