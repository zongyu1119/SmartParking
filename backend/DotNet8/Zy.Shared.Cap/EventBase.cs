using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.Shared.Cap
{
    /// <summary>
    /// 事件基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class EventBase<T>(long id)
    {
        /// <summary>
        /// 事件ID
        /// </summary>
        [Required(ErrorMessage ="事件ID不可为空！")]
        public long Id { get; set; } = id;
        /// <summary>
        /// 数据
        /// </summary>
        public abstract T? Data { get; set; }
    }
}
