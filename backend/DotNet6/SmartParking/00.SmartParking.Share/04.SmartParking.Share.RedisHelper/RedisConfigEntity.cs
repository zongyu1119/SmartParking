using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: RedisHelper
///  Name： RedisConfigEntity
///  Author: zy
///  Time:  2022-04-19 22:37:16
///  Version:  0.1
/// </summary>

namespace SmartParking.Share.RedisHelper
{
    /// <summary>
    /// Redis配置实体
    /// </summary>
    public class RedisConfigEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ip地址
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 超时时间
        /// </summary>
        public int Timeout { get; set; }
        /// <summary>
        /// 数据库
        /// </summary>
        public int Db { get; set; }
    }
}
