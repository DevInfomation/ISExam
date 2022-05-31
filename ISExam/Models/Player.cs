﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISExam.Models
{
    public class Player
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime SigningDate { get; set; }
        public int Rank { get; set; }
        public int TotalGoals { get; set; }
        public string Club { get; set; }
    }
}
