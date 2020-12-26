using P03.Detail_Printer;
using P03.Detail_Printer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            List<IPrintable> printers = new List<IPrintable>()
            {
                new EmployeePrinter(),
                new ManagerPrinter()
            };

            foreach (IEmployee employee in this.employees)
            {
                printers.First(x => x.isMatch(employee)).PrintDetails(employee);
            }
        }
    }
}
