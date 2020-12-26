using System;
using System.Collections.Generic;
using System.Text;

namespace P05BorderControl.Contracts
{
    public interface ICitizen : IIdentifiable
    {
        string Name { get; }

        int Age { get; }
    }
}
