﻿using System;
using System.Collections.Generic;
using System.Text;

namespace lab5.Results
{
    public class PurchaseResultModel
    {
        public decimal Price { get; set; }

        public DateTime PurchaseDate { get; set; }

        public CarResultModel Car { get; set; }

        public CustomerResultModel Customer { get; set; }
    }
}
