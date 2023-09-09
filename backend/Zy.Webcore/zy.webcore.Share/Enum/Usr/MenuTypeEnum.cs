using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Enum.Usr
{
    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuTypeEnum
    {
        /// <summary>
        /// 目录
        /// </summary>
        [Description("目录")]
        Directory=0,
        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        Menu=1,
        /// <summary>
        /// 按钮
        /// </summary>
        [Description("按钮")]
        Button=2
    }
}
