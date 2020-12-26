using System;
using System.Collections.Generic;
using System.Text;

namespace P06BirthdayCelebrations.Contracts
{
    public interface ICitizen : IIdentifiable, IBirthable, INameable
    {
        int Age { get; }
    }
}
