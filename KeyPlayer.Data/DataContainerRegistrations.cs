using KeyPlayer.Data.Repository;
using KeyPlayer.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Data
{
    class DataContainerRegistrations : IContainerRegistration
    {
        public void RegisterParts(IContainer container)
        {
            container.RegisterType<KeyPlayerContext>(ERegistrationType.PerRequest)
                     .RegisterType<IPlayerRepository, PlayerRepository>(ERegistrationType.PerRequest)
                     .RegisterType<ITeamRepository, TeamRepository>(ERegistrationType.PerRequest);
        }
    }
}
