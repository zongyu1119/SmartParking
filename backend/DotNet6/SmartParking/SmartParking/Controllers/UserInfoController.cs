using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Comm;
using Service.IService;
using Service.Models;
using Service.Params;
using SmartParking.Common;

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
    [EnableCors("CorsPolicy")]//配置Cors,允许跨域
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
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = $"{PowerType.Insert}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public Res<bool> AddUserInfo([FromBody]UserInfoAddParam param)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{param}");
            param.TenantId = this.TenantId;
            param.CreatedBy = this.UserId;
            return service.AddUserInfo(param);
        }
        
        /// <summary>
        /// 获得简要的用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = $"{PowerType.Select}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public Res<UserInfo> GetUserInfo(int id)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{id}");
            return service.GetUserInfo(id);
        }
        /// <summary>
        /// 获得用户列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = $"{PowerType.Select}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public Res<List<UserInfo>> GetUserInfoList([FromBody]UserInfoQueryParam param)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{param}");
            param.TenantId=this.TenantId;
            return service.GetUserInfoList(param);
        }
        /// <summary>
        /// 获得分页用户列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = $"{PowerType.Select}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public ResPage<UserInfo> GetUserInfoListPage([FromBody]ParamPage<UserInfoQueryParam> param)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{param}");
            if(param.Param==null)
                param.Param=new UserInfoQueryParam();
            param.Param.TenantId = TenantId;
            return service.GetUserInfoList(param);
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = $"{PowerType.Update}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public Res<bool> UpdateUserInfo([FromBody]UserInfoUpdateParam param)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{param}");
            param.TenantId = TenantId;
            return service.UpdateUserInfo(param);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles =$"{PowerType.Delete}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public Res<bool> DeleteUserInfo(int id)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{id}");
            return service.DeleteUserInfo(id);
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = $"{PowerType.Update}:{PowerID.UserInfoManagement}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public Res<bool> UpdateUserInfoPassword([FromBody]UserInfoUpdatePasswordParam param)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{param}");
            return service.UpdateUserInfoPassword(param);
        }
    }
}
