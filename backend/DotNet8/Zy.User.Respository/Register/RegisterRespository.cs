using Zy.Shared.Respository.Register;

namespace Zy.User.Respository.Registers;

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
    public static IServiceCollection AddDbcontextServices(this IServiceCollection services,ServiceInfo serviceInfo, IConfiguration config)
    {
        //services.AddZyDbcontextServices<EntityInfo>(config,serviceInfo);
        services.AddShardingCoreDbcontextServices<EntityInfo>(config, serviceInfo);
        return services;
    }
}
