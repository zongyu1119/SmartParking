using Zy.Shared.Constraint;
using Zy.Message.WebApi.Registers;

Environment.SetEnvironmentVariable("ASPNETCORE_HOSTINGSTARTUPASSEMBLIES", "SkyAPM.Agent.AspNetCore");
Environment.SetEnvironmentVariable("SKYWALKING__SERVICENAME", "message");
var builder = WebApplication.CreateBuilder(args);
var webApiAssembly = System.Reflection.Assembly.GetExecutingAssembly();
var serviceInfo = ServiceInfo.CreateInstance(webApiAssembly);
var app = builder.ZyBuild(serviceInfo).Build();

app.UseZyApp(serviceInfo);
await app.RunAsync();
