namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {


            var projects = context
                .Projects
                .Where(p => p.Tasks.Count >= 1)
                .Select(p => new ProjectExportDto
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new TaskExportDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ProjectExportDto[]), new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesTasks.Select(et => et.Task).Any(t => DateTime.Compare(t.OpenDate, date) >= 0))
                .OrderByDescending(e => e.EmployeesTasks.Count(t => DateTime.Compare(t.Task.OpenDate, date) >= 0))
                .ThenBy(e => e.Username)
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks.Select(et => et.Task).Select(t => new
                    {
                        TaskName = t.Name,
                        OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.LabelType.ToString(),
                        ExecutionType = t.ExecutionType.ToString()
                    })
                    .Where(t => DateTime.Compare(DateTime.ParseExact(t.OpenDate, "d", CultureInfo.InvariantCulture), date) >= 0)
                    .OrderByDescending(t => DateTime.ParseExact(t.DueDate, "d", CultureInfo.InvariantCulture))
                    .ThenBy(t => t.TaskName)
                    .ToArray()
                })
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
    
}