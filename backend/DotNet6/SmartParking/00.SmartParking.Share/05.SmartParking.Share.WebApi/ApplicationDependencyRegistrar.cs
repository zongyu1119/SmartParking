using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartParking.Share.Core;
using SmartParking.Share.Infra;
using SmartParking.Share.ObjExt;
using SmartParking.Share.Str;
using System.Reflection;

namespace SmartParking.Share.WebApi
{
    public abstract class ApplicationDependencyRegistrar
    {
        public abstract Assembly RepositoryOrDomainLayerAssembly { get; }

        protected IServiceCollection Services { get; init; }
        protected IServiceInfo ServiceInfo { get; init; }

        protected IConfiguration Configuration { get; init; }

        protected IConfigurationSection MysqlSection { get; init; }

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
                if (this.IsDevelopment())
                {
                    options.LogTo(new Action<string>(Console.WriteLine), LogLevel.Information).EnableSensitiveDataLogging().EnableDetailedErrors();
                }
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
