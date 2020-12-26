using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static lab5.Data.DataValidations.Model;

namespace lab5.Data.Models
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxName)]
        public string Name { get; set; }

        [Required]
        [MaxLength(MaxModification)]
        public string Modification { get; set; }

        [Range(1900, 3000)]
        public int Year { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
