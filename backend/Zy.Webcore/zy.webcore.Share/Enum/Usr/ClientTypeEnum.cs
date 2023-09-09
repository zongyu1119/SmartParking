using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Enum.Usr
{
    /// <summary>
    /// 登录客户端类型
    /// </summary>
    public enum ClientTypeEnum
    {
        /// <summary>
        /// PC
        /// </summary>
        [Description("PC")]
        PC=0,
        /// <summary>
        /// 移动APP
        /// </summary>
        [Description("MobileAPP")]
        MobileAPP = 1,
        /// <summary>
        /// 微信小程序
        /// </summary>
        [Description("WeChat")]
        WeChat =2,
        /// <summary>
        /// 移动端网页
        /// </summary>
        [Description("MobileWeb")]
        MobileWeb =3,
    }
}
