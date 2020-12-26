using System;

namespace P05ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = 0;
            try
            {
                number = Convert.ToDouble("");
                number = Convert.ToDouble('g');
                Console.WriteLine(number);
                
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Invalid format");
                throw fe;
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine("The number is too big");
                throw aore;
            }
            catch (InvalidCastException ice)
            {
                Console.WriteLine("This input can't be converted to double");
                throw ice;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}
