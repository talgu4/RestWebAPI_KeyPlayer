using KeyPlayer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyPlayer.Data.Entities
{
    public class Team
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public ConsoleColor Color { get; set; }
        public ICollection<Player> Players { get; set; }

    }
}