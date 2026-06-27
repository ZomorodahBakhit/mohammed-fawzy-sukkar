using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystemApi.Data.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(RepositoryModule).Assembly)
                  .Where(t => t.Name.EndsWith("Repository"))
                  .AsImplementedInterfaces()
                  .PropertiesAutowired();
        }
    }
}
