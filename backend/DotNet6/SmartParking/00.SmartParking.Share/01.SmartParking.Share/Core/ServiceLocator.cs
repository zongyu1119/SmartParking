using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Core
{
    public sealed class ServiceLocator
    {
        public static IServiceProvider? Provider { get; set; }

        private ServiceLocator()
        {
        }

        static ServiceLocator()
        {
        }
    }
}
