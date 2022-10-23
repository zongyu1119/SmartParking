using Microsoft.Extensions.DependencyInjection;
namespace SmartParking.Share.Service
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AppServiceAttribute:Attribute
    {
        public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;
    }
}
