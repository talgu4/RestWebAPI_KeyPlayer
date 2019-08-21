using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Mapping
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>
                {
                    new PlayerMappingProfile(),
                    new TeamMappingProfile()
                });
            });

            return mapperConfig;
        }
    }
}