using System;
using System.Collections.Generic;
using System.Text;

namespace P07FoodShortage.Contracts
{
    public interface ICitizen : IIdentifiable, IBirthable, IBuyer
    {
        int Age { get; }
    }
}
