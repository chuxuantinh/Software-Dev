using System;

namespace SubsetSumWithRepeats
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 3, 5, 2 };

            var targetSum = 6;

            var possibleSums = new bool[targetSum + 1];
            possibleSums[0] = true;

            for (int sum = 0; sum < possibleSums.Length; sum++)
            {
                if (possibleSums[sum])
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        var newSum = sum + numbers[i];

                        if (newSum <= targetSum)
                        {
                            possibleSums[newSum] = true;
                        }
                        
                    }
                }
            }

            while (targetSum != 0)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    var sum = targetSum - numbers[i];
                    if (sum >= 0 && possibleSums[sum])
                    {
                        Console.Write(numbers[i] + " ");
                        targetSum = sum;
                    }
                }
            }

            Console.WriteLine(possibleSums[targetSum]);
        }
    }
}
