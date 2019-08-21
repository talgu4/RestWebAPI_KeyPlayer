using AutoMapper;
using KeyPlayer.Data.Entities;
using KeyPlayer.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Mapping
{
    public class TeamMappingProfile: Profile
    {
        public TeamMappingProfile()
        {
            CreateMap<Team, TeamModel>()
                .ForMember(p => p.Players, opt => opt.MapFrom(m => m.Players.Select(x=> $"{x.FirstName } {x.LastName}")));
        }
    }
}