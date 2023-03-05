using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Application.Utilitys;
using zy.webcore.Share.Constraint.Core.Interfaces;

namespace zy.webcore.Share.WebApi.Register
{
    public abstract class AbstractWebApiDependencyRegistrar:IMiddlewareRegistrar
    {
        protected readonly WebApplication App;
        protected AbstractWebApiDependencyRegistrar(WebApplication app)
        {
            App = app;
        }

        /// <summary>
        /// 注册中间件入口方法
        /// </summary>
        /// <param name="app"></param>
        public abstract void UseZyWebCore();

        /// <summary>
        /// 注册webapi通用中间件
        /// </summary>
        protected virtual void UseWebApiDefault()
        {
            ServiceLocator.Instance = App.Services;
            var serviceInfo = (IServiceInfo)App.Services.GetService(typeof(IServiceInfo));
            App.UseCors(serviceInfo.CorsPolicy);
            // Configure the HTTP request pipeline.
            if (App.Environment.IsDevelopment())
            {
                App.UseSwagger();
                App.UseSwaggerUI();
            }
            App.UseRealIp(x => x.HeaderKey = "X-Forwarded-For");
           
            App.MapControllers();
            App.UseRouting();
            //用户认证
            App.UseAuthentication();
            App.UseAuthorization();
            App.UseEndpoints(a =>
            {
            });
        }
    }
}
