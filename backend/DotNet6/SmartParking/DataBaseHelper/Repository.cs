using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Comm
///  Name： Repository
///  Author: zy
///  Time:  2022-04-02 23:24:00
///  Version:  0.1
/// </summary>

namespace DataBaseHelper
{
    /// <summary>
    /// 资源库
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository :IRepository
    {
        public Repository()
        {
            dbContext = new Entities.smartparkingContext();
        }
        private Entities.smartparkingContext dbContext;
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public Entities.smartparkingContext DbContext
        {
            get
            {
                return dbContext;
            } 
        }
    }
}
