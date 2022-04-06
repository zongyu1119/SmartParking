using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Service;
using SmartParking.Authorize;
using System.Reflection;
using System.Text;
using Serilog;
using DataBaseHelper;
using Service.Comm;
using DataBaseHelper.Entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Swashbuckle.Swagger;
using Autofac.Extras.DynamicProxy;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton(new AppHelper.AppSettings(configuration));

builder.Services.AddSwaggerGen(swgger =>
{
    swgger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SmartParking API",
        Description = "智能停车场系统API",
        Contact = new OpenApiContact
        {
            Name = "ZY",
            Email = "wuguoqiang0927@hotmail.com"
        }
    });
    //添加安全定义
    swgger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "请输入token,格式为 Bearer xxxxxxxx（注意中间必须有空格）",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    //添加安全要求
    swgger.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme{
                Reference =new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id ="Bearer"
                }
            },new string[]{ }
        }
    });
    // 为 Swagger JSON and UI设置xml文档注释路径
    var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
    var xmlPath = Path.Combine(basePath, "SmartParking.xml");
    swgger.IncludeXmlComments(xmlPath);
});

// 以下是加入了JWT身份认证
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
    };
});

/// <summary>
/// 注入NewtonsoftJson
/// </summary>
builder.Services.AddMvc().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";
});
/// <summary>
/// AutoMapper依赖
/// </summary>
// builder.Services.AddAutoMapper(typeof(Service.Comm.AutoMapperConfig));//如果在web层可以这样
 builder.Services.AddAutoMapper(Assembly.Load("Service"));//Service层可以这样，会自动寻找


// 以下是autofac依赖注入
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{

    //拦截器
    builder.RegisterType<Service.Comm.ServiceInterceptor>();

    //先注入JWT
    builder.RegisterType<AuthorizeJWT>().As<IAuthorizeJWT>();
    //注入数据库资源
    builder.RegisterType<Repository>().As<IRepository>();
     // 注入Service程序集
     Assembly assembly = Assembly.Load(ServiceAutofac.GetAssemblyName());
    builder.RegisterAssemblyTypes(assembly)
    .AsImplementedInterfaces()
    .InstancePerDependency()
    .EnableInterfaceInterceptors();//拦截器
});
// 使用日志
builder.Host.UseSerilog((context, logger) =>
{
    logger.ReadFrom.Configuration(context.Configuration);
    logger.Enrich.FromLogContext();
});
//这个配置在调试时是不发挥作用的，实际部署后可以用
builder.WebHost.UseUrls(new[] { configuration["Url"].ToString() });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowCors");

app.UseHttpsRedirection();

//用户认证
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

Console.WriteLine($"Smart Parking WebApi Start!");

app.Run();