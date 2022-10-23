using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Infra
{
    /// <summary>
    /// 操作基础
    /// </summary>
    public class Operater
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 租户ID
        /// </summary>

        public long TenantId { get;set; }
        /// <summary>
        /// 账号
        /// </summary>

        public string Account { get; set; }
        /// <summary>
        /// 名称
        /// </summary>

        public string Name { get; set; }
    }
}
