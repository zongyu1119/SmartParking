using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zy.Message.Constraint.Dtos;
using Zy.Message.Constraint.IServices;
using Zy.Message.WebApi.Services;
using Zy.Shared.Constraint.Dtos;

namespace Zy.Message.WebApi.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    /// <remarks>
    /// 用户
    /// </remarks>  
    /// <param name="service"></param>
    [Route("message/[Controller]/[Action]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {
        private readonly IUserService _service = service;

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ZyResult<List<UserOutputDto>>> GetList()
        {
            return await _service.GetList();
        }
        /// <summary>
        /// 获得聊天组
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ZyResult<List<GroupOutputDto>>> GetChatGroupAsync()
        {
            return await _service.GetChatGroupAsync();
        }
        /// <summary>
        /// 查询我的好友
        /// </summary>
        /// <param name="searchVal"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ZyResult<List<UserOutputDto>>> GetFirendAsync([FromQuery]string? searchVal)
        {
            return await _service.GetFirendAsync(searchVal);
        }
    }
}
