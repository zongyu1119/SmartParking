// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mysqlx.Crud;
using ShardingCore;
using ShardingCore.Extensions;
using Microsoft.Extensions.Configuration;
using Zy.Shared.Constraint;
using Zy.Shared.Repository.Contexts;
using Zy.User.Repository.Entitys;
using Zy.User.Repository.Registers;
using Microsoft.Extensions.Hosting;
using Google.Protobuf.WellKnownTypes;
using Zy.Shared.ServicesLocator;
using Zy.Shared.Constraint.Dtos;

Console.WriteLine("Hello, World!");
var webApiAssembly = System.Reflection.Assembly.GetExecutingAssembly();
var serviceInfo = ServiceInfo.CreateInstance(webApiAssembly);
var services=new ServiceCollection();
services.AddSingleton(serviceInfo);
//加载配置文件
ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

//添加配置文件路径
configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json");

var configuration = configurationBuilder.Build();
// Add services to the container.

services.AddSingleton(typeof(ZyUserContext), new ZyUserContext
{
    Id = 0
});
services.AddDbcontextServices(serviceInfo, configuration);
var serviceProvider = services.BuildServiceProvider();
ServiceLocator.Instance = serviceProvider;


// var dbContextOptionsBuilder = new DbContextOptionsBuilder<ZyShardingCoreContext>();
// dbContextOptionsBuilder.UseDefaultSharding<ZyShardingCoreContext>(ShardingProvider.ShardingRuntimeContext);
var dbcontext = (ZyShardingCoreDbContext)serviceProvider.GetService(typeof(ZyShardingCoreDbContext));

{
    var transation=dbcontext.Database.BeginTransaction();
    dbcontext.Add(new SysUser()
    {
        Id = 1001,
        Account = "",
        CreateBy = 0,
        Name = "",
        Address = "",
        ConnectionId = "",
        DataScope = 0,
        Email = "",
        Password = "password",
        IsOnline = false,
        Phone = "",
        Photo = "",
        Sex = "",
        UserIdCard = ""
    });
    await dbcontext.SaveChangesAsync();
    dbcontext.Add(new SysUser()
    {
        Id = 1003,
        Account = "",
        CreateBy = 0,
        Name = "",
        Address = "",
        ConnectionId = "",
        DataScope = 0,
        Email = "",
        Password = "password",
        IsOnline = false,
        Phone = "",
        Photo = "",
        Sex = "",
        UserIdCard = ""
    });
    await dbcontext.SaveChangesAsync();
    transation.Commit();
}

Console.WriteLine("Hello, World!");