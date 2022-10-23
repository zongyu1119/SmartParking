

namespace SmartParking.EFCore.EntityFramework.Entities
{
    /// <summary>
    /// 租户表
    /// </summary>
    public partial class Tenant : ParkingEntityBase
    {      
        /// <summary>
        /// 租户名称
        /// </summary>
        public string? TenantName { get; set; }
    }
}
