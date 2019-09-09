using AutoMapper;
using KeyPlayer.Data.Entities;
using KeyPlayer.Data.Model;
using KeyPlayer.Data.Repository;
using KeyPlayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/players")]
    public class PlayersController : ApiController
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamRepository _teamService;
        private readonly IMapper _mapper;

        public PlayersController(IMapper mapper,ITeamRepository teamService, IPlayerService playerService)
        { 
            _playerService = playerService;
            _teamService = teamService;
            _mapper = mapper;
        }
        [Route()]
        public async Task<IHttpActionResult> Get()
        {
            var mappedResult = _mapper.Map<IEnumerable<PlayerModel>>(await _playerService.GetPlayersAsync());
            return Ok(mappedResult);
        }

        [Route("{playerId}", Name = "GetPlayer")]
        public IHttpActionResult Get(int playerId)
        {
            var mappedResult = _mapper.Map<PlayerModel>(_playerService.GetPlayer(playerId));
            return Ok(mappedResult);
        }

        [Route("searchByTeam")]
        [HttpGet]
        public IHttpActionResult SearchByTeam(int teamId)
        {
            var mappedResult = _mapper.Map<IEnumerable<PlayerModel>>(_playerService.GetPlayersByTeam(teamId));
            return Ok(mappedResult);
        }

        [Route()]
        public async Task<IHttpActionResult> Post(PlayerModel model)
        {
            try
            {
                if (_teamService.GetById(model.CurrentTeam) == null)
                {
                    ModelState.AddModelError("CurrentTeam", "Team doesn't exists");
                }
                if (ModelState.IsValid)
                {
                    var newPlayer = _mapper.Map<Player>(model);
                    _playerService.CreatePlayer(newPlayer);
                    if (await _playerService.SaveChangesAsync())
                    {
                        return CreatedAtRoute("GetPlayer", new { playerId = newPlayer.PlayerID}, model);
                    }
                }
            }
            catch (Exception ex)
            {
                //only for dev environment
                return InternalServerError(ex);
            }
            return BadRequest(ModelState);
        }

        [Route("{playerId}")]
        public async Task<IHttpActionResult> Put(int playerId, PlayerModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var player = await _playerService.GetPlayerAsync(playerId);

                    if (player == null) return NotFound();

                    player = _mapper.Map(model, player);
                    if (await _playerService.SaveChangesAsync())
                    {
                        return Ok(_mapper.Map<PlayerModel>(player));
                    }
                    else
                    {
                        return InternalServerError();
                    }
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{playerId}")]
        public async Task<IHttpActionResult> Delete(int playerId)
        {
            try
            {
                var player = await _playerService.GetPlayerAsync(playerId);
                if (player == null) return NotFound();
                _playerService.DeletePlayer(player);
                if (await _playerService.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
