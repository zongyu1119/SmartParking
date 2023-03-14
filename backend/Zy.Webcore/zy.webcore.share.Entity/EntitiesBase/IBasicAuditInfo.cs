using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Repository.EntitiesBase
{
    public interface IBasicAuditInfo:IEntity
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public long CreateBy { get; set; }

        /// <summary>
        /// 创建时间/注册时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
    public class BasicAuditInfo:Entity,IBasicAuditInfo
    {
        /// <summary>
        /// 创建人
        /// </summary>
        [Column("create_by")]
        [Comment("创建人")]
        [Required]
        public long CreateBy { get; set; }

        /// <summary>
        /// 创建时间/注册时间
        /// </summary>
        [Column("create_time")]
        [Comment("创建时间")]
        [Required]
        public DateTime CreateTime { get; set; }
    }
}
