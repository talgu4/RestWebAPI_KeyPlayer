using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Data.Model
{
    public class PlayerModel
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int CurrentTeam { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
