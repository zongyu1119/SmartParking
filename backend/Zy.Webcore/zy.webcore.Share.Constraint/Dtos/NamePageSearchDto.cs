using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Constraint.Dtos
{
    /// <summary>
    /// 名称分页查询参数
    /// </summary>
    public class NamePageSearchDto:BasePageSearchDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }
    }
}
