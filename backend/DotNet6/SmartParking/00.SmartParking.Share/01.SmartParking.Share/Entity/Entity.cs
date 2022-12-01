using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Entity
{
    public interface IEntity
    {
        public long Id { get; set; }
    }
    public class Entity : IEntity,ITenant
    {
        [Key]
        [Column("ID")]
        [Comment("ID")]
        public long Id { get; set; }
        /// <summary>
        /// 租户号
        /// </summary>
        [Column("TENANT_ID")]
        [Comment("租户号")]
        public long TenantId { get; set; }
    }
}
