using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace Zy.Shared.Entitys
{
    /// <summary>
    /// 符合审计的实体
    /// </summary>
    public interface IAuditEntity:IEntity
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public long? CreateBy { get; set; }
        public long? ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
    /// <summary>
    /// 符合审计的实体
    /// </summary>
    public class AuditEntity:Entity
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        [Comment("创建时间")]
        public DateTime CreateTime { get; set; }
        [Column("create_by")]
        [Comment("创建人")]
        public long? CreateBy { get; set; }
        [Column("modify_by")]
        [Comment("修改人")]
        public long? ModifyBy { get; set; }
        [Column("modify_time")]
        [Comment("修改时间")]
        public DateTime? ModifyTime { get; set; }
    }
}
