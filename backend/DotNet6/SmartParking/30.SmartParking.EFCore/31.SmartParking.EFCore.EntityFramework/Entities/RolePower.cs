

namespace SmartParking.EFCore.EntityFramework.Entities
{
    /// <summary>
    /// 角色权限中间表
    /// </summary>
    public partial class RolePower : ParkingEntityBase
    {       
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public int PowerId { get; set; }
        /// <summary>
        /// 是否允许查询(1:允许;0:不允许)
        /// </summary>
        public int? IsSelect { get; set; }
        /// <summary>
        /// 是否允许新增(1:允许;0:不允许)
        /// </summary>
        public int? IsInsert { get; set; }
        /// <summary>
        /// 是否允许修改(1:允许;0:不允许)
        /// </summary>
        public int? IsUpdate { get; set; }
        /// <summary>
        /// 是否允许删除(1:允许;0:不允许)
        /// </summary>
        public int? IsDelete { get; set; }
       
    }
}
