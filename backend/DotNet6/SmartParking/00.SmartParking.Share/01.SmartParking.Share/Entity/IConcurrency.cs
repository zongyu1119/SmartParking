using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public interface IConcurrency
    {
       /// <summary>
       /// 并发控制列
       /// </summary>
        byte[] RowVersion { get; set; }
    }
}
