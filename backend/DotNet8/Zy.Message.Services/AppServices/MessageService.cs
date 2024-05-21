using Microsoft.EntityFrameworkCore;
using Zy.Message.Constraint.Dtos;
using Zy.Message.Constraint.Dtos.ChatDtos;
using Zy.Shared.Repository.Contexts;
using Zy.Shared.Constraint.Dtos;
using Zy.Shared.Constraint.IServices;
namespace Zy.Message.Services.AppService
{
    public class MessageService(ZyContext dbcontext,
        ZyUserContext httpContext) : IAppService
    {
        /// <summary>
        /// 获取最近的100条消息（某个时间以前的100条）
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task<ZyResult<List<SendMessageOutputDto>>> GetNewMessageAsync(MessageSearchDto dto)
        {
            var listIQueryable = dbcontext.Set<Zy.Message.Repository.Entitys.Message>().Where(x => x.RecriveId == dto.GroupId);
            if (dto.Time.HasValue)
            {
                listIQueryable = listIQueryable.Where(x => x.SendTime <= dto.Time.Value);
            }
            var list = await listIQueryable
                .OrderByDescending(x => x.SendTime)
                .Select(x => new SendMessageOutputDto
                {
                    Id = x.Id,
                    Message = x.Content,
                    ReceiveId = x.RecriveId,
                    SendUserId = x.SendUserId,
                    Time = x.SendTime.ToString("yyyy-MM-dd HH:mm:ss")
                }).ToListAsync();
            return new ZyResult<List<SendMessageOutputDto>>(list);
        }
    }
}
