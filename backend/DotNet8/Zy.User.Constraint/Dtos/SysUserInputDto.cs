using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.User.Constraint.Dtos
{
    /// <summary>
    /// 用户表输入
    /// </summary>
    [Serializable]
    public class SysUserInputDto
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "姓名不能为空")]
        [MaxLength(90)]
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "账号不能为空")]
        [MaxLength(90)]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [MaxLength(255)]
        public string Password { get; set; }

        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnline { get; set; } = false;

        /// <summary>
        /// 连接ID
        /// </summary>
        [MaxLength(255)]
        public string ConnectionId { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        [MaxLength(255)]
        public string Address { get; set; }

        /// <summary>
        /// 数据权限
        /// </summary>
        public DataScopeEnum DataScope { get; set; } = DataScopeEnum.None;

        /// <summary>
        /// 身份证号
        /// </summary>
        [MaxLength(90)]
        public string UserIdCard { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(90)]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(90)]
        public string Email { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        [MaxLength(255)]
        public string Photo { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [MaxLength(90)]
        public string Sex { get; set; }
    }
}
