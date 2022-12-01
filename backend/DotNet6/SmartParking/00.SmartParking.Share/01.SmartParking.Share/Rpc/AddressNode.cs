using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Rpc
{
    public class AddressNode
    {
        public string Service { get; set; } = string.Empty;
        public string Direct { get; set; } = string.Empty;
        public string Consul { get; set; } = string.Empty;
        public string CoreDns { get; set; } = string.Empty;
    }

}
