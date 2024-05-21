using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zy.Shared.Entitys
{
    /// <summary>
    /// 全功能实体
    /// </summary>
    public class FullEntity:AuditEntity,ISoftDeleted
    {
        [Column("is_deleted")]
        [Comment("是否已删除")]
        public bool IsDeleted { get; set; } = false;
    }
}
