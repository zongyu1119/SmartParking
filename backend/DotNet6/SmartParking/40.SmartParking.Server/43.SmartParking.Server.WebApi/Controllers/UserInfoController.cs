using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartParking.Common;
using SmartParking.Server.Const.Dtos.DtoBase;
using SmartParking.Server.Const.Dtos.User;
using System.Runtime.CompilerServices;

/// <summary>
///  Namespace: SmartParking.Controllers
///  Name： UserInfoController
///  Author: zy
///  Time:  2022-04-03 22:07:54
///  Version:  0.1
/// </summary>

namespace SmartParking.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]   
    public class UserInfoController : ZyControllerBase
    {
        private readonly IUserInfoService service;
        /// <summary>
        /// 用户相关
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        /// <param name="_service"></param>
        public UserInfoController(IConfiguration _configuration, ILogger<LoginController> _logger, IUserInfoService _service) : base(_configuration, _logger)
        {
            service = _service;
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = $"{PowerType.Insert}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public async Task<ResDto<bool>> AddUserInfo([FromBody]UserCreateDto dto)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name??""} Args:{dto}");           
            return await service.CreateAsync(dto);
        }
        
        /// <summary>
        /// 获得简要的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = $"{PowerType.Select}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public async Task<ResDto<UserOutputDto>> GetUserInfo([FromRoute]long id)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} Args:{id}");
            return await service.GetModelAsync(id);
        }
        /// <summary>
        /// 获得用户列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = $"{PowerType.Select}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public async Task<ResDto<List<UserOutputDto>>> GetList([FromQuery]UserPageSearchDto dto)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} Args:{dto}");
            return await service.GetListAsync(dto);
        }
        /// <summary>
        /// 获得分页用户列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = $"{PowerType.Select}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public async Task<ResPageDto<UserOutputDto>> GetPageList([FromQuery]UserPageSearchDto dto)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} Args:{dto}");
            return await service.GetPageListAsync(dto);
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = $"{PowerType.Update}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public async Task<ResDto<bool>> UpdateUserInfo([FromBody]UserUpdateDto dto, [FromRoute] long id)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} Args:{dto}");
            return await service.UpdateAsync(dto,id);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles =$"{PowerType.Delete}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public async Task<ResDto<bool>> DeleteUserInfo(int id)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{id}");
            return await service.DeleteAsync(id);
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = $"{PowerType.Update}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public async Task<ResDto<bool>> UpdateUserPwd([FromBody] string pwd)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return await service.UpdatePwdAsync(pwd);
        }
    }
}
