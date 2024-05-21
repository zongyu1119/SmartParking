using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zy.Shared.Constraint;
using Zy.Shared.Entitys;
using Zy.Shared.Repository.Contexts;
using Zy.Shared.Repository.Repositorys;

namespace Zy.Shared.Repository.Registers;

/// <summary>
/// 注入Db
/// </summary>
public static class RegisterZyDbcontext
{
    /// <summary>
    /// 注入DbContext
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddZyDbcontextServices<T>(this IServiceCollection services,IConfiguration config, ServiceInfo serviceInfo) where T : class,IEntityInfo
    {
        services.AddScoped(typeof(IEntityInfo), typeof(T));

        services.AddDbContext<ZyContext>(opt => {
            string connectionString = config.GetConnectionString("MySQLConnection") ?? "";
            //var serverVersion = ServerVersion.AutoDetect(connectionString);
            opt.UseMySQL(connectionString,  optionsBuilder =>
            {
                optionsBuilder.MinBatchSize(4)
                                        .MigrationsAssembly(serviceInfo.StartAssembly.GetName().Name.Replace("WebApi", "Repository"))
                                        .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });
        });
        //services.AddSingleton(typeof(DbContext), typeof(ZyContext));
        services.AddScoped(typeof(IEfRepository<>),typeof(EfRepository<>));
        return services;
    }
}
