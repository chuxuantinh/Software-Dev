﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P08MilitaryElite.Contracts
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}