﻿using P03.Detail_Printer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : IEmployee
    {
        public Manager(string name, ICollection<string> documents)
        {
            this.Documents = new List<string>(documents);
            this.Name = name;
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public string Name { get; set; }
    }
}
