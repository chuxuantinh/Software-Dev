﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P04Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Student student = new Student(input[0], input[1], double.Parse(input[2]));
                students.Add(student);
            }
            List<Student> orderedStudents = students.OrderByDescending(s => s.Grade).ToList();
            foreach (Student student in orderedStudents)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }

    class Student
    {
        public Student(string firstName, string secondName, double grade)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Grade = grade;
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade:f2}";
        }
    }
}
