using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Constraint.Dtos.SearchDtos
{
    /// <summary>
    /// 分页查询参数
    /// </summary>
    public class BasePageSearchDto : BaseSearchDto
    {
        private int _pageIndex = 1;
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get { return _pageIndex; } set { _pageIndex = value == 0 ? 1 : value; } }
        /// <summary>
        /// 每页个数
        /// </summary>
        public int PageSize { get; set; } = 20;
        /// <summary>
        /// 计算查询需要跳过的行数
        /// </summary>
        public int SkipRows { get { return (PageIndex - 1) * PageSize; } }
    }
}
