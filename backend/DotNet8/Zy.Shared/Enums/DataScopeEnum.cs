using System.ComponentModel;

namespace Zy.Shared.Enums
{
    /// <summary>
    /// 数据权限
    /// </summary>
    public enum DataScopeEnum
    {
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        None = 0,
        /// <summary>
        /// 本人
        /// </summary>
        [Description("本人")]
        OneSelf = 1,
        /// <summary>
        /// 部门
        /// </summary>
        [Description("部门")]
        Dept = 2,
        /// <summary>
        /// 公司
        /// </summary>
        [Description("公司")]
        Company = 3,
        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        All = 4,
        /// <summary>
        /// 自定义
        /// </summary>
        [Description("自定义")]
        Custom=5
    }
}
