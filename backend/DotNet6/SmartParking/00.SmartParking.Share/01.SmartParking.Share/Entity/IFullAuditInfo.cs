
namespace SmartParking.Share.Entity
{
    public interface IFullAuditInfo:IBaseAuditInfo
    {
        /// <summary>
        /// 更新人
        /// </summary>
        public long? UpdatedBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }

    }
    public interface IBaseAuditInfo
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public long? CreatedBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedTime { get; set; }
    }
}
