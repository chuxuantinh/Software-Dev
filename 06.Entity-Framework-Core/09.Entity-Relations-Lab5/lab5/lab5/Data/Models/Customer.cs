using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static lab5.Data.DataValidations.Customer;

namespace lab5.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public ICollection<CarPurchase> Purchases { get; set; } = new HashSet<CarPurchase>();

        public Address Address { get; set; }
    }
}
