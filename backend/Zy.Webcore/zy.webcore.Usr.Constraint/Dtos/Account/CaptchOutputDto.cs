using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Usr.Constraint.Dtos.Account
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class CaptchOutputDto
    {
        /// <summary>
        /// 验证码ID
        /// </summary>
        public long CaptchId { get; set; }
        /// <summary>
        /// 验证码Base64
        /// </summary>
        public string CaptchBase64Str { get; set; }
    }
}
