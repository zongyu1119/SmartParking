using System.Reflection;
using zy.webcore.Share.Constraint.Core.Interfaces;
using zy.webcore.Usr.Application.Register;
using zy.webcore.Share.WebApi.Register;
using zy.webcore.Share.Extensions;
using zy.webcore.Share.Application.Registrar;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace zy.webcore.Usr.WebApi.Register
{
    public static class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder ConfigureService(this WebApplicationBuilder builder,IServiceInfo serviceInfo)
        {
            builder.AddZyWebApi(serviceInfo);
            builder.Services.AddZyWebCoreDefault();
            return builder;
        }
    }
}
