using System;
using System.Linq;

namespace P11ArrayManipularor
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandToArray = command.Split().ToArray();
                if (commandToArray[0] == "exchange")
                {
                    int index = int.Parse(commandToArray[1]);
                    if (index >= 0 && index < array.Length)
                    {
                        array = ExchangedArray(array, index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commandToArray[0] == "max")
                {
                    if (commandToArray[1] == "even")
                    {
                        PrintMaxEvenIndex(array);
                    }
                    else if (commandToArray[1] == "odd")
                    {
                        PrintMaxOddIndex(array);
                    }
                }
                else if (commandToArray[0] == "min")
                {
                    if (commandToArray[1] == "even")
                    {
                        PrintMinEvenIndex(array);
                    }
                    else if (commandToArray[1] == "odd")
                    {
                        PrintMinOddIndex(array);
                    }
                }
                else if (commandToArray[0] == "first")
                {
                    if (commandToArray[2] == "even")
                    {
                        int count = int.Parse(commandToArray[1]);
                        PrintFirstEvenElements(array, count);
                    }
                    else if (commandToArray[2] == "odd")
                    {
                        int count = int.Parse(commandToArray[1]);
                        PrintFirstOddElements(array, count);
                    }
                }
                else if (commandToArray[0] == "last")
                {
                    if (commandToArray[2] == "even")
                    {
                        int count = int.Parse(commandToArray[1]);
                        PrintLastEvenElements(array, count);
                    }
                    else if (commandToArray[2] == "odd")
                    {
                        int count = int.Parse(commandToArray[1]);
                        PrintLastOddElements(array, count);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        private static void PrintLastOddElements(int[] array, int count)
        {
            if (count < 0 || count > array.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                int[] subArray = new int[array.Length];
                int counter = 0;
                int j = 0;
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 != 0)
                    {
                        subArray[j] = array[i];
                        counter++;
                        j++;
                        if (counter == count)
                        {
                            break;
                        }
                    }
                }
                if (counter == 0)
                {
                    Console.WriteLine("[]");
                }
                else
                {
                    int countZero = 0;
                    for (int i = 0; i < subArray.Length; i++)
                    {

                        if (subArray[i] == 0)
                        {
                            countZero++;
                        }
                    }
                    int[] finalArray = new int[array.Length - countZero];
                    for (int i = 0; i < finalArray.Length; i++)
                    {
                        finalArray[i] = subArray[i];
                    }
                    subArray = finalArray;
                    Array.Reverse(subArray);
                    Console.WriteLine($"[{string.Join(", ", subArray)}]");
                }
            }
        }

        private static void PrintLastEvenElements(int[] array, int count)
        {
            if (count < 0 || count > array.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                int[] subArray = new int[array.Length];
                int counter = 0;
                int j = 0;
                int zeroDigitCounter = 0;
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == 0)
                    {
                        if (array[i] == 0)
                        {
                            zeroDigitCounter++;
                        }
                        subArray[j] = array[i];
                        counter++;
                        j++;
                        if (counter == count)
                        {
                            break;
                        }
                    }
                }
                if (counter == 0)
                {
                    Console.WriteLine("[]");
                }
                else
                {
                    int countZero = 0 - zeroDigitCounter;
                    for (int i = 0; i < subArray.Length; i++)
                    {

                        if (subArray[i] == 0)
                        {
                            countZero++;
                        }
                    }
                    int[] finalArray = new int[array.Length - countZero];
                    for (int i = 0; i < finalArray.Length; i++)
                    {
                        finalArray[i] = subArray[i];
                    }
                    subArray = finalArray;
                    Array.Reverse(subArray);
                    Console.WriteLine($"[{string.Join(", ", subArray)}]");
                }
            }
        }

        private static void PrintFirstOddElements(int[] array, int count)
        {
            if (count < 0 || count > array.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                int[] subArray = new int[array.Length];
                int counter = 0;
                int j = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0)
                    {
                        subArray[j] = array[i];
                        counter++;
                        j++;
                        if (counter == count)
                        {
                            break;
                        }
                    }
                }
                if (counter == 0)
                {
                    Console.WriteLine("[]");
                }
                else
                {
                    int countZero = 0;
                    for (int i = 0; i < subArray.Length; i++)
                    {

                        if (subArray[i] == 0)
                        {
                            countZero++;
                        }
                    }
                    int[] finalArray = new int[array.Length - countZero];
                    for (int i = 0; i < finalArray.Length; i++)
                    {
                        finalArray[i] = subArray[i];
                    }
                    subArray = finalArray;
                    Console.WriteLine($"[{string.Join(", ", subArray)}]");
                }
            }
        }

        private static void PrintFirstEvenElements(int[] array, int count)
        {
            if (count < 0 || count > array.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                int[] subArray = new int[array.Length];
                int counter = 0;
                int j = 0;
                int zeroDigitCounter = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                    {
                        if (array[i] == 0)
                        {
                            zeroDigitCounter++;
                        }
                        subArray[j] = array[i];
                        counter++;
                        j++;
                        if (counter == count)
                        {
                            break;
                        }
                    }
                }
                if (counter == 0)
                {
                    Console.WriteLine("[]");
                }
                else
                {
                    int countZero = 0 - zeroDigitCounter;
                    for (int i = 0; i < subArray.Length; i++)
                    {

                        if (subArray[i] == 0)
                        {
                            countZero++;
                        }
                    }
                    int[] finalArray = new int[array.Length - countZero];
                    for (int i = 0; i < finalArray.Length; i++)
                    {
                        finalArray[i] = subArray[i];
                    }
                    subArray = finalArray;
                    Console.WriteLine($"[{string.Join(", ", subArray)}]");
                }
            }
        }

        private static void PrintMinOddIndex(int[] array)
        {
            int indexMinOdd = -1;
            int minOdd = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0 && array[i] <= minOdd)
                {
                    minOdd = array[i];
                    indexMinOdd = i;
                }
            }
            if (indexMinOdd == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexMinOdd);
            }
        }

        private static void PrintMinEvenIndex(int[] array)
        {
            int indexMinEven = -1;
            int minEven = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && array[i] <= minEven)
                {
                    minEven = array[i];
                    indexMinEven = i;
                }
            }
            if (indexMinEven == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexMinEven);
            }
        }

        private static void PrintMaxOddIndex(int[] array)
        {
            int indexMaxOdd = -1;
            int maxOdd = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0 && array[i] >= maxOdd)
                {
                    maxOdd = array[i];
                    indexMaxOdd = i;
                }
            }
            if (indexMaxOdd == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexMaxOdd);
            }
        }

        private static void PrintMaxEvenIndex(int[] array)
        {
            int indexMaxEven = -1;
            int maxEven = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && array[i] >= maxEven)
                {
                    maxEven = array[i];
                    indexMaxEven = i;
                }
            }
            if (indexMaxEven == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexMaxEven);
            }
        }

        private static int[] ExchangedArray(int[] array, int index)
        {
            int[] exchangedArray = new int [array.Length];
            for (int i = 0; i < array.Length - index - 1; i++)
            {
                exchangedArray[i] = array[index + i + 1];
            }
            for (int i =  array.Length - index - 1; i < array.Length; i++)
            {
                exchangedArray[i] = array[i - array.Length + index + 1];
            }
            return exchangedArray;
        }
    }
}
