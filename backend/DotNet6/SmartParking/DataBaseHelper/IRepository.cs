using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Comm
///  Name： IRepository
///  Author: zy
///  Time:  2022-04-02 23:21:56
///  Version:  0.1
/// </summary>

namespace DataBaseHelper
{
    /// <summary>
    /// 存储库
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// 数据操作对象
        /// </summary>
        Entities.smartparkingContext DbContext { get; }
    }
}
