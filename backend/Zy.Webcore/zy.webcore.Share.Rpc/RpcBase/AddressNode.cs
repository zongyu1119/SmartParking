using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Rpc.RpcBase
{
    public class AddressNode
    {
        /// <summary>
        /// 服务
        /// </summary>
        public string Service { get; set; } = string.Empty;
        public string Direct { get; set; } = string.Empty;
        public string Consul { get; set; } = string.Empty;
        public string CoreDns { get; set; } = string.Empty;
    }
}
