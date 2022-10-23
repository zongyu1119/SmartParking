using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Entity
{
    /// <summary>
    /// 租户
    /// </summary>
    public interface ITenant
    {
        public long TenantId { get; set; }
    }
}
