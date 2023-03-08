namespace zy.webcore.Usr.Constraint.Dtos.Menu
{
    /// <summary>
    /// 菜单输出DTO
    /// </summary>
    public class MenuOutputDto:OutputDto
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override long Id { get => base.Id; set => base.Id = value; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        public string MenuCode { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; } = true;
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string MenuPath { get; set; } = null;
        /// <summary>
        /// 是否启用
        /// </summary>
        public MenuTypeEnum MenuType { get; set; } = MenuTypeEnum.Directory;
        /// <summary>
        /// 排序
        /// </summary>
        public long? ParentMenuId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; } = 0;
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}
