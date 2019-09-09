using KeyPlayer.Data.Entities;
using KeyPlayer.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Data.Repository
{ 
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(KeyPlayerContext ctx) : base(ctx)
        {
        }

        public IEnumerable<Player> GetAllAsync(int teamId)
        {
            return this.DbContext.Players.Where(x => x.TeamID == teamId).ToList();
        }
        public async Task<Player> GetPlayerAsync(int id)
        {
            var query = this.DbContext.Players.Where(p => p.PlayerID == id);
            return await query.FirstOrDefaultAsync();
        }
    }

    public interface IPlayerRepository : IRepository<Player>
    {
        IEnumerable<Player> GetAllAsync(int teamId);
        Task<Player> GetPlayerAsync(int id);
    }
}
