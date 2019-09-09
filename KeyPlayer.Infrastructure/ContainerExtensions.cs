using KeyPlayer.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayer.Infrastructure
{
    public static class ContainerExtensions
    {
        public static void RegisterParts(this IContainer container)
        {
            foreach(Assembly currentAssembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach(Type currentType in currentAssembly.GetTypes())
                {
                    if (currentType.IsInterface)
                        continue;

                    var containerRegistrations =  currentType.GetInterfaces().Where(i => i == typeof(IContainerRegistration));

                    foreach(var register in containerRegistrations)
                    {
                        try
                        {

                            var instance = Activator.CreateInstance(currentType);

                            MethodInfo mi = register.GetMethod("RegisterParts");

                            mi.Invoke(instance, new object[] { container });
                        }
                        catch(Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.ToString());
                        }                        
                    }
                }
            }
        }
    }
}
