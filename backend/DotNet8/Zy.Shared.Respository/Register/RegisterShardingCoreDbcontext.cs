using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShardingCore;
using ShardingCore.Core.DbContextCreator;
using ShardingCore.Sharding.ReadWriteConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Constraint;
using Zy.Shared.Entitys;
using Zy.Shared.Respository.Contexts;
using Zy.Shared.Respository.Entitys;
using Zy.Shared.Respository.Respositorys;

namespace Zy.Shared.Respository.Register
{
    public static class RegisterShardingCoreDbcontext
    {
        /// <summary>
        /// 注入DbContext
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddShardingCoreDbcontextServices<T>(this IServiceCollection services, IConfiguration config, ServiceInfo serviceInfo) where T : class, IEntityInfo
        {
            services.AddSingleton(typeof(IEntityInfo), typeof(T));
           //services.AddScoped<DbContext,ZyShardingCoreContext>();
            services.AddShardingDbContext<ZyShardingCoreContext>().UseRouteConfig(op =>
            {
                var routeType = typeof(T);
                var routeTypes = routeType.Assembly
                    .GetExportedTypes()
                    .Where(type => type.IsClass&&!type.IsAbstract && type.IsAssignableTo(typeof(IShardingCoreVirtualTableRoute)))
                    .ToList();
                if(routeTypes.Any())
                {
                    routeTypes.ForEach(type =>
                    {
                        op.AddShardingTableRoute(type);
                    });
                }
            }).UseConfig(op =>
            {
                //当无法获取路由时会返回默认值而不是报错
                op.ThrowIfQueryRouteNotMatch = false;
                string connectionString = config.GetConnectionString("MySQLConnection") ?? "";
                var serverVersion = ServerVersion.AutoDetect(connectionString);
                op.UseShardingQuery((conStr, builder) =>
                {
                    builder.UseMySql(conStr,serverVersion, optionsBuilder =>
                    {
                        optionsBuilder.EnableRetryOnFailure();
                        optionsBuilder.MinBatchSize(4)
                                                .MigrationsAssembly(serviceInfo.StartAssembly.GetName().Name.Replace("WebApi", "Respository"))
                                                .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
                });
                op.UseShardingTransaction((connection, builder) =>
                {
                    builder.UseMySql(connection, serverVersion, optionsBuilder =>
                    {
                        optionsBuilder.EnableRetryOnFailure();
                        optionsBuilder.MinBatchSize(4)
                                                .MigrationsAssembly(serviceInfo.StartAssembly.GetName().Name.Replace("WebApi", "Respository"))
                                                .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
                });
                
                op.AddDefaultDataSource("ds0", connectionString);
                op.AddReadWriteSeparation(sp =>
                {
                    return new Dictionary<string, IEnumerable<string>>()
                    {
                        {
                            "ds0", new List<string>()
                            {
                                connectionString
                            }
                        }
                    };
                }, ReadStrategyEnum.Loop, ReadWriteDefaultEnableBehavior.DefaultDisable);
            })
           // .ReplaceService<IDbContextCreator, ZyShardingCoreDbContextCreator>(ServiceLifetime.Scoped)
            .AddShardingCore();

            services.AddScoped(typeof(IEfRespository<>), typeof(EfRespository<>));
            return services;
        }
        
    }
}
