using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Contracts
{
    public interface IPrintable
    {
        void PrintDetails(IEmployee employee);

        bool isMatch(IEmployee employee);
    }
}
