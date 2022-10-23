
namespace SmartParking.EFCore.EntityFramework.Entities
{
    /// <summary>
    /// 车主/车位业主信息表
    /// </summary>
    public partial class OwnerInfo : ParkingEntityBase
    {      
        /// <summary>
        /// 车主名
        /// </summary>
        public string OwnerName { get; set; } = null!;
        /// <summary>
        /// 用户身份证号
        /// </summary>
        public string? UserIdCardNum { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string? Sex { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string? Address { get; set; }
    }
}
