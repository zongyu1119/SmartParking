using Microsoft.Extensions.DependencyInjection;
namespace Common.Service
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AppServiceAttribute:Attribute
    {
        public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;
    }
}
