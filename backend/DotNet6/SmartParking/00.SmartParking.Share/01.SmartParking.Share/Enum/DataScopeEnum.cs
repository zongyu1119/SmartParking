using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Enum
{
    public enum DataScopeEnum
    {
        /// <summary>
        /// 无数据权限 -1
        /// </summary>
        [Description("无")]
        No = -1,
        /// <summary>
        /// 全部数据 0
        /// </summary>
        [Description("全部数据")]
        All = 0,
        /// <summary>
        /// 自定义数据 1
        /// </summary>
        [Description("自定义数据")]
        Custom,
        /// <summary>
        /// 本部门数据 2
        /// </summary>
        [Description("本部门数据")]
        Deprtment,
        /// <summary>
        /// 仅本人数据 3
        /// </summary>
        [Description("仅本人数据")]
        Oneself,
        /// <summary>
        /// 所在公司/单位数据 4
        /// </summary>
        [Description("所在公司数据")]
        Company
    }
}
