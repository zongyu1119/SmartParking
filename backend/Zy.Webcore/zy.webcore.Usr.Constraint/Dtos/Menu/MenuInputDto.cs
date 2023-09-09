using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Usr.Constraint.Dtos.Menu
{
    public class MenuInputDto:InputDto
    {
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
        /// 菜单类型
        /// </summary>
        public MenuTypeEnum MenuType { get; set; } = MenuTypeEnum.Directory;
        /// <summary>
        /// 父菜单ID
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
