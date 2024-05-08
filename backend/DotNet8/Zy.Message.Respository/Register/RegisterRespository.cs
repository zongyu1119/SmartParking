using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zy.Shared.Constraint;
using Zy.Shared.Entitys;
using Zy.Shared.Respository.Contexts;
using Zy.Shared.Respository.Register;
using Zy.Shared.Respository.Registers;

namespace Zy.Message.Respository.Registers;

/// <summary>
/// 注入Db
/// </summary>
public static class RegisterRespository
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
