﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01._FileStream_Before.Contracts
{
    public interface IStream
    {
        int Length { get; set; }

        int Sent { get; set; }
    }
}
