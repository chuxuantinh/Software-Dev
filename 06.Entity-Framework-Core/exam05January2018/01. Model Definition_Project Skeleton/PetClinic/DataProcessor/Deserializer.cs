namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.ImportDto;
    using PetClinic.Models;

    public class Deserializer
    {

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedAnimalAids = JsonConvert.DeserializeObject<ImportAnimalAidDto[]>(jsonString);

            var animalAids = new List<AnimalAid>();

            foreach (var dto in deserializedAnimalAids)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var animalAid = animalAids.SingleOrDefault(aa => aa.Name == dto.Name);
                if (animalAid != null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }
                else
                {
                    animalAid = new AnimalAid
                    {
                        Name = dto.Name,
                        Price = dto.Price
                    };

                    animalAids.Add(animalAid);
                }

                sb.AppendLine($"Record {animalAid.Name} successfully imported.");
            }

            context.AnimalAids.AddRange(animalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedAnimals = JsonConvert.DeserializeObject<ImportAnimalDto[]>(jsonString);

            var animals = new List<Animal>();
            var passports = new List<Passport>();

            foreach (var dto in deserializedAnimals)
            {
                if (!IsValid(dto) || !IsValid(dto.Passport))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var passport = passports.SingleOrDefault(p => p.SerialNumber == dto.Passport.SerialNumber);

                if (passport != null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }
                else
                {
                    var animal = new Animal
                    {
                        Name = dto.Name,
                        Type = dto.Type,
                        Age = dto.Age,
                        Passport = new Passport 
                        {
                            SerialNumber = dto.Passport.SerialNumber,
                            OwnerName = dto.Passport.OwnerName,
                            OwnerPhoneNumber = dto.Passport.OwnerPhoneNumber,
                            RegistrationDate = DateTime.ParseExact(dto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                        }
                    };

                    animals.Add(animal);
                    passports.Add(animal.Passport);
                    sb.AppendLine($"Record {animal.Name} Passport №: {animal.Passport.SerialNumber} successfully imported.");
                }
            }

            context.Animals.AddRange(animals);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportVetDto[]), new XmlRootAttribute("Vets"));
            var objects = (ImportVetDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var vets = new List<Vet>();

            foreach (var dto in objects)
            {
                bool phoneNumberAlreadyExists = vets.Any(v => v.PhoneNumber == dto.PhoneNumber);

                if (!IsValid(dto) || phoneNumberAlreadyExists)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var vet = new Vet
                {
                    Name = dto.Name,
                    Profession = dto.Profession,
                    Age = dto.Age,
                    PhoneNumber = dto.PhoneNumber
                };

                vets.Add(vet);
                sb.AppendLine($"Record {vet.Name} successfully imported.");
            }

            context.Vets.AddRange(vets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportProcedureDto[]), new XmlRootAttribute("Procedures"));
            var objects = (ImportProcedureDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var procedures = new List<Procedure>();
            var animalAids = new List<AnimalAid>();

            foreach (var dto in objects)
            {
                if (!IsValid(dto) || !dto.AnimalAids.All(IsValid))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var vet = context.Vets.SingleOrDefault(v => v.Name == dto.VetName);
                var animal = context.Animals.SingleOrDefault(a => a.PassportSerialNumber == dto.AnimalSerialNumber);
                

                if (vet == null || animal == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var procedure = new Procedure
                {
                    Vet = vet,
                    Animal = animal,
                    DateTime = DateTime.ParseExact(dto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                };

                var animalAidExistInDB = true;
                var animalAidsExistsMoreThanOnce = false;
                
                animalAids.Clear();

                foreach (var animalAidDto in dto.AnimalAids)
                {
                    var animalAid = context.AnimalAids.SingleOrDefault(aa => aa.Name == animalAidDto.Name);

                    if (animalAid == null)
                    {
                        animalAidExistInDB = false;
                        sb.AppendLine("Error: Invalid data.");
                        break;
                    }

                    if (animalAids.Contains(animalAid))
                    {
                        animalAidsExistsMoreThanOnce = true;
                        sb.AppendLine("Error: Invalid data.");
                        break;
                    }

                    procedure.ProcedureAnimalAids.Add(new ProcedureAnimalAid
                    {
                         AnimalAidId = animalAid.Id
                    });

                    animalAids.Add(animalAid);
                }

                if (animalAidExistInDB == false || animalAidsExistsMoreThanOnce == true)
                {
                    continue;
                }

                procedures.Add(procedure);
                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(procedures);
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
