using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Repository.EntitiesBase;

namespace zy.webcore.Usr.Repository.Entities
{
    /// <summary>
    /// 职务表
    /// </summary>
    [Table("sys_job")]
    [Comment("职务表")]
    public class SysJob: FullAuditSoftDeleteInfo
    {
        /// <summary>
        /// 职务ID
        /// </summary>
        [Column("job_id")]
        [Comment("职务ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//不自动增长
        public override long Id { get => base.Id; set => base.Id = value; }
        /// <summary>
        /// 职务名称
        /// </summary>
        [MaxLength(32, ErrorMessage = "职务名称不能大于32位！")]
        [Column("job_name")]
        [Comment("职务名称")]
        public string JobName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Comment("备注")]
        [Column("remark")]
        [MaxLength(256, ErrorMessage = "备注不能大于256位!")]
        public string? Remark { get; set; }
    }
}
