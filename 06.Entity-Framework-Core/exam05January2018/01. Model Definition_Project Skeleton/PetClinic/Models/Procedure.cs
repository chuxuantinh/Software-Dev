using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PetClinic.Models
{
    public class Procedure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }

        [Required]
        public int VetId { get; set; }

        public Vet Vet { get; set; }

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; } = new HashSet<ProcedureAnimalAid>();

        public decimal Cost => this.ProcedureAnimalAids.Sum(s => s.AnimalAid.Price);

        [Required]
        public DateTime DateTime { get; set; }
    }
}
