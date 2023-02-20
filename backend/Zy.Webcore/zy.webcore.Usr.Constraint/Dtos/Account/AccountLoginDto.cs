using System.ComponentModel.DataAnnotations;

namespace zy.webcore.Usr.Constraint.Dtos.Account
{
    /// <summary>
    /// 登录
    /// </summary>
    public class AccountLoginDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage ="用户名不可为空！")]
        public string UserAccount { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage ="密码不可为空！")]
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage ="验证码不能为空！")]
        public string VerificationCode { get; set; }
    }
}