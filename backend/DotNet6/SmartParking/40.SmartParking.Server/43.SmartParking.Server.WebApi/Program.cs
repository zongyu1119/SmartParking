using SmartParking.Registrar;

var builder = WebApplication
    .CreateBuilder(args)
    .BaseRegistrarBuilder()
    .SwaggerRegistrarBuilder()
    .AuthenticationRegistrarBuilder();
var app = builder.Build();
app.UseBaseWebApplication();
app.Logger.LogInformation($"Smart Parking WebApi Start!");
await app.RunAsync();