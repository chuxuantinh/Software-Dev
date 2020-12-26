using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int minHorsePower = 50;
        private const int maxHorsePower = 69;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, 125)
        {
            if (horsePower < minHorsePower || horsePower > maxHorsePower)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            }
        }
    }
}
