using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Redis.Constraint
{
    /// <summary>
    /// 可被ProtoBuf序列化的对象，可缓存的
    /// </summary>
    [ProtoContract]
    public interface ICacheAble
    {
    }
}
