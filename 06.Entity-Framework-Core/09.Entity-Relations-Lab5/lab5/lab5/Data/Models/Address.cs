using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static lab5.Data.DataValidations.Address;

namespace lab5.Data.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTextLength)]
        public string Text { get; set; }

        [Required]
        [MaxLength(MaxTownLength)]
        public string Town { get; set; }

        public int CustomerId { get; set; }//int? for onr-to-zero

        public Customer Customer { get; set; }
    }
}
