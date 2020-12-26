using System;
using System.Collections.Generic;
using System.Text;

namespace P09CollectionHierarchy.Contracts
{
    public interface IAdd
    {
        IReadOnlyCollection<string> Items { get; }

        int Add(string item);
    }
}
