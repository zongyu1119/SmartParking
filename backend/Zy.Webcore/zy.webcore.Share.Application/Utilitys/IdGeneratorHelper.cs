using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yitter.IdGenerator;

namespace zy.webcore.Share.Application.Utilitys
{
    /// <summary>
    /// 雪花漂移算法ID,使用单实例模式
    /// </summary>
    public class IdGeneratorHelper
    {
        public IdGeneratorHelper()
        {
            var options = new IdGeneratorOptions(1); //构造方法初始化雪花Id
            YitIdHelper.SetIdGenerator(options);
        }

        private static IIdGenerator _IdGenInstance = null;

        /// <summary>
        /// 设置参数，建议程序初始化时执行一次
        /// </summary>
        /// <param name="options"></param>
        private static void SetIdGenerator(IdGeneratorOptions options)
        {
            _IdGenInstance = new DefaultIdGenerator(options);
        }

        /// <summary>
        /// 生成新的Id
        /// 调用本方法前，请确保调用了 SetIdGenerator 方法做初始化。
        /// 否则将会初始化一个WorkerId为0的对象。
        /// </summary>
        /// <returns></returns>
        public long NextId()
        {
            _IdGenInstance ??= new DefaultIdGenerator(
                    new IdGeneratorOptions() { WorkerId = 0 }
                    );
            return _IdGenInstance.NewLong();
        }
    }
}
