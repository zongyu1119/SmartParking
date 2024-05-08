using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Nacos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments("doc.xml", true);
});
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
          builder =>
          {
              builder.AllowAnyMethod()
                  .SetIsOriginAllowed(_ => true)
                  .AllowAnyHeader()
                  .AllowCredentials();
          }));
// 添加Ocelot对应Nacos扩展
builder.Services.AddOcelot().AddNacosDiscovery("NacosConfig");
// 添加配置中心
builder.Configuration.AddNacosV2Configuration(builder.Configuration.GetSection("NacosConfig"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();
await app.UseOcelot();
app.MapControllers();

app.Run();
