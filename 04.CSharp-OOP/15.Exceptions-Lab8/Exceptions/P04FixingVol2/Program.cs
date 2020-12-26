using System;

namespace P04FixingVol2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num1, num2;
                byte result;

                num1 = 30;
                num2 = 60;
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
                Console.ReadLine();
            }
            catch (OverflowException oe)
            {
                Console.WriteLine("The number is too big");
            }
        }
    }
}
