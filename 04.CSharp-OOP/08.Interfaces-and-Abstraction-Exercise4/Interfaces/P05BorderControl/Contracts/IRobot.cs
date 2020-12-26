using System;
using System.Collections.Generic;
using System.Text;

namespace P05BorderControl.Contracts
{
    public interface IRobot : IIdentifiable
    {
        string Model { get; }
    }
}
