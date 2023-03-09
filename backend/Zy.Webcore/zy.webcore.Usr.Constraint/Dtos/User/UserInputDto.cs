using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Constraint.Dtos;

namespace zy.webcore.Usr.Constraint.Dtos.User
{
    /// <summary>
    /// 用户输入对象
    /// </summary>
    public class UserInputDto : InputDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(32, ErrorMessage = "用户账户不能超过32个字！")]
        [Required(ErrorMessage ="用户名不能为空！")]
        public string Account { get; set; } = null!;
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(255, ErrorMessage = "用户密码不能超过255个字！")]
        [Required(ErrorMessage = "密码不能为空！")]
        public string Password { get; set; } = null!;
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [MaxLength(32, ErrorMessage = "用户姓名不能超过32个字！")]
        public string? UserName { get; set; }

        /// <summary>
        /// 用户身份证号
        /// </summary>
        [MaxLength(32, ErrorMessage = "身份证号不能超过32个字！")]
        public string? UserIdCardNum { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        [MaxLength(4, ErrorMessage = "性别不能超过4个字！")]
        public string? Sex { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary
        [MaxLength(32, ErrorMessage = "电话不能超过32个字！")]
        public string? Phone { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        [MaxLength(255, ErrorMessage = "住址不能超过255个字！")]
        public string? Address { get; set; }
        /// <summary>
        /// 数据权限
        /// </summary>
        public DataScopeEnum DataScope { get; set; } = DataScopeEnum.None;
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(128, ErrorMessage = "邮箱不能超过128位！")]
        public string? Email { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(256, ErrorMessage = "备注不能大于256位!")]
        public string? Remark { get; set; }
    }
}
