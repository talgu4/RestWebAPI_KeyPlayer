using KeyPlayer.Data.Entities;
using KeyPlayer.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Service
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetPlayersAsync();
        IEnumerable<Player> GetPlayersByTeam(int teamId);
        Player GetPlayer(int id);
        void DeletePlayer(Player player);
        Task<Player> GetPlayerAsync(int id);
        void CreatePlayer(Player player);
        Task<bool> SaveChangesAsync();
    }

    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            this._playerRepository = playerRepository;
        }
        public void CreatePlayer(Player player)
        {
            _playerRepository.Add(player);
        }

        public Player GetPlayer(int id)
        {
            return _playerRepository.GetById(id);
        }
        public async Task<Player> GetPlayerAsync(int id)
        {
            return await _playerRepository.GetPlayerAsync(id);
        }
        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            return await _playerRepository.GetAllAsync();
        }

        public IEnumerable<Player> GetPlayersByTeam(int teamId)
        {
            return _playerRepository.GetAllAsync(teamId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _playerRepository.SaveChangesAsync();
        }
        public void DeletePlayer(Player player)
        {
            _playerRepository.Delete(player);
        }
    }
}
