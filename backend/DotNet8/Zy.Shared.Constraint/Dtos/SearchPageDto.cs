using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.Shared.Constraint.Dtos
{
    /// <summary>
    /// 分页查询DTO
    /// </summary>
    public class SearchPageDto
    {
        /// <summary>
        /// 每页个数
        /// </summary>
        public int PageSize { get; set; } = 15;
        /// <summary>
        /// 页码-起始值为1
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 跳过行数
        /// </summary>
        public int SkipRows => PageSize * (PageIndex == 0 ? 0:(PageIndex - 1));
        /// <summary>
        /// 取多少行
        /// </summary>
        public int TakeRows => PageSize;
    }
}
