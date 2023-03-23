using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Nacos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ���Ocelot��ӦNacos��չ
builder.Services.AddOcelot().AddNacosDiscovery();
//builder.Services.AddNacosAspNet(builder.Configuration); //Ĭ�Ͻڵ�Nacos
// �����������
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

app.UseAuthorization();
app.Use(async (context, next) =>
{
    Console.WriteLine(context.Request.Path);
    await next.Invoke();
});
app.UseOcelot().Wait();
app.MapControllers();

app.Run();
