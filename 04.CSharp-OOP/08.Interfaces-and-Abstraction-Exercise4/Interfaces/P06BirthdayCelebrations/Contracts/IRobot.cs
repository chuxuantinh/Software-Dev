using System;
using System.Collections.Generic;
using System.Text;

namespace P06BirthdayCelebrations.Contracts
{
    public interface IRobot : IIdentifiable
    {
        string Model { get; }
    }
}
