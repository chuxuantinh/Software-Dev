using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            products = new List<IProduct>();
        }

        public IProduct this[int index] { get => products[index]; set => products[index] = value; }

        public int Count
        {
            get
            {
                return products.Count;
            }
        }

        public void Add(IProduct product)
        {

            var existingProduct = (Product)products.FirstOrDefault(p => p.Label == product.Label);

            if (existingProduct == null)
            {
                products.Add(product);
            }
            else
            {
                if (existingProduct.Price != product.Price)
                {
                    throw new ArgumentException();
                }
                existingProduct.Quantity += product.Quantity;
            }
        }

        public bool Contains(IProduct product)
        {
            return products.Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            try
            {
                return products[index - 1];
            }
            catch (ArgumentOutOfRangeException ae)
            {
                throw new IndexOutOfRangeException(ae.Message, ae);
            }
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return products.Where(p => p.Price == price)
                .ToList();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return products.Where(p => p.Quantity == quantity)
                .ToList();
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal lo, decimal hi)
        {
            return products.Where(p => p.Price >= lo)
                .Where(p => p.Price <= hi)
                .OrderByDescending(p => p.Price)
                .ToList();
        }

        public IProduct FindByLabel(string label)
        {
            var product = products.FirstOrDefault(p => p.Label == label);

            if (product == null)
            {
                throw new ArgumentException();
            }

            return product;
        }

        public IProduct FindMostExpensiveProduct()
        {
            return products
                .OrderByDescending(p => p.Price)
                .FirstOrDefault();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        public bool Remove(IProduct product)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return products.GetEnumerator();
        }
    }
}
