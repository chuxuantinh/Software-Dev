using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static CodeFirst.Data.DataValidations.Student;

namespace CodeFirst.Data.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(NameMaxLength)]
        public string MiddleName { get; set; }

        //[Column("EGN", TypeName = "char(10)")]
        //public string IdentifierNumber { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public StudentType Type { get; set; }

        public int? Age { get; set; }

        public bool HasScholarship { get; set; }

        public int? TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<StudentInCourse> Courses { get; set; } = new HashSet<StudentInCourse>();

        public ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();

        [NotMapped]
        public string Fullname
        {
            get
            {
                if (this.MiddleName == null)
                {
                    return $"{this.FirstName} {this.LastName}";
                }

                return $"{this.FirstName} {this.MiddleName} {this.LastName}";
            }
        }
    }
}
