using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Constraint.Dtos.SearchDtos
{
    /// <summary>
    /// 名称分页查询参数
    /// </summary>
    public class NameCodePageSearchDto : BasePageSearchDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string? Code { get; set; }
    }
}
