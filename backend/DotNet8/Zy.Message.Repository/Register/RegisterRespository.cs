using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zy.Shared.Constraint;
using Zy.Shared.Entitys;
using Zy.Shared.Repository.Contexts;
using Zy.Shared.Repository.Register;
using Zy.Shared.Repository.Registers;

namespace Zy.Message.Repository.Registers;

/// <summary>
/// 注入Db
/// </summary>
public static class RegisterRepository
{
    /// <summary>
    /// 注入DbContext
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddMessageDbcontextServices(this IServiceCollection services,ServiceInfo serviceInfo, IConfiguration config)
    {
        services.AddShardingCoreDbcontextServices<EntityInfo>(config,serviceInfo);
        //services.AddZyDbcontextServices<EntityInfo>(config,serviceInfo);
        return services;
    }
}
