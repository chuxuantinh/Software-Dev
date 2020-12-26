using System;

namespace Farm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dog = new Dog();
            dog.Eat();
            dog.Bark();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();
        }
    }
}
