using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShardingCore;
using Zy.Shared.Constraint;
using Zy.Shared.ServicesLocator;

namespace Zy.Shared.WebApi.Register
{
    public static class UseZyWebApplication
    {
        /// <summary>
        /// Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication UseZySwagger(this WebApplication app,ServiceInfo serviceInfo)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(options =>
                {
                    options.RouteTemplate = serviceInfo.ShortName+"/swagger/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(options =>
                {
                    options.RoutePrefix = $"{serviceInfo.ShortName}/swagger";
                });
            }
            return app;
        }
        /// <summary>
        /// 健康检查
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication UseZyHealthCheck(this WebApplication app, ServiceInfo serviceInfo)
        {
            app.MapGet("/health", () => $"Hello,This is Zy {serviceInfo.ShortName}!Env:{app.Environment.EnvironmentName}");
            return app;
        }
        /// <summary>
        /// 路由和控制器基础
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication UseZyWebBase(this WebApplication app)
        {
            ServiceLocator.Instance = app.Services;
            app.UseHttpsRedirection();
            app.MapControllers();
            app.UseRouting();
            app.UseShardingCoreDbcontext();
            return app;
        }
        /// <summary>
        /// ShardingCore自动创建缺失的表
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseShardingCoreDbcontext(this IApplicationBuilder app)
        {
            //not required, enable check table missing and auto create,非必须  启动检查缺少的表并且创建
            // app.ApplicationServices.UseAutoTryCompensateTable();
            return app;
          }
        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication UseZyAuth(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
        /// <summary>
        /// Use Cors
        /// </summary>
        /// <param name="app"></param>
        /// <param name="serviceInfo"></param>
        /// <returns></returns>
        public static WebApplication UseZyCors(this WebApplication app, ServiceInfo serviceInfo)
        {
            app.UseCors(serviceInfo.CorsPolicy);
            return app;
        }

        /// <summary>
        /// 服务管道
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication UseZyService(this WebApplication app, ServiceInfo serviceInfo)
        {
            //app.Map(serviceInfo.PathStart, appCurrent =>
            //{
            //    appCurrent.Use(async (context, next) =>
            //    {
            //        Console.WriteLine(context.Request.Path);
            //        await next.Invoke();
            //    });
            //});
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsJsonAsync(new ZyResult(System.Net.HttpStatusCode.BadRequest, "Request Path Is Wrong."));
            //});
            return app;
        }

        /// <summary>
        /// 记录请求日志
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication UseZyRequestLog(this WebApplication app)
        {

            app.Use(async (context, next) =>
            {
                app.Logger.LogInformation($"Path:{context.Request.Path};User:{context.User.Claims.FirstOrDefault(x => x.Type == "Account")?.Value}");
                await next.Invoke();
            });

            return app;
        }
    }
}
