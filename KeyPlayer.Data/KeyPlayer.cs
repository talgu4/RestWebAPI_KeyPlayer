using KeyPlayer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Data
{
    public class KeyPlayerContext : DbContext
    {
        public KeyPlayerContext():base("KeyPlayer")
        {
            Database.SetInitializer(new KeyPlayerSeedData());
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players{ get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
