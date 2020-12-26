using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onTimeForExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHours = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int studentHours = int.Parse(Console.ReadLine());
            int studentMinutes = int.Parse(Console.ReadLine());

            TimeSpan examTime = new TimeSpan(examHours, examMinutes, 0);
            TimeSpan studentTime = new TimeSpan(studentHours, studentMinutes, 0);
            string result = string.Empty;
            if (examTime == studentTime)
            {
                result = "On time";
            }
            else if (examTime > studentTime && (examTime - studentTime).Minutes <= 30 && (examTime - studentTime).Hours == 0)
            {
                result = "On time" + Environment.NewLine + $"{(examTime - studentTime).Minutes} minutes before the start";
            }
            else if (examTime > studentTime)
            {
                if ((examTime - studentTime).Hours != 0)
                {
                    result = "Early" + Environment.NewLine + $"{(examTime - studentTime).Hours}:{(examTime - studentTime).Minutes:D2} hours before the start";
                }
                else
                {
                    result = "Early" + Environment.NewLine + $"{(examTime - studentTime).Minutes} minutes before the start";
                }
            }
            else if (studentTime > examTime)
            {
                if ((studentTime - examTime).Hours != 0)
                {
                    result = "Late" + Environment.NewLine + $"{(studentTime - examTime).Hours}:{(studentTime - examTime).Minutes:D2} hours after the start";
                }
                else
                {
                    result = "Late" + Environment.NewLine + $"{(studentTime - examTime).Minutes} minutes after the start";
                }
            }
            Console.WriteLine(result);
        }
    }
}
