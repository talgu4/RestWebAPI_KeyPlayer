using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Infrastructure.Interfaces
{

    public enum ERegistrationType
    {
        PerRequest, Singleton, LifetimeScope
    }

    public interface IContainer
    {
        IContainer RegisterType<T>(ERegistrationType t);
        IContainer RegisterType<I, T>(ERegistrationType t);

    }
}
