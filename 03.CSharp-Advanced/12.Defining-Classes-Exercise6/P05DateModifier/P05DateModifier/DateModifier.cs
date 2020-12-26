using System;
using System.Collections.Generic;
using System.Text;

namespace P05DateModifier
{
    public class DateModifier
    {

        public static int CalculateDays(string date1, string date2)
        {
            string[] date1Data = date1.Split();
            int year1 = int.Parse(date1Data[0]);
            int month1 = int.Parse(date1Data[1]);
            int day1 = int.Parse(date1Data[2]);
            DateTime firstDate = new DateTime(year1, month1, day1);
            string[] date2Data = date2.Split();
            int year2 = int.Parse(date2Data[0]);
            int month2 = int.Parse(date2Data[1]);
            int day2 = int.Parse(date2Data[2]);
            DateTime secondDate = new DateTime(year2, month2, day2);
            TimeSpan ts = secondDate - firstDate;
            return Math.Abs(ts.Days);
        }
    }
}
