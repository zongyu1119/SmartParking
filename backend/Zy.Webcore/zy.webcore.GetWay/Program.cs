using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Nacos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
          builder =>
          {
              builder.AllowAnyMethod()
                  .SetIsOriginAllowed(_ => true)
                  .AllowAnyHeader()
                  .AllowCredentials();
          }));
// 添加Ocelot对应Nacos扩展
builder.Services.AddOcelot().AddNacosDiscovery();
//builder.Services.AddNacosAspNet(builder.Configuration); //默认节点Nacos
// 添加配置中心
builder.Host.ConfigureAppConfiguration((context, builder) =>
{
    var config = builder.Build();
    builder.AddNacosV2Configuration(config.GetSection("NacosConfig"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseAuthorization();
app.Use(async (context, next) =>
{
    Console.WriteLine(context.Request.Path);   
    await next.Invoke();
});
app.UseOcelot().Wait();
app.MapControllers();
app.Run();
