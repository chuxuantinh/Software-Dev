using System;
using System.Collections.Generic;
using System.Linq;

namespace P10SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();
            string command = Console.ReadLine();
            while (command != "course start")
            {
                string[] tokens = command.Split(':');
                if (tokens[0] == "Add")
                {
                    if (!lessons.Contains(tokens[1]))
                    {
                        lessons.Add(tokens[1]);
                    }
                }
                else if (tokens[0] == "Insert")
                {
                    if (!lessons.Contains(tokens[1]))
                    {
                        lessons.Insert(int.Parse(tokens[2]), tokens[1]);
                    }
                }
                else if (tokens[0] == "Remove")
                {
                    if (lessons.Contains(tokens[1]))
                    {
                        lessons.Remove(tokens[1]);
                    }
                    if (lessons.Contains($"{tokens[1]}-Exercise"))
                    {
                        lessons.Remove($"{tokens[1]}-Exercise");
                    }
                }
                else if (tokens[0] == "Swap")
                {
                    if (lessons.Contains(tokens[1]) && lessons.Contains(tokens[2]))
                    {
                        
                        int indexOfLesson1 = lessons.IndexOf(tokens[1]);
                        int indexOfLesson2 = lessons.IndexOf(tokens[2]);
                        if (indexOfLesson1 > indexOfLesson2)
                        {
                            int tempIndex = indexOfLesson1;
                            indexOfLesson1 = indexOfLesson2;
                            indexOfLesson2 = tempIndex;
                        }
                        string tempLesson = lessons[indexOfLesson1];
                        lessons[indexOfLesson1] = lessons[indexOfLesson2];
                        lessons[indexOfLesson2] = tempLesson;
                        if (lessons.Contains($"{tokens[1]}-Exercise") && lessons.Contains($"{tokens[2]}-Exercise"))
                        {
                            lessons.Insert(indexOfLesson2 + 1, $"{tokens[1]}-Exercise");
                            lessons.Remove($"{tokens[1]}-Exercise");
                        
                            lessons.Insert(indexOfLesson1 + 1, $"{tokens[2]}-Exercise");
                            lessons.RemoveAt(indexOfLesson2 + 2);
                        }
                        else if (lessons.Contains($"{tokens[1]}-Exercise") && !lessons.Contains($"{tokens[2]}-Exercise"))
                        {
                            lessons.Insert(indexOfLesson2 + 1, $"{tokens[1]}-Exercise");
                            lessons.Remove($"{tokens[1]}-Exercise");
                        }
                        else if (!lessons.Contains($"{tokens[1]}-Exercise") && lessons.Contains($"{tokens[2]}-Exercise"))
                        {
                            lessons.Insert(indexOfLesson1 + 1, $"{tokens[2]}-Exercise");
                            lessons.RemoveAt(indexOfLesson2 + 2);
                        }
                    }
                }
                else if (tokens[0] == "Exercise")
                {
                    if (lessons.Contains(tokens[1]) && !lessons.Contains($"{tokens[1]}-Exercise"))
                    {
                        int indexOfLesson = lessons.IndexOf(tokens[1]);
                        lessons.Insert(indexOfLesson + 1, $"{tokens[1]}-Exercise");
                    }
                    else if (!lessons.Contains(tokens[1]) && !lessons.Contains($"{tokens[1]}-Exercise"))
                    {
                        lessons.Add(tokens[1]);
                        lessons.Add($"{tokens[1]}-Exercise");
                    }
                }
                command = Console.ReadLine();
            }
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
