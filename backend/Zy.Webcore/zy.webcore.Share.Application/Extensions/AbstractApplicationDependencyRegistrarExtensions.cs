namespace zy.webcore.Share.Application.Extensions
{
    public static class AbstractApplicationDependencyRegistrarExtensions
    {
        /// <summary>
        /// 环境名称
        /// </summary>
        public static string ASPNETCORE_ENVIRONMENT => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        /// <summary>
        /// 是否开发环境
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public static bool IsDevelopment(this AbstractApplicationDependencyRegistrar _) => ASPNETCORE_ENVIRONMENT.EqualsIgnoreCase("Development");

    }
}
