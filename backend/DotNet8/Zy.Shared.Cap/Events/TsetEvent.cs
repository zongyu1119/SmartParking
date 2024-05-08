using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.Shared.Cap.Events
{
    /// <summary>
    /// 测试事件
    /// </summary>
    public class TestEvent(long id) : EventBase<string>(id)
    {
        public override string? Data { get;set; }
    }
    
}
