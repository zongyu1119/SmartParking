using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Application.Registrar;
using zy.webcore.Usr.Constraint.IServices;
using zy.webcore.Usr.Repository.EntitiesBase;

namespace zy.webcore.Usr.WebApi.Register
{
    public class ApplicationDependencyRegistrar : AbstractApplicationDependencyRegistrar
    {
        public ApplicationDependencyRegistrar(IServiceCollection service) : base(service) { }
        public override Assembly ApplicationLayerAssembly => typeof(IUserService).Assembly;

        public override Assembly RepositoryOrDomainLayerAssembly => typeof(EntityInfo).Assembly;
        public override void AddZyWebCore()
        {
            AddApplicaitonDefault();
        }
    }
}
