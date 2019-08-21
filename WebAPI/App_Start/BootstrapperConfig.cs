using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using KeyPlayer.Data;
using KeyPlayer.Data.Infrastructure;
using KeyPlayer.Data.Repository;
using KeyPlayer.Service;
using WebAPI.Mapping;

namespace WebAPI.App_Start
{
    public class BootstrapperConfig
    {
        public static void Register()
        {
            var bldr = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            bldr.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterServices(bldr);
            bldr.RegisterWebApiFilterProvider(config);
            bldr.RegisterWebApiModelBinderProvider();
            var container = bldr.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder bldr)
        {

            MapperConfiguration config = AutoMapperConfig.Configure();

            bldr.RegisterInstance(config.CreateMapper())
              .As<IMapper>()
              .SingleInstance();

            bldr.RegisterType<KeyPlayerContext>()
              .InstancePerRequest();

            bldr.RegisterType<DbFactory>()
                .As<IDbFactory>().InstancePerRequest();

            bldr.RegisterType<PlayerService>()
                .As<IPlayerService>().InstancePerRequest();
            bldr.RegisterType<PlayerRepository>()
                .As<IPlayerRepository>().InstancePerRequest();


            bldr.RegisterType<TeamService>()
                .As<ITeamsService>().InstancePerRequest();
            bldr.RegisterType<TeamRepository>()
                .As<ITeamService>().InstancePerRequest();



        }
    }
}