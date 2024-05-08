using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.User.Respository.Entitys
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Comment("测试表")]
    [Table("sys_test")]
    public class ShardingCoreTestEntity : FullEntity
    {
        /// <summary>
        /// 测试名称
        /// </summary>
        [Column("name")]
        [Comment("测试名称")]
        [Required(ErrorMessage = "测试名称不可为空！")]
        [MaxLength(90, ErrorMessage = "测试名称最大不能超过90")]
        public string Name { get; set; }
    }
}
