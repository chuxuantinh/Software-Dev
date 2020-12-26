using System;
using System.Collections.Generic;
using System.Text;

namespace P09CollectionHierarchy.Contracts
{
    public interface IMyList : IAddRemove
    {
        int Used { get; }
    }
}
