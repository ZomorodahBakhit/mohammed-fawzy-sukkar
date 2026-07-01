using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystemApi.Core.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ServiceModule).Assembly)
                  .Where(t => t.Name.EndsWith("Service"))
                  .AsImplementedInterfaces()
                  .PropertiesAutowired();
        }
    }
}
