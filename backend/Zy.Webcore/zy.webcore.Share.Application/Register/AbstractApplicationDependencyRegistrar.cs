using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkyApm.Utilities.DependencyInjection;
using System.Reflection;
using zy.webcore.Share.Constraint.Core.Interfaces;
using zy.webcore.Share.ZyEfcore;
using zy.webcore.Share.Rpc.RpcBase;
using zy.webcore.Share.Extensions;
using zy.webcore.Share.Consts.ConfigKey;
using zy.webcore.Share.Application.Utilitys;
using zy.webcore.Share.Redis.Registrar;
using zy.webcore.Share.Application.Caching;
using zy.webcore.Share.Cache.Register;

namespace zy.webcore.Share.Application.Registrar;

public abstract partial class AbstractApplicationDependencyRegistrar : IDependencyRegistrar
{
    public string Name => "application";
    public abstract Assembly ApplicationLayerAssembly { get; }
    public abstract Assembly RepositoryOrDomainLayerAssembly { get; }
    protected SkyApmExtensions SkyApm { get; init; }
    protected List<AddressNode> RpcAddressInfo { get; init; }
    protected IServiceCollection Services { get; init; }
    protected IConfiguration Configuration { get; init; }
    protected IServiceInfo ServiceInfo { get; init; }
    protected IConfigurationSection RedisSection { get; init; }
    protected IConfigurationSection CachingSection { get; init; }
    protected IConfigurationSection MysqlSection { get; init; }
    protected IConfigurationSection MongoDbSection { get; init; }
    protected IConfigurationSection ConsulSection { get; init; }
    protected IConfigurationSection RabbitMqSection { get; init; }

    protected AbstractApplicationDependencyRegistrar(IServiceCollection services)
    {
        Services = services ?? throw new ArgumentException("IServiceCollection is null.");
        Configuration = services.GetConfiguration() ?? throw new ArgumentException("Configuration is null.");
        ServiceInfo = services.GetServiceInfo() ?? throw new ArgumentException("ServiceInfo is null.");
        RedisSection = Configuration.GetSection(ConfigKey.Redis);
        CachingSection = Configuration.GetSection(ConfigKey.Caching);
        MongoDbSection = Configuration.GetSection(ConfigKey.MongoDb);
        MysqlSection = Configuration.GetSection(ConfigKey.Mysql);
        ConsulSection = Configuration.GetSection(ConfigKey.Consul);
        RabbitMqSection = Configuration.GetSection(ConfigKey.RabbitMq);
        SkyApm = Services.AddSkyApmExtensions();
        RpcAddressInfo = Configuration.GetSection(ConfigKey.RpcAddressInfo).Get<List<AddressNode>>();
    }

    /// <summary>
    /// 注册所有服务
    /// </summary>
    public abstract void AddZyWebCore();

    /// <summary>
    /// 注册application通用服务
    /// </summary>
    protected virtual void AddApplicaitonDefault()
    {
        Services
            .AddZyCoreAutoMapper(ApplicationLayerAssembly);
        AddApplicationSharedServices();
        AddEfCoreContextWithRepositories();
        AddRedisCaching();
    }

    /// <summary>
    /// 注册application.shared层服务
    /// </summary>
    protected void AddApplicationSharedServices()
    {
        Services.AddSingleton(typeof(Lazy<>));
        Services.AddScoped<UserContext>();
        Services.AddSingleton(typeof(IdGeneratorHelper),new IdGeneratorHelper());
    }
    /// <summary>
    /// 注册缓存
    /// </summary>
    private void AddRedisCaching()
    {
        Services.AddZyRedisCaching(RedisSection, CachingSection);
        var serviceType = typeof(ICachePreheatable);
        var implTypes = ApplicationLayerAssembly.ExportedTypes.Where(type => type.IsAssignableTo(serviceType) && type.IsNotAbstractClass(true));
        if (implTypes.IsNotNullOrEmpty())
        {
            implTypes.ForEach(implType =>
            {
                Services.AddSingleton(implType, implType);
                Services.AddSingleton(x => x.GetRequiredService(implType) as ICachePreheatable);
            });
        }
        Services.AddCacheService();
    }
}