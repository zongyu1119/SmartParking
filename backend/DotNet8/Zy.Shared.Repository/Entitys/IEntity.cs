using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zy.Shared.Entitys
{
    /// <summary>
    /// 实体接口
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// ID 
        /// </summary>
        public long Id { get; set; }
    }
    /// <summary>
    /// 实体类基类
    /// </summary>
    public class Entity:IEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Required]
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//不自动增长
        public long Id { get; set; }       
    }
}
