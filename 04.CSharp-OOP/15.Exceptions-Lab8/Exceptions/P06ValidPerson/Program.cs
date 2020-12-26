using System;

namespace P06ValidPerson
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Person noName = new Person(string.Empty, "Goshev", 31);
                //Person negativeAge = new Person("Stoyan", "Kolev", -1);
                Student wrongName = new Student("Gin4o", "email");
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("Exception thrown: {0}", ane.Message);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine("Exception thrown: {0}", aore.Message);
            }
            catch (InvalidPersonNameException ipne)
            {
                Console.WriteLine("Exception thrown: {0}", ipne.Message);
            }
        }
    }
}
