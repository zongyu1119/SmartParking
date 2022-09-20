
namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 车主/车位业主信息表
    /// </summary>
    public partial class BcOwnerInfo : Entity
    {
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? Revision { get; set; }
        /// <summary>
        /// 车主/业主ID
        /// </summary>
        public int OwnerId { get; set; }
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
        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreatedBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public int? UpdatedBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }
    }
}
