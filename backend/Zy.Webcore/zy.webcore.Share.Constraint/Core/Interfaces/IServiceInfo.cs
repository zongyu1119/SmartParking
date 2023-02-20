using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Constraint.Core.Interfaces
{
    public interface IServiceInfo
    {
        /// <summary>
        /// zy-xxx-webapi-188933
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// zy-xxx-webapi
        /// </summary>
        public string ServiceName { get; }

        /// <summary>
        /// corsPolicy
        /// </summary>
        public string CorsPolicy { get; set; }

        /// <summary>
        ///  usr or maint or cus or xxx
        /// </summary>
        public string ShortName { get; }

        /// <summary>
        /// 0.9.2.xx
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// assembly  of start's project
        /// </summary>
        public Assembly StartAssembly { get; }
    }
}
