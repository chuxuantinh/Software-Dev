using P03.Detail_Printer.Contracts;
using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer
{
    public class EmployeePrinter : IPrintable
    {
        public bool isMatch(IEmployee employee)
        {
            if (employee is Employee)
            {
                return true;
            }

            return false;
        }

        public void PrintDetails(IEmployee employee)
        {
            var employeeType = employee as Employee;
            Console.WriteLine(employeeType.Name);
        }
    }
}
