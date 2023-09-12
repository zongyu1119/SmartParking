using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Repository.EntitiesBase
{
    public interface IFullAuditInfo:IBasicAuditInfo
    {
        /// <summary>
        /// 最后更新人
        /// </summary>
        public long? ModifyBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }
    }
    public class FullAuditInfo:BasicAuditInfo, IFullAuditInfo
    {
        /// <summary>
        /// 最后更新人
        /// </summary>
        [Column("modify_by")]
        [Comment("修改人")]
        public long? ModifyBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Column("modify_time")]
        [Comment("修改时间")]
        public DateTime? ModifyTime { get; set; }
    }
    /// <summary>
    /// 软删除
    /// </summary>
    public class FullAuditSoftDeleteInfo : FullAuditInfo, ISoftDelete
    {
        /// <summary>
        /// 是否已删除
        /// </summary>
        [Column("is_delete")]
        [Comment("是否已删除")]
        public bool IsDeleted { get; set; } = false;
    }
}
