using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: RedisHelper
///  Name： IRedisManage
///  Author: zy
///  Time:  2022-04-19 22:02:50
///  Version:  0.1
/// </summary>

namespace RedisHelper
{
    /// <summary>
    /// Redis管理
    /// </summary>
    public  interface IRedisManage
    {
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string Get(string key);
        /// <summary>
        /// 删除值
        /// </summary>
        /// <param name="key"></param>
        public bool Delete(string key);
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts">超时时间</param>
        /// <returns>返回值</returns>
        public bool Set(string key, object value,TimeSpan ts);
    }
}
