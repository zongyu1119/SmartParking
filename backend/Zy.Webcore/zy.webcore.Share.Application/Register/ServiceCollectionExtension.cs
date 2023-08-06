
using zy.webcore.Share.Repository.IRepositories;

namespace zy.webcore.Share.Application.Registrar
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddZyEfCoreMySql(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder)
        {

            if (services.HasRegistered(nameof(AddZyEfCoreMySql)))
                return services;

            services.TryAddScoped<IUnitOfWork, MySqlUnitOfWork<MySqlDbContext>>();
            services.TryAddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
            services.TryAddScoped(typeof(IEfBasicRepository<>), typeof(EfBasicRepository<>));
            services.AddDbContext<DbContext, MySqlDbContext>(optionsBuilder);

            return services;
        }
        /// <summary>
        /// 通用的注册服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceInfo"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static IServiceCollection AddZyWebCore(this IServiceCollection services, IServiceInfo serviceInfo)
        {
            var webApiRegistarType = serviceInfo.StartAssembly.ExportedTypes.FirstOrDefault(m => m.IsAssignableTo(typeof(IDependencyRegistrar)) && m.IsNotAbstractClass(true));
            if (webApiRegistarType is null)
                throw new NullReferenceException(nameof(IDependencyRegistrar));

            var webapiRegistar = Activator.CreateInstance(webApiRegistarType, services) as IDependencyRegistrar;
            webapiRegistar.AddZyWebCore();
            return services;
        }
    }
}
