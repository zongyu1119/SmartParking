using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Message.Constraint.Dtos.ChatDtos;
using Zy.Message.Constraint.Dtos;
using Zy.Shared.Constraint.IServices;
using Zy.Shared.Constraint.Dtos;

namespace Zy.Message.Constraint.IServices
{
    public interface IMessageService:IAppService
    {
        /// <summary>
        /// 消息服务
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ZyResult<List<SendMessageOutputDto>>> GetNewMessageAsync(MessageSearchDto dto);
    }
}
