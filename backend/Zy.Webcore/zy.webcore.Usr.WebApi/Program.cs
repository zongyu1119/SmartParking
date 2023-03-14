global using zy.webcore.Usr.WebApi.Register;
using zy.webcore.Share.WebApi;

var webApiAssembly = System.Reflection.Assembly.GetExecutingAssembly();
var serviceInfo = ServiceInfo.CreateInstance(webApiAssembly);
var builder = WebApplication.CreateBuilder(args)
    .ConfigureService(serviceInfo);


await builder.Build()
    .UseZyMiddleware()
    .ChangeThreadPoolSettings()
    .RunAsync();

