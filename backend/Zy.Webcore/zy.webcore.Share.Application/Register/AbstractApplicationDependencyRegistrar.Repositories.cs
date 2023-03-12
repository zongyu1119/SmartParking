
namespace zy.webcore.Share.Application.Registrar;

public abstract partial class AbstractApplicationDependencyRegistrar
{
    /// <summary>
    /// 注册EFCoreContext与仓储
    /// </summary>
    protected virtual void AddEfCoreContextWithRepositories()
    {
        var serviceType = typeof(IEntityInfo);
        var implType = RepositoryOrDomainLayerAssembly.ExportedTypes.FirstOrDefault(type => type.IsAssignableTo(serviceType) && type.IsNotAbstractClass(true));
        if (implType is null)
            throw new NotImplementedException(nameof(IEntityInfo));
        else
            Services.AddScoped(serviceType, implType);

        AddEfCoreContext();
    }

    /// <summary>
    /// 注册EFCoreContext
    /// </summary>
    protected virtual void AddEfCoreContext()
    {
        var mysqlConfig = MysqlSection.Get<MysqlOptions>();
        var serverVersion = new MariaDbServerVersion(new Version(8, 5, 4));
        Services.AddZyEfCoreMySql(options =>
        {
            options.UseMySql(mysqlConfig.ConnectionString, serverVersion, optionsBuilder =>
            {
                optionsBuilder.MinBatchSize(4)
                                        .MigrationsAssembly(ServiceInfo.StartAssembly.GetName().Name.Replace("WebApi", "Repository"))
                                        .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });

            if (this.IsDevelopment())
            {
                //options.AddInterceptors(new DefaultDbCommandInterceptor())
                options.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                            .EnableSensitiveDataLogging()
                            .EnableDetailedErrors();
            }
        });
    }

}