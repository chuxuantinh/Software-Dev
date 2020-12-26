using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace INStock
{
    public class Product : IProduct
    {
        public string Label { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CompareTo(IProduct other)
        {
            if (this.Label.CompareTo(other.Label) != 0)
            {
                return this.Label.CompareTo(other.Label);
            }
            else if (this.Price != other.Price)
            {
                throw new ArgumentException();
            }
            return 0;
        }
    }
}
