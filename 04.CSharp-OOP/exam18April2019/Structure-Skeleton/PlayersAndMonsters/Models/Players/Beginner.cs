﻿using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player, IPlayer
    {
        private const int BeginnerInitialHealth = 50;

        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, BeginnerInitialHealth)
        {

        }
    }
}
