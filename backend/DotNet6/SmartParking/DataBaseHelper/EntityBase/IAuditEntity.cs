
namespace DataBaseHelper.EntityBase
{
    public interface IAuditEntity:IDeptEntity
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public long? CreatedBy { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public long? UpdatedBy { get; set; }
    }
}
