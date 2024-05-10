namespace Zy.User.Constraint.IServices
{
    public interface ITestService:IAppService
    {
        /// <summary>
        /// 发布消息测试
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<string> Publish(string message);

    }
}
