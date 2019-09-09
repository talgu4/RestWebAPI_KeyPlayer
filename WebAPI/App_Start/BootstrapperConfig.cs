using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using WebAPI.Mapping;
using KeyPlayer.Infrastructure;
using KeyPlayer.Infrastructure.Interfaces;

namespace WebAPI.App_Start
{
    internal class Container : KeyPlayer.Infrastructure.Interfaces.IContainer
    {
        private readonly ContainerBuilder _containerBuilder;

        public Container(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }

        public KeyPlayer.Infrastructure.Interfaces.IContainer RegisterType<T>(ERegistrationType registrationType)
        {
            var x = _containerBuilder.RegisterType<T>();
            InstancePerType(registrationType, x);
            return this;
        }
        public KeyPlayer.Infrastructure.Interfaces.IContainer RegisterType<I, T>(ERegistrationType registrationType)
        {
            var x = _containerBuilder.RegisterType<T>().As<I>();
            InstancePerType(registrationType, x);
            return this;
        }
        private static void InstancePerType<T>(ERegistrationType registrationType,
                                               Autofac.Builder.IRegistrationBuilder<T, Autofac.Builder.ConcreteReflectionActivatorData,
                                               Autofac.Builder.SingleRegistrationStyle> x)
        {
            switch (registrationType)
            {
                case ERegistrationType.PerRequest:
                    x.InstancePerRequest();
                    break;
                case ERegistrationType.Singleton:
                    x.SingleInstance();
                    break;
                case ERegistrationType.LifetimeScope:
                    x.InstancePerLifetimeScope();
                    break;
            }
        }
    }



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
            KeyPlayer.Infrastructure.Interfaces.IContainer c = new Container(bldr);

            var config = AutoMapperConfig.Configure();
            bldr.RegisterInstance(config.CreateMapper())
              .As<IMapper>()
              .SingleInstance();
            
            c.RegisterParts();

        }
    }
}