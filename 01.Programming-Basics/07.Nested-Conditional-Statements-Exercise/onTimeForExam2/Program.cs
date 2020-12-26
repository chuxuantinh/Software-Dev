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
            string result = string.Empty;
            int diffMin = (examHours - studentHours) * 60 + examMinutes - studentMinutes;
            int hours = Math.Abs(diffMin / 60);
            int minutes = Math.Abs(diffMin % 60);
            if (diffMin == 0)
            {
                result = "On time";
            }
            else if (diffMin > 0 && diffMin <= 30)
            {
                result = "On time" + Environment.NewLine + diffMin + " minutes before the start";
            }
            else if (diffMin > 30 && diffMin < 60)
            {
                result = "Early" + Environment.NewLine + diffMin + " minutes before the start";
            }
            else if (diffMin >= 60)
            {
                if (minutes < 10)
                {
                    result = "Early" + Environment.NewLine + hours + ":0" + minutes +  " hours before the start";
                }
                else
                {
                    result = "Early" + Environment.NewLine + hours + ":" + minutes + " hours before the start";
                }
            }
            else if (diffMin < 0 && diffMin > -60)
            {
                result = "Late" + Environment.NewLine + Math.Abs(diffMin) + " minutes after the start";
            }
            else if (diffMin <= -60)
            {
                if (minutes < 10)
                {
                    result = "Late" + Environment.NewLine + hours + ":0" + minutes + " hours after the start";
                }
                else
                {
                    result = "Late" + Environment.NewLine + hours + ":" + minutes + " hours after the start";
                }
            }
            Console.WriteLine(result);
        }
    }
}
