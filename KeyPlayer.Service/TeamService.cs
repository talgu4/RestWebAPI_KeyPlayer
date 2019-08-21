using KeyPlayer.Data.Entities;
using KeyPlayer.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Service
{
    public interface ITeamsService
    {
        Task<IEnumerable<Team>> GetTeamsAsync(bool includePlayers = false);
        Team GetTeam(int id);
    }
    public class TeamService : ITeamsService
    {
        private readonly ITeamService _teamRepository;

        public TeamService(ITeamService teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public Team GetTeam(int id)
        {
            return _teamRepository.GetById(id);
        }

        public Task<IEnumerable<Team>> GetTeamsAsync(bool includePlayers = false)
        {
            return _teamRepository.GetTeamsAsync(includePlayers);
        }
    }
}
