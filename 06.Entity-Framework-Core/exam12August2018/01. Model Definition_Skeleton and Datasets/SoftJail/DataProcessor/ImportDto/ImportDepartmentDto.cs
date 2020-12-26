﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentDto
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        public ImportCellsDto[] Cells { get; set; }
    }
}
