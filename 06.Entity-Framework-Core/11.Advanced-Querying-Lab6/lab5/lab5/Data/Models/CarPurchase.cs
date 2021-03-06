﻿using System;
using System.Collections.Generic;
using System.Text;

namespace lab5.Data.Models
{
    public class CarPurchase
    {
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal Price { get; set; }
    }
}
