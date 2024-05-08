using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Yitter.IdGenerator;
using Zy.Message.Constraint.Dtos.ChatDtos;
using Zy.Message.Respository.Entitys;
using Zy.Shared.Respository.Contexts;

namespace Zy.Message.WebApi.ChatHubs
{
    /// <summary>
    /// HUB
    /// </summary>
    [Authorize]
    public class ChatHub(ZyShardingCoreContext context) : Hub
    {
        /// <summary>
        /// 客户端发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task SendMessage(SendMessageInputDto msg)
        {
            var userId = long.Parse(Context.User.Claims.FirstOrDefault(x => x.Type == "userid")?.Value ?? "0");
            var time = DateTime.Now;           
            var model = new Zy.Message.Respository.Entitys.Message
            {
                Content = msg.Message,
                CreateTime = time,
                Id = YitIdHelper.NextId(),
                RecriveId = msg.ReceiveId,
                 MessageType = msg.MessageType,
                SendTime = time,
                SendUserId = userId,
            };
            await context.Set<Zy.Message.Respository.Entitys.Message>().AddAsync(model);
            await context.SaveChangesAsync();
            var msgRes = new SendMessageOutputDto
            {
                Message = msg.Message,
                Time = time.ToString("yyyy-MM-dd HH:mm:ss"),
                ReceiveId = msg.ReceiveId,
                 MessageType=msg.MessageType,
                SendUserId = userId,
                Id=model.Id               
            };
            var receiveIds=await context.Set<User>()
                .Where(s=>context.Set<GroupUser>().Where(g=>g.GroupId==msg.ReceiveId).Select(g=>g.UserId).Contains(s.Id)&&s.IsOnline)
                .Select(x=>x.ConectionId).ToListAsync();
            if (receiveIds.Any())
                await Clients.Clients(receiveIds).SendAsync("ReceiveMessage", msgRes);
        }
        /// <summary>
        /// 连接
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            var userId = long.Parse(Context.User.Claims.FirstOrDefault(x => x.Type == "userid")?.Value??"0");
            var user = await context.Set<User>().FirstOrDefaultAsync(x => x.Id ==userId );
            user.IsOnline = true;
            user.ConectionId = Context.ConnectionId;
            await context.SaveChangesAsync();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = long.Parse(Context.User.Claims.FirstOrDefault(x => x.Type == "userid")?.Value ?? "0");
            var user = await context.Set<User>().FirstOrDefaultAsync(x => x.Id == userId);
            user.IsOnline = false;
            user.ConectionId =null;
            await context.SaveChangesAsync();
            await base.OnDisconnectedAsync(exception);
        }
    }
}
