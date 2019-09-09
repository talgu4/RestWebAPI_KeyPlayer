using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Infrastructure.Interfaces
{
    public interface IContainerRegistration
    {
        void RegisterParts(IContainer container);
    }
}
