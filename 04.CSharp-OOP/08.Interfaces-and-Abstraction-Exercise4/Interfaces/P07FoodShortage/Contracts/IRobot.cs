using System;
using System.Collections.Generic;
using System.Text;

namespace P07FoodShortage.Contracts
{
    public interface IRobot : IIdentifiable
    {
        string Model { get; }
    }
}
