using Serilog;

namespace SmartParking.Registrar
{
    /// <summary>
    /// 基础中间件扩展类
    /// </summary>
    public static class BaseWebApplicationExtension
    {
        /// <summary>
        /// 基础中间件
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication UseBaseWebApplication(this WebApplication app)
        {
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

            app.UseCors("Cors");//策略名称，这里写啥，控制器就要写啥

            app.UseHttpsRedirection();

            //用户认证
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseSerilogRequestLogging();
            app.MapControllers();
            return app;
        }
    }
}
