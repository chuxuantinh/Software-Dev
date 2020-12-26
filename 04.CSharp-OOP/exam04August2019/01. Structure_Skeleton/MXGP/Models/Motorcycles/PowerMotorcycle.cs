using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const int minHorsePower = 70;
        private const int maxHorsePower = 100;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, 450)
        {
            if (horsePower < minHorsePower || horsePower > maxHorsePower)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            }
        }
    }
}
