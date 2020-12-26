using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun, IGun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;

        public Rifle(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {

        }

        public override int Fire()
        {
            this.BulletsPerBarrel -= 5;
            if (this.BulletsPerBarrel == 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
            }
            return 5;
        }
    }
}
