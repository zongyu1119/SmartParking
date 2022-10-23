using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.Const.Dtos.DtoBase
{
    /// <summary>
    /// 输出对象接口
    /// </summary>
    public interface IOutputDto
    {
        /// <summary>
        /// ID
        /// </summary>
        long Id { get; set; }
    }
    /// <summary>
    /// 输出对象父类
    /// </summary>
    public class OutputDto : IOutputDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
    }
}
