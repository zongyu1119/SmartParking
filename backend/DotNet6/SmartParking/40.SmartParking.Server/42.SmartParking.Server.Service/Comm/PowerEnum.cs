namespace SmartParking.Server.Service.Comm
{
    /// <summary>
    /// 权限ID对应关系
    /// </summary>
    public static class PowerID
    {
        /// <summary>
        /// 工作台
        /// </summary>
        public const string Workbench = "101";
        /// <summary>
        /// 停车场监控
        /// </summary>
        public const string ParkingMonitor = "102";
        /// <summary>
        /// 停车场管理
        /// </summary>
        public const string ParkingManagement = "201";
        /// <summary>
        /// 报表
        /// </summary>
        public const string ParkingReport = "301";
        /// <summary>
        /// 用户管理
        /// </summary>
        public const string UserInfoManagement = "401";
        /// <summary>
        /// 角色权限管理
        /// </summary>
        public const string RoleInfoManagement = "402";
        /// <summary>
        /// 系统配置管理
        /// </summary>
        public const string ConfigManagement = "501";
        /// <summary>
        /// 租户管理
        /// </summary>
        public const string TenantManagement = "502";

    }
    /// <summary>
    /// 权限操作类型
    /// </summary>
    public static class PowerType
    {
        /// <summary>
        /// 查询
        /// </summary>
    public const string Select = "Select";
        /// <summary>
        /// 新增
        /// </summary>
        public const string Insert = "Insert";
        /// <summary>
        /// 修改
        /// </summary>
        public const string Update = "Update";
        /// <summary>
        /// 删除
        /// </summary>
        public const string Delete = "Delete";
    }
}