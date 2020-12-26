using System;
using System.Collections.Generic;
using System.Linq;

namespace P02AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            for (int i = 0; i < numberOfStudents; i++)
            {
                var entry = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (students.ContainsKey(entry[0]))
                {
                    students[entry[0]].Add(double.Parse(entry[1]));
                }
                else
                {
                    students[entry[0]] = new List<double>()
                    {
                        double.Parse(entry[1])
                    };
                }
            }
            foreach (var item in students)
            {
                var studentGrades = item.Value;
                Console.WriteLine($"{item.Key} -> {string.Join(" ", item.Value.Select(i => i.ToString("f2")))} (avg: {studentGrades.Average():f2})");
                
            }
        }
    }
}
