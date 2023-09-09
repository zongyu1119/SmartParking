using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Redis.Options
{
    /// <summary>
    /// Redis配置
    /// </summary>
    public class RedisSection
    {
        /// <summary>
        /// 数据库配置
        /// </summary>
        public DBOptions Dbconfig { get; set; }
    }
}
