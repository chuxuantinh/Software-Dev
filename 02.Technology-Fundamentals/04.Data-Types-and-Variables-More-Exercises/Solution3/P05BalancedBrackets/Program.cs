using System;
using System.Linq;

namespace RandomExercise
{
    class Program
    {
        static void Main()
        {

            byte n = byte.Parse(Console.ReadLine());
            byte open = 0;      // OPENING BRACKETS
            byte close = 0;     // CLOSING BRACKETS

            bool balanced = true;

            for (byte i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "(":
                        open++;
                        break;
                    case ")":
                        if (open == 0)
                        {
                            balanced = false; // no opening bracket before closing bracket
                        }
                        else
                        {
                            close++;
                        }
                        break;
                }

                if (open == 1 && close == 1) // RESET
                {
                    open--;
                    close--;
                }

            }

            if (open == 0 && close == 0 && balanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }

        }



    }
}