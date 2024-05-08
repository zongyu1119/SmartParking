using Microsoft.AspNetCore.Mvc;
using Zy.User.Constraint.Dtos;
using Zy.User.Constraint.IServices;
using Zy.Shared.Constraint.Dtos;

namespace Zy.User.WebApi.Controllers
{
    /// <summary>
    /// 登录相关
    /// </summary>
    [Route("user/[Controller]/[Action]")]
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
        public async Task<ZyResult<JwtTokenResult>> LoginAsync([FromBody]SessionDto dto)
        {
           return await _sessionService.SessionAsync(dto);
        }

    }
}
