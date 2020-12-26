using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Shop_Keeper
{
    internal class Program
    {
        private static void Main()
        {
            var initialStock = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var ordersList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            if (!initialStock.Contains(ordersList[0]))
            {
                Console.WriteLine("impossible");
                return;
            }

            var orders = new Dictionary<int, Order>();

            for (var index = ordersList.Length - 1; index >= 0; index--)
            {
                var order = ordersList[index];

                if (!orders.ContainsKey(order))
                {
                    orders.Add(order, new Order(order));
                }

                orders[order].Indexes.Push(index);
            }

            var shop = new SortedSet<Order>();

            foreach (var product in initialStock.Distinct())
            {
                shop.Add(!orders.ContainsKey(product) ?
                    new Order() :
                    orders[product]);
            }

            var stockChanges = 0;

            foreach (var order in ordersList)
            {
                var currentOrder = orders[order];

                if (!shop.Contains(currentOrder))
                {
                    //   Console.WriteLine("{0} <<< {1}",shop.Last().Id, order);
                    shop.Remove(shop.Last());
                    shop.Add(currentOrder);
                    stockChanges++;
                }

                shop.Remove(currentOrder);
                currentOrder.Indexes.Pop();
                shop.Add(currentOrder);
            }

            Console.WriteLine(stockChanges);
        }

        internal class Order : IComparable<Order>
        {
            private static int _dummyId = int.MaxValue;

            public int Id { get; set; }

            public Stack<int> Indexes { get; set; }

            public int PeekNextIndex()
            {
                if (Indexes.Count <= 0)
                {
                    Indexes.Push(_dummyId--);
                }

                return Indexes.Peek();
            }

            public Order(int id)
            {
                Id = id;
                Indexes = new Stack<int>();
            }

            public Order()
            {
                Indexes = new Stack<int>();
                Indexes.Push(_dummyId);
                Id = _dummyId--;
            }

            public int CompareTo(Order other)
            {
                return PeekNextIndex().CompareTo(other.PeekNextIndex());
            }

            public override string ToString()
            {
                return $"{Id} : {string.Join(", ", Indexes)}";
            }
        }
    }
}