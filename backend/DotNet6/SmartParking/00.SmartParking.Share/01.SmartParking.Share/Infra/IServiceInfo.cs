using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Infra
{
    public interface IServiceInfo
    {
        string Id { get; }

        string ServiceName { get; }

        string CorsPolicy { get; set; }

        string ShortName { get; }

        string Version { get; }

        string Description { get; }

        Assembly StartAssembly { get; }
    }
}
