using KeyPlayer.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Service
{
    class ServiceContainerRegistrations : IContainerRegistration
    {
        public void RegisterParts(IContainer container)
        {
            container.RegisterType<ITeamsService, TeamService>(ERegistrationType.PerRequest)
                .RegisterType<IPlayerService,PlayerService>(ERegistrationType.PerRequest);
        }
    }
}
