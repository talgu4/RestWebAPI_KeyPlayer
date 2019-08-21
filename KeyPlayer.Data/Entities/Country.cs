using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyPlayer.Data.Entities
{
    public class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
        public ConsoleColor Color { get; set; }
        public ICollection<Team> Teams { get; set; }

    }
}