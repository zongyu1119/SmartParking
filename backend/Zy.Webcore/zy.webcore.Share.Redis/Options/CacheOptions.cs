using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Redis.Options
{
    /// <summary>
    /// Redis Options
    /// </summary>
    public class CacheOptions
    {
        /// <summary>
        /// 最大随机秒数
        /// </summary>
        /// <remarks>
        /// If this value greater then zero, the seted cache items' expiration will add a random second
        /// This is mainly for preventing Cache Crash
        /// </remarks>
        /// <value>The max random second.</value>
        public int MaxRdSecond { get; set; } = 0;

        /// <summary>
        /// 是否开启缓存
        /// </summary>
        /// <value><c>true</c> if enable logging; otherwise, <c>false</c>.</value>
        public bool EnableLogging { get; set; }

        /// <summary>
        /// 睡眠毫秒数
        /// when mutex key alive, it will sleep some time, default is 300
        /// </summary>
        /// <value>The sleep ms.</value>
        public int SleepMs { get; set; } = 300;

        /// <summary>
        /// 锁毫秒数
        /// mutex key's alive time(ms), default is 5000
        /// </summary>
        /// <value>The lock ms.</value>
        public int LockMs { get; set; } = 5000;

        /// <summary>
        ///穿透设置
        /// </summary>
        public PenetrationOptions PenetrationSetting { get; set; }

        /// <summary>
        /// 超时秒数
        /// </summary>
        public int PollyTimeoutSeconds { get; set; } = 11;
        /// <summary>
        /// 穿透设置
        /// </summary>
        public sealed class PenetrationOptions
        {
            /// <summary>
            /// 是否启用
            /// </summary>
            public bool Disable { get; set; }

            public BloomFilterSetting BloomFilterSetting { get; set; }
        }
        /// <summary>
        /// 布隆过滤器设置
        /// </summary>
        public sealed class BloomFilterSetting
        {
            public string Name { get; set; }
            /// <summary>
            /// 容量
            /// </summary>
            public int Capacity { get; set; }
            /// <summary>
            /// 失败率
            /// </summary>
            public double ErrorRate { get; set; }
        }
    }
}
