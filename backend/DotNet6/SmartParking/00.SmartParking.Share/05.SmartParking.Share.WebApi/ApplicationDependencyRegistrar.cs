using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SkyApm.Utilities.DependencyInjection;
using SmartParking.Share.Consts;
using SmartParking.Share.Core;
using SmartParking.Share.Infra;
using SmartParking.Share.ObjExt;
using SmartParking.Share.Str;
using System.Reflection;

namespace SmartParking.Share.WebApi
{
    public abstract class ApplicationDependencyRegistrar
    {
        protected ApplicationDependencyRegistrar(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentException("IServiceCollection is null.");
            Configuration = services.GetConfiguration() ?? throw new ArgumentException("Configuration is null.");
            ServiceInfo = services.GetServiceInfo() ?? throw new ArgumentException("ServiceInfo is null.");
            RedisSection = Configuration.GetSection(AppSettings.Redis);
            CachingSection = Configuration.GetSection(AppSettings.Caching);
            MongoDbSection = Configuration.GetSection(AppSettings.MongoDb);
            MysqlSection = Configuration.GetSection(AppSettings.Mysql);
            ConsulSection = Configuration.GetSection(AppSettings.Consul);
            RabbitMqSection = Configuration.GetSection(AppSettings.RabbitMq);
            SkyApm = Services.AddSkyApmExtensions();
            RpcAddressInfo = Configuration.GetSection(AppSettings.RpcAddressInfo).Get<List<Rpc.AddressNode>>();
        }       
        public string Name => "application";
        public abstract Assembly ApplicationLayerAssembly { get; }
        public abstract Assembly ContractsLayerAssembly { get; }
        public abstract Assembly RepositoryOrDomainLayerAssembly { get; }
        protected SkyApmExtensions SkyApm { get; init; }
        protected List<Rpc.AddressNode> RpcAddressInfo { get; init; }
        protected IServiceCollection Services { get; init; }
        protected IConfiguration Configuration { get; init; }
        protected IServiceInfo ServiceInfo { get; init; }
        protected IConfigurationSection RedisSection { get; init; }
        protected IConfigurationSection CachingSection { get; init; }
        protected IConfigurationSection MysqlSection { get; init; }
        protected IConfigurationSection MongoDbSection { get; init; }
        protected IConfigurationSection ConsulSection { get; init; }
        protected IConfigurationSection RabbitMqSection { get; init; }

        protected virtual void AddEfCoreContextWithRepositories(int major, int minor, int build)
        {
            Type serviceType = typeof(IEntityInfo);
            Type type2 = RepositoryOrDomainLayerAssembly.ExportedTypes.FirstOrDefault((Type type) => type.IsAssignableTo(serviceType) && type.IsNotAbstractClass(publicOnly: true));
            if ((object)type2 == null)
            {
                throw new NullReferenceException("IEntityInfo");
            }

            Services.AddSingleton(serviceType, type2);
            Services.AddScoped(delegate (IServiceProvider provider)
            {
                UserContext requiredService = provider.GetRequiredService<UserContext>();
                return new Operater
                {
                    Id = ((requiredService.Id == 0L) ? 0 : requiredService.Id),
                    Account = (requiredService.Account.IsNullOrEmpty() ? "system" : requiredService.Account),
                    Name = (requiredService.Name.IsNullOrEmpty() ? "system" : requiredService.Name)
                };
            });
            AddEfCoreContext(new Version(major, minor, build));
        }

        protected virtual void AddEfCoreContext(Version version)
        {
            MysqlConfig mysqlConfig = MysqlSection.Get<MysqlConfig>();
            MySqlServerVersion serverVersion = new MySqlServerVersion(version);
            Services.AddInfraEfCoreMySql(delegate (DbContextOptionsBuilder options)
            {
                options.UseLowerCaseNamingConvention();
                options.UseMySql(mysqlConfig.ConnectionString, serverVersion, delegate (MySqlDbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.MinBatchSize(4).MigrationsAssembly(ServiceInfo.StartAssembly.GetName().Name!.Replace("WebApi", "Migrations")).UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
            });
        }
       
        public virtual bool IsDevelopment()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}
