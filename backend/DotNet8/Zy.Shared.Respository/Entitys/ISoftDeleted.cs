using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zy.Shared.Entitys
{
    public interface ISoftDeleted
    {
        [Column("is_deleted")]
        [Comment("是否已删除")]
        public bool IsDeleted { get; set; }
    }
}
