using Microsoft.AspNetCore.Mvc;
using Zy.Message.Constraint.Dtos;
using Zy.Message.Constraint.IServices;
using Zy.Message.WebApi.Services;
using Zy.Shared.Constraint.Dtos;

namespace Zy.Message.WebApi.Controllers
{
    /// <summary>
    /// 登录相关
    /// </summary>
    [Route("msg/[Controller]/[Action]")]
    [ApiController]
    public class SessionController(ISessionService service) : ControllerBase
    {
        private readonly ISessionService _sessionService = service;

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ZyResult<JwtTokenResult>> LoginAsync([FromBody]LoginDto dto)
        {
           return await _sessionService.SessionAsync(dto);
        }

    }
}
