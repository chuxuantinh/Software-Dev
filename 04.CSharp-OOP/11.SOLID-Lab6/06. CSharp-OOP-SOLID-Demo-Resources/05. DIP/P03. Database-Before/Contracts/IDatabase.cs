using System;
using System.Collections.Generic;
using System.Text;

namespace P03._Database_Before.Contracts
{
    public interface IDatabase
    {
        IEnumerable<int> CourseIds();

        IEnumerable<string> CourseNames();

        IEnumerable<string> Search(string substring);

        string GetCourseById(int id);
    }
}
