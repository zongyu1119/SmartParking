using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Comm
///  Name： ResPage
///  Author: zy
///  Time:  2022-03-31 22:59:21
///  Version:  0.1
/// </summary>

namespace Service.Comm
{
    /// <summary>
    /// 分页返回值
    /// </summary>
    /// <typeparam name="TList"></typeparam>
    public class ResPage<TList>:Res<List<TList>>
    {
        public ResPage(bool _success):base(_success)
        {           
        }
        public ResPage()
        {

        }
        /// <summary>
        /// 每页个数
        /// </summary>
        public int PageSize { get; set; } = 15;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get { return (int)Math.Ceiling(((double)TotalCount / (double)PageSize)); } }
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount { get; set; } = 0;
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageCurrent { get; set; } = 1;
    }
}
