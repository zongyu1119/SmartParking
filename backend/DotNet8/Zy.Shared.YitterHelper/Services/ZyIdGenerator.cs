using Yitter.IdGenerator;
namespace Zy.Shared.YitterHelper.Services
{
    public class ZyIdGenerator
    {
        public ZyIdGenerator()
        {
        }

        private static IIdGenerator _IdGenInstance = null;

        /// <summary>
        /// 设置参数，建议程序初始化时执行一次
        /// </summary>
        /// <param name="workId"></param>
        public static void SetIdGenerator(ushort workId)
        {
            var options = new IdGeneratorOptions(workId); //构造方法初始化雪花Id
            YitIdHelper.SetIdGenerator(options);
            _IdGenInstance = new DefaultIdGenerator(options);
        }
     
        /// <summary>
        /// 生成新的Id
        /// 调用本方法前，请确保调用了 SetIdGenerator 方法做初始化。
        /// 否则将会初始化一个WorkerId为0的对象。
        /// </summary>
        /// <returns></returns>
        public static long NextId()
        {
            _IdGenInstance ??= new DefaultIdGenerator(
                    new IdGeneratorOptions() { WorkerId = 0 }
                    );
            return _IdGenInstance.NewLong();
        }
    }
}
