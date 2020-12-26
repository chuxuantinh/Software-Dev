using P08MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
