﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string DateOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string Nationality { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
