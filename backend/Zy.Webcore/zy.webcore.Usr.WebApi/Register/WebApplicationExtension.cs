using System.Runtime.CompilerServices;

namespace zy.webcore.Usr.WebApi.Register
{
    public static class WebApplicationExtension
    {
        public static WebApplication UseZyMiddleware(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors("CorsPolicy");
            app.UseRouting();
            return app;
        }
    }
}
