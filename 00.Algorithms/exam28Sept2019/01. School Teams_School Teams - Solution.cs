using System;
using System.Collections.Generic;

    class SchoolTeams
    {
        private static List<string> girlsBuilder;
        private static List<string> boysBuilder;

        public static void Main()
        {
            girlsBuilder = new List<string>();
            boysBuilder = new List<string>();

            string[] girls = Console.ReadLine().Split(", ");
            string[] boys = Console.ReadLine().Split(", ");
            string[] girlsCombinations = new string[3];
            string[] boysCombinations = new string[2];

            CombGirls(girls, 0, 0, girlsCombinations);
            CombBoys(boys, 0, 0, boysCombinations);

            for (int i = 0; i < girlsBuilder.Count; i++)
            {
                for (int j = 0; j < boysBuilder.Count; j++)
                {
                    Console.WriteLine(girlsBuilder[i] + ", " + boysBuilder[j]);
                }
            }
        }
        private static void CombGirls(string[] data, int index, int start, string[] combinations)
        {
            if (index >= combinations.Length)
            {
                AppendGirls(combinations);
            }
            else
            {
                for (int i = start; i < data.Length; i++)
                {
                    combinations[index] = data[i];
                    CombGirls(data, index + 1, i + 1, combinations);
                }
            }
        }


        private static void CombBoys(String[] data, int index, int start, String[] combinations)
        {
            if (index >= combinations.Length)
            {
                AppendBoys(combinations);
            }
            else
            {
                for (int i = start; i < data.Length; i++)
                {
                    combinations[index] = data[i];
                    CombBoys(data, index + 1, i + 1, combinations);
                }
            }
        }

        private static void AppendGirls(string[] combinations)
        {
            girlsBuilder.Add(string.Join(", ", combinations));
        }

        private static void AppendBoys(String[] combinations)
        {
            boysBuilder.Add(string.Join(", ", combinations));
        }
    }

