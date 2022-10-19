using Microsoft.OpenApi.Models;

namespace SmartParking.Registrar
{
    /// <summary>
    /// Swagger注册扩展
    /// </summary>
    public static class SwaggerRegistrarBuilderExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplicationBuilder SwaggerRegistrarBuilder(this WebApplicationBuilder builder)
        {
            //Swagger
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
            return builder;
        }
    }
}
