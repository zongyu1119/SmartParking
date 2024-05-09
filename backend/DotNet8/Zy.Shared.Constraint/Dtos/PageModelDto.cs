using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.Shared.Constraint.Dtos
{
    /// <summary>
    /// 分页DTO
    /// </summary>
    public class PageModelDto<T>
    {
        public PageModelDto(){
            }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchPageDto"></param>
        /// <param name="datas"></param>
        /// <param name="totalCount"></param>
        public PageModelDto(SearchPageDto searchPageDto,List<T> datas,int totalCount)
        {
            TotalCount = totalCount;
            PageSize = searchPageDto.PageSize;
            PageIndex = searchPageDto.PageIndex;
            Rows = datas;
        }
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount { get; set; } = 0;
        /// <summary>
        /// 每页个数
        /// </summary>
        public int PageSize { get; set; } = 15;
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages =>(int)Math.Ceiling( (decimal)TotalCount/(decimal)PageSize);
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 数据
        /// </summary>
        public List<T>? Rows { get; set; }
    }
}
