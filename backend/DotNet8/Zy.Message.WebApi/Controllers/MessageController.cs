using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Zy.Message.WebApi.Services;
using Zy.Message.Constraint.Dtos;
using Zy.Message.Constraint.Dtos.ChatDtos;
using Zy.Message.Services.AppService;
using Zy.Shared.Constraint.Dtos;

namespace Zy.Message.WebApi.Controllers
{
    /// <summary>
    /// 消息相关
    /// </summary>
    [Route("msg/[Controller]/[Action]")]
    [ApiController]
    public class MessageController(MessageService service) : ControllerBase
    {
        private readonly MessageService _service = service;

        /// <summary>
        /// 获取最近的100条消息（某个时间以前的100条）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ZyResult<List<SendMessageOutputDto>>> GetNewMessageAsync([FromQuery]MessageSearchDto dto)
        {
            return await _service.GetNewMessageAsync(dto);
        }
    }
}
