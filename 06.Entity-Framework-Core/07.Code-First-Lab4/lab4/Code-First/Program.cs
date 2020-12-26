using CodeFirst.Data;
using CodeFirst.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var db = new StudentsDbContext();

            db.Database.Migrate();

            var courses = db
                .Courses
                .Select(c => new
                {
                    c.Name,
                    TotalStudents = c.Students.Where(st => st.Course.Homeworks.Average(h => h.Score) > 2).Count(),
                    Students = c
                        .Students
                        .Select(st => new
                        {
                            FullName = st.Student.FirstName + " " + st.Student.LastName,
                            Score = st.Student.Homeworks.Average(h => h.Score)
                        })
                })
                .ToList();
        }
    }
}
