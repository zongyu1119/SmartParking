using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Constraint.IServices;

namespace Zy.Message.Constraint.IServices
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
