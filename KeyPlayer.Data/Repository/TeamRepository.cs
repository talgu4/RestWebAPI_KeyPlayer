using KeyPlayer.Data.Entities;
using KeyPlayer.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace KeyPlayer.Data.Repository
{
    public class TeamRepository : BaseRepository<Team>, ITeamService
    {
        public TeamRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Team GetTeamByName(string teamName)
        {
            return this.DbContext.Teams.Where(t => t.Name.Equals(teamName)).FirstOrDefault();
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync(bool includePlayers = false)
        {
            if (includePlayers)
            {
                var query = DbContext.Teams.Include(team => team.Players);
                return await query.ToArrayAsync();
            }
            return await base.GetAllAsync();
        }
    }

    public interface ITeamService : IRepository<Team>
    {
        Team GetTeamByName(string teamName);
        Task<IEnumerable<Team>> GetTeamsAsync(bool includePlayers = false);
    }
}
