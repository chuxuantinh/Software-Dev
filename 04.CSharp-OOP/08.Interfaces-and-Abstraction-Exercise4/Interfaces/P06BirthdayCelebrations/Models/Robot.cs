﻿using P06BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P06BirthdayCelebrations.Models
{
    public class Robot : IRobot
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
