using Animals.Cats;
using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string type = input;

                string[] animalTokens = Console.ReadLine()
                    .Split();

                try
                {
                    Animal animal = newAnimal(type, animalTokens);
                    Console.WriteLine(type);
                    Console.WriteLine(animal);
                    animal.ProduceSound();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                input = Console.ReadLine();
            }
        }

        private static Animal newAnimal(string type, string[] animalTokens)
        {
            switch (type)
            {
                case "Dog":
                    return new Dog(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                case "Frog":
                    return new Frog(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                case "Cat":
                    return new Cat(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                case "Tomcat":
                    return new Tomcat(animalTokens[0], int.Parse(animalTokens[1]));
                case "Kitten":
                    return new Kitten(animalTokens[0], int.Parse(animalTokens[1]));
                default:
                    throw new ArgumentException("Invalid input!");
            }
        }
    }
}
