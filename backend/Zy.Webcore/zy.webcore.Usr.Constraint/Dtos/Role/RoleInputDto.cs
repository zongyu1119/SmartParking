using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Usr.Constraint.Dtos.Role
{
    public class RoleInputDto: InputDto
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [MaxLength(32, ErrorMessage = "角色名称不能大于32位！")]
        public string RoleName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(256, ErrorMessage = "备注不能大于256位!")]
        public string? Remark { get; set; }
    }
}
