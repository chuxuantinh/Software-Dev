using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static lab5.Data.DataValidations.Car;

namespace lab5.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        public DateTime ProductionDate { get; set; }

        [Required]
        [MaxLength(VinLength)]
        public string Vin { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MaxLength(ColorMaxLength)]
        public string Color { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }

        public ICollection<CarPurchase> Owners { get; set; } = new HashSet<CarPurchase>();


    }
}
