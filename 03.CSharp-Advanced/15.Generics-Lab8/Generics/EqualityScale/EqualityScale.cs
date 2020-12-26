using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T> where T : IComparable
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            return left.CompareTo(right) == 0;
        }

        public void WhichIsHavier()
        {
            int result = left.CompareTo(right);
            if (result == 0)
            {
                Console.WriteLine("Right and Left are equal");
            }
            else if (result > 0)
            {
                Console.WriteLine("Left is havier");
            }
            else
            {
                Console.WriteLine("Right is havier");
            }
        }
    }
}
