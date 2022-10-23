using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Infra
{
    public sealed class InfraHelper
    {
        public static ISecurity Security => new Security();

        public static IHashGenerater Hash => new HashGenerater();

        public static IAccessor Accessor => new Accessor();

        private InfraHelper()
        {
        }

        static InfraHelper()
        {
        }
    }
}
