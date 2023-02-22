using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.share.Repository.EntitiesBase
{
    public interface IEntity
    {
        public long Id { get; set; }
    }
    public class Entity : IEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//不自动增长
        [Comment("ID")]
        public long Id { get; set; }
    }
}
