using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportMailDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(@"[A-ZA-z0-9 ]+ str\.")]
        public string Address { get; set; }
    }
}
