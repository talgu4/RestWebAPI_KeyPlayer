using AutoMapper;
using KeyPlayer.Data.Model;
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
    [RoutePrefix("api/teams")]
    public class TeamsController : ApiController
    {
        private readonly ITeamsService _teamsService;
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public TeamsController(IMapper mapper, ITeamsService teamsService,IPlayerService playerService)
        {
            _teamsService = teamsService;
            _playerService = playerService;
            _mapper = mapper;
        }

        public async Task<IHttpActionResult> Get(bool includePlayers = false)
        {
            return Ok(_mapper.Map<IEnumerable<TeamModel>>(await _teamsService.GetTeamsAsync(includePlayers)));
        }
    }
}
