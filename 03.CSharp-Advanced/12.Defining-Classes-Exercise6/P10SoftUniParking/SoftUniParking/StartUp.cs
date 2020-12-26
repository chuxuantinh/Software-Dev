namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            System.Console.WriteLine(car);
        }
    }
}
