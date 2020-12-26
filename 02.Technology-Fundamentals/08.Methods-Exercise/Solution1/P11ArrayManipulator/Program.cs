using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split();

                string commandName = commandArgs[0];

                switch (commandName)
                {
                    case "exchange":
                        {
                            int index = int.Parse(commandArgs[1]);

                            if (index + 1 > input.Length || index < 0)
                            {
                                Console.WriteLine("Invalid index");
                                break;
                            }

                            int[] reversed = Exchange(input, index);

                            Array.Copy(reversed, input, reversed.Length);

                            break;
                        }
                    case "max":
                        {
                            string position = commandArgs[1];

                            if (position == "odd")
                            {
                                string maxOddIndex = MaxOdd(input);

                                Console.WriteLine(maxOddIndex);

                                break;
                            }

                            string maxEvenIndex = MaxEven(input);

                            Console.WriteLine(maxEvenIndex);

                            break;
                        }
                    case "min":
                        {
                            string position = commandArgs[1];

                            if (position == "odd")
                            {
                                string minOddIndex = MinOdd(input);

                                Console.WriteLine(minOddIndex);

                                break;
                            }

                            string minEvenIndex = MinEven(input);

                            Console.WriteLine(minEvenIndex);

                            break;
                        }
                    case "first":
                        {
                            int count = int.Parse(commandArgs[1]);

                            if (count > input.Length || count < 0)
                            {
                                Console.WriteLine("Invalid count");
                                break;
                            }

                            string type = commandArgs[2];

                            if (type == "odd")
                            {
                                int[] oddElements = GetFirstOddElements(input, count);

                                Console.WriteLine($"[{String.Join(", ", oddElements)}]");

                                break;
                            }

                            int[] evenElements = GetFirstEvenElements(input, count);

                            Console.WriteLine($"[{String.Join(", ", evenElements)}]");

                            break;
                        }
                    case "last":
                        {
                            int count = int.Parse(commandArgs[1]);

                            if (count > input.Length || count < 0)
                            {
                                Console.WriteLine("Invalid count");
                                break;
                            }

                            string type = commandArgs[2];

                            if (type == "odd")
                            {
                                int[] oddElements = GetLastOddElements(input, count);

                                Console.WriteLine($"[{String.Join(", ", oddElements)}]");

                                break;
                            }

                            int[] evenElements = GetLastEvenElements(input, count);

                            Console.WriteLine($"[{String.Join(", ", evenElements)}]");

                            break;
                        }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"[{String.Join(", ", input)}]");

        }

        private static int[] GetLastEvenElements(int[] input, int count)
        {
            return input.Where(x => x % 2 == 0).Reverse().Take(count).Reverse().ToArray();
        }

        private static int[] GetLastOddElements(int[] input, int count)
        {
            return input.Where(x => x % 2 != 0).Reverse().Take(count).Reverse().ToArray();
        }

        private static int[] GetFirstEvenElements(int[] input, int count)
        {
            return input.Where(x => x % 2 == 0).Take(count).ToArray();
        }

        private static int[] GetFirstOddElements(int[] input, int count)
        {
            return input.Where(x => x % 2 != 0).Take(count).ToArray();
        }

        private static string MinEven(int[] input)
        {
            int[] evenElements = input.Where(x => x % 2 == 0).ToArray();

            if (evenElements.Length == 0)
            {
                return "No matches";
            }

            return Array.LastIndexOf(input, evenElements.Min()).ToString();
        }

        private static string MinOdd(int[] input)
        {
            int[] oddElements = input.Where(x => x % 2 != 0).ToArray();

            if (oddElements.Length == 0)
            {
                return "No matches";
            }

            return Array.LastIndexOf(input, oddElements.Min()).ToString();
        }

        private static string MaxEven(int[] input)
        {
            int[] evenElements = input.Where(x => x % 2 != 1).ToArray();

            if (evenElements.Length == 0)
            {
                return "No matches";
            }

            return Array.LastIndexOf(input, evenElements.Max()).ToString();
        }

        private static string MaxOdd(int[] input)
        {
            int[] oddElements = input.Where(x => x % 2 != 0).ToArray();

            if (oddElements.Length == 0)
            {
                return "No matches";
            }

            return Array.LastIndexOf(input, oddElements.Max()).ToString();
        }

        private static int[] Exchange(int[] input, int index)
        {
            int[] secondHalf = input.Skip(index + 1).ToArray();
            int[] firstHalf = input.Take(input.Length - secondHalf.Length).ToArray();

            return secondHalf.Concat(firstHalf).ToArray();
        }
    }
}