using KeyPlayer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Data.Model
{
    public class TeamModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public ConsoleColor Color { get; set; }
        public ICollection<string> Players { get; set; }
    }
}
