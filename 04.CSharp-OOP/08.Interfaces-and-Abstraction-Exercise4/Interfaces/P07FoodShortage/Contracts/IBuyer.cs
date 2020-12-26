using System;
using System.Collections.Generic;
using System.Text;

namespace P07FoodShortage.Contracts
{
    public interface IBuyer : INameable
    {
        int Food { get; }

        int BuyFood();
    }
}
