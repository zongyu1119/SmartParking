using SmartParking.Share.Entity;
using SmartParking.Share.Infra;
using SmartParking.Share.WebApi;
using System.Reflection;

namespace SmartParking.Server.WebApi.Registrar
{
    public class AppDependencyRegistrar : ApplicationDependencyRegistrar
    {
        public override Assembly ApplicationLayerAssembly => Assembly.GetExecutingAssembly();

        public override Assembly ContractsLayerAssembly => typeof(IUserInfoService).Assembly;

        public override Assembly RepositoryOrDomainLayerAssembly => typeof(Entity).Assembly;

        public AppDependencyRegistrar(IServiceCollection services) : base(services)
        {
        }
    }
}
