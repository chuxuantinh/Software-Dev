using System;

namespace opit3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[3];
            for (int i = 0; i < 2; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {

                if (array[i] == 0)
                {
                    count++;
                }
            }
            Array.Resize(ref array, array.Length - count);
            foreach (int num in array)
            {
                Console.Write($"{num}, ");
            }
        }
    }
}
