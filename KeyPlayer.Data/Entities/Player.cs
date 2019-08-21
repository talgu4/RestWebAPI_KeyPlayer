﻿using KeyPlayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyPlayer.Data.Entities
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int TeamID { get; set; }
        public PlayerPosition Position { get; set; }
        
    }
}