using Serilog;

namespace SmartParking.Registrar
{
    public static class BaseWebApplicationExtension
    {
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
