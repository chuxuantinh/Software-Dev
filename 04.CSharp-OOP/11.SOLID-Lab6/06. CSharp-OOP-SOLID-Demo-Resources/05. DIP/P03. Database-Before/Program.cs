using P03._Database;
using System;

namespace P03._Database_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            Courses courses = new Courses(new DatabaseSql());
        }
    }
}
