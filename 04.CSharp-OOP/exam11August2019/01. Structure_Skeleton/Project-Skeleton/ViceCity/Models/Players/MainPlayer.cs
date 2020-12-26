﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const string Name = "Tommy Vercetti";
        private const int InitialLifePoints = 100;

        public MainPlayer() 
            : base(Name, InitialLifePoints)
        {
        }
    }
}
