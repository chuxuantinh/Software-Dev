using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun, IGun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;

        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {

        }

        public override int Fire()
        {
            this.BulletsPerBarrel--;
            if (this.BulletsPerBarrel == 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
            }
            return 1;
        }
    }
}
