using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonPattern
{
    public interface ISingletonContainer
    {
        int GetPopulation(string name);
    }
}
