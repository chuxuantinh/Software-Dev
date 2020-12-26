using System;

class Program
{
    static void Main()
    {
        // input
        string guessNum = Console.ReadLine();
        int targetBulls = int.Parse(Console.ReadLine());
        int targetCows = int.Parse(Console.ReadLine());
        bool hasSolution = false;
        bool isFirst = true;

        for (int num = 1111; num <= 9999; num++)
        {
            int bulls = 0;
            int cows = 0;
            char[] numStr = num.ToString().ToCharArray();
            bool[] isGuessVisted = new bool[numStr.Length];
            bool[] isNumVisted = new bool[numStr.Length];
            // added another bool array to track the digits that are visited from the number we are checking

            if (num.ToString().Contains("0"))
            {
                continue;
            }

            // count bulls and cows
            for (int i = 0; i < guessNum.Length; i++)
            {
                if (guessNum[i] == numStr[i])
                {
                    bulls++;
                    isGuessVisted[i] = true; // set that we have visited this digit at index i
                    isNumVisted[i] = true; // set that we have visited this digit at index i
                }
            }

            for (int i = 0; i < guessNum.Length; i++)
            {
                for (int j = 0; j < numStr.Length; j++)
                {
                    if (i != j &&
                        !isNumVisted[j] &&
                        !isGuessVisted[i] &&
                        guessNum[i] == numStr[j]) // check if digits are the same
                    {
                        cows++;
                        isGuessVisted[i] = true; // set that we have visited this digit at index i
                        isNumVisted[j] = true; // set that we have visited this digit at index j
                    }
                }
            }

            // compare
            if (bulls == targetBulls && cows == targetCows)
            {
                hasSolution = true;
                if (!isFirst)
                {
                    Console.Write(" ");
                }
                Console.Write(num);
                isFirst = false;
            }
        }

        if (!hasSolution)
        {
            Console.WriteLine("No");
        }
    }
}