using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Enum.Usr;

namespace zy.webcore.Share.ZyEfcore
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserContext
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 扩展ID
        /// </summary>
        public long ExationId { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; } = string.Empty;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; } = string.Empty;
        /// <summary>
        /// 角色ID
        /// </summary>
        public List<long> RoleIds { get; set; }
        /// <summary>
        /// 设备
        /// </summary>
        public string Device { get; set; } = string.Empty;
        /// <summary>
        /// 远程IP地址
        /// </summary>
        public string RemoteIpAddress { get; set; } = string.Empty;
        /// <summary>
        /// 部门ID
        /// </summary>
        public long DeptId { get; set; }
        /// <summary>
        /// 数据权限
        /// </summary>
        public DataScopeEnum DataScope {get; set; }
        /// <summary>
        /// 客户端类型
        /// </summary>
        public ClientTypeEnum ClientType { get; set; }
    }
}
