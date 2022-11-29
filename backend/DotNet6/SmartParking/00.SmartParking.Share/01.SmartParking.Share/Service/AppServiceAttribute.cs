using Microsoft.Extensions.DependencyInjection;
namespace SmartParking.Share.Service
{
    /// <summary>
    /// Service层的注解
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AppServiceAttribute:Attribute
    {
        public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;
    }
}
