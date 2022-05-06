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
using RedisHelper;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//�򵥵������ļ���ȡ��
builder.Services.AddSingleton(new AppHelper.AppSettings(configuration));
//redis����
builder.Services.AddSingleton<IRedisManage,RedisManage>();
//Swagger
builder.Services.AddSwaggerGen(swgger =>
{
    swgger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SmartParking API",
        Description = "����ͣ����ϵͳAPI",
        Contact = new OpenApiContact
        {
            Name = "ZY",
            Email = "wuguoqiang0927@hotmail.com"
        }
    });
    //��Ӱ�ȫ����
    swgger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "������token,��ʽΪ Bearer xxxxxxxx��ע���м�����пո�",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    //��Ӱ�ȫҪ��
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
    // Ϊ Swagger JSON and UI����xml�ĵ�ע��·��
    var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//��ȡӦ�ó�������Ŀ¼�����ԣ����ܹ���Ŀ¼Ӱ�죬������ô˷�����ȡ·����
    var xmlPath = Path.Combine(basePath, "SmartParking.xml");
    swgger.IncludeXmlComments(xmlPath);
});

// �����Ǽ�����JWT�����֤
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
/// ע��NewtonsoftJson
/// </summary>
builder.Services.AddMvc().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";
});
/// <summary>
/// AutoMapper����
/// </summary>
// builder.Services.AddAutoMapper(typeof(Service.Comm.AutoMapperConfig));//�����web���������
 builder.Services.AddAutoMapper(Assembly.Load("Service"));//Service��������������Զ�Ѱ��

//��AudienceValidator��ӵ�DI
//builder.Services.AddScoped<SmartParking.Common.AuditFilterAttribute>();

// ������autofac����ע��
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24);
    options.Cookie.HttpOnly = false;
    //options.Cookie.IsEssential = true;
});

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    //������
    builder.RegisterType<Service.Comm.ServiceInterceptor>();
    //������
    builder.RegisterType<SmartParking.Common.AuditFilterAttribute>();
    //ע��JWT
    builder.RegisterType<AuthorizeJWT>().As<IAuthorizeJWT>();
    //ע�����ݿ���Դ
    builder.RegisterType<Repository>().As<IRepository>();
     // ע��Service����
     Assembly assembly = Assembly.Load(ServiceAutofac.GetAssemblyName());
    builder.RegisterAssemblyTypes(assembly)
    .AsImplementedInterfaces()
    .InstancePerDependency()
    .EnableInterfaceInterceptors();//������
});
// ��־
builder.Host.UseSerilog((context, logger) =>
{
    logger.ReadFrom.Configuration(context.Configuration);
    logger.Enrich.FromLogContext();
});
//��������ڵ���ʱ�ǲ��������õģ�ʵ�ʲ���������
builder.WebHost.UseUrls(new[] { configuration["Url"].ToString() });

builder.Services.AddCors(cor =>
{
    cor.AddPolicy("Cors", policy =>
    {
        policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        c.DefaultModelsExpandDepth(2);
    });
}

app.UseSession();//Session

app.UseCors("Cors");//�������ƣ�����дɶ����������Ҫдɶ

app.UseHttpsRedirection();

//�û���֤
app.UseAuthentication();

app.UseAuthorization();
app.UseSerilogRequestLogging();
app.MapControllers();
app.Logger.LogInformation($"Smart Parking WebApi Start!");
app.Run();