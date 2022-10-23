using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: RedisHelper
///  Name： RedisManage
///  Author: zy
///  Time:  2022-04-19 22:03:38
///  Version:  0.1
/// </summary>

namespace SmartParking.Share.RedisHelper
{
    /// <summary>
    /// Redis管理类
    /// </summary>
    public class RedisManage:IRedisManage
    {
        /// <summary>
        /// 连接
        /// </summary>
        private volatile ConnectionMultiplexer connection;
        /// <summary>
        /// 锁
        /// </summary>
        private readonly object redisConnectLock=new object();
        /// <summary>
        /// 配置
        /// </summary>
        private readonly ConfigurationOptions configOptions;
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILogger<RedisManage> logger;
        public RedisManage(ILogger<RedisManage> _logger)
        {
            logger = _logger;
            configOptions = ReadRedisSetting();
            connection = ConnectionRedis();
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        private ConfigurationOptions ReadRedisSetting()
        {
            try
            {
                List<RedisConfigEntity> redisConfigs = AppHelper.AppSettings.ReadAppSettings<RedisConfigEntity>(new string[] { "Redis" });
                if (redisConfigs.Any())
                {
                    ConfigurationOptions options = new ConfigurationOptions
                    {
                        EndPoints =
                            {
                                {
                                    redisConfigs.FirstOrDefault().Ip,
                                    redisConfigs.FirstOrDefault().Port
                                }
                            },
                        ClientName = redisConfigs.FirstOrDefault().Name,
                        Password = redisConfigs.FirstOrDefault().Password,
                        ConnectTimeout = redisConfigs.FirstOrDefault().Timeout,
                        DefaultDatabase = redisConfigs.FirstOrDefault().Db,
                    };
                    return options;
                }
                return null;
            }catch (Exception ex)
            {
                logger.LogError("[Redis]读取Redis配置文件错误！",ex);
                return null;
            }
        }
        /// <summary>
        /// 连接到Redis
        /// </summary>
        /// <returns></returns>
        private ConnectionMultiplexer ConnectionRedis()
        {
            if (this.connection != null && this.connection.IsConnected)
            {
                return this.connection; // 已有连接，直接使用
            }
            lock (redisConnectLock)
            {
                if (this.connection != null)
                {
                    this.connection.Dispose(); // 释放，重连
                }
                try
                {
                    this.connection = ConnectionMultiplexer.Connect(configOptions);
                }
                catch (Exception ex)
                {
                    logger.LogError($"[Redis]Redis连接失败：{ex.Message}");
                }
            }
            return this.connection;
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string Get(string key)
        {
            return connection.GetDatabase().StringGet(key);
        }
        /// <summary>
        /// 删除值
        /// </summary>
        /// <param name="key"></param>
        public bool Delete(string key)
        {
            return connection.GetDatabase().KeyDelete(key);
        }
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool Set(string key, object value, TimeSpan ts)
        {
            if (value != null)
                return connection.GetDatabase().StringSet(key, System.Text.Json.JsonSerializer.Serialize(value), ts);
            else
                return false;
        }

    }
}
