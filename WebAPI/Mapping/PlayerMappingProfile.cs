using AutoMapper;
using KeyPlayer.Common;
using KeyPlayer.Data.Entities;
using KeyPlayer.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Mapping
{
    public class PlayerMappingProfile : Profile
    {
        public PlayerMappingProfile()
        {
            //CreateMap<Player, PlayerModel>()
            //    .ForMember(p => p.Position, opt => opt.MapFrom(m => m.Position.ToString()));

            CreateMap<PlayerModel, Player>()
                .ForMember(p => p.Position, opt => opt.MapFrom(m => Enum.Parse(typeof(PlayerPosition),m.Position)))
                .ForMember(p=> p.TeamID,opt=>opt.MapFrom(m=> m.CurrentTeam)).ReverseMap();
        }
    }
}