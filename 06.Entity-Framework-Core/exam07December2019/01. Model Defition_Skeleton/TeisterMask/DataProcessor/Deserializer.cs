namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ProjectsImportDto[]), new XmlRootAttribute("Projects"));
            var objects = (ProjectsImportDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var projects = new List<Project>();

            foreach (var dto in objects)
            {
                var isValidOpenDate = DateTime.TryParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDate);

                if (!IsValid(dto) || !isValidOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Project project; 

                if (string.IsNullOrWhiteSpace(dto.DueDate))
                {
                    project = new Project
                    {
                        Name = dto.Name,
                        DueDate = null,
                        OpenDate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };
                }
                else
                {
                    project = new Project
                    {
                        Name = dto.Name,
                        DueDate = DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        OpenDate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };
                }

                foreach (var taskDto in dto.Tasks)
                {
                    var isValidEnumExecution = Enum.TryParse(taskDto.ExecutionType, out ExecutionType execution);
                    var isValidEnumLabel = Enum.TryParse(taskDto.LabelType, out LabelType label);

                    if (!IsValid(taskDto)
                        || DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) < project.OpenDate
                        || DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) > project.DueDate
                        || !isValidEnumExecution || !isValidEnumLabel)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    project.Tasks.Add(new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        DueDate = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ExecutionType = execution,
                        LabelType = label
                    });
                }


                projects.Add(project);

                sb.AppendLine(string.Format(SuccessfullyImportedProject, dto.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeeDtos = JsonConvert.DeserializeObject<EmployeeImportDto[]>(jsonString);

            var employees = new List<Employee>();
            var employeeTasks = new List<EmployeeTask>();

            var sb = new StringBuilder();

            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var taskDto in employeeDto.Tasks.Select(t => t).Distinct())
                {
                    var task = context.Tasks.Find(taskDto);
                    
                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask 
                    {
                        TaskId = taskDto
                    });
                }

                employees.Add(employee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}