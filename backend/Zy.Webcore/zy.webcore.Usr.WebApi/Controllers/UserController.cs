using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zy.webcore.Share.Application.Filter;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.WebApi.Controllers;
using zy.webcore.Usr.Constraint.Dtos.User;
using zy.webcore.Usr.Constraint.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zy.webcore.Usr.WebApi.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserController : ZyControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
     
        /// <summary>
        /// 获取单个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get([FromRoute]int id)
        {
            return "value";
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<AppSrvResult<List<UserOutputDto>>> GetList([FromQuery]UserSearchDto dto)
        {
            return await _userService.GetListAsync(dto);
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public async Task<AppSrvResult<bool>> Post([FromBody] UserInputDto dto)
        {
            return await _userService.AddAsync(dto);
        }
        
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        /// <summary>
        /// 获得缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("GetCache")]
        public async Task<AppSrvResult<object>> GetCacheAsync([FromQuery]string key)
        {
            return await _userService.GetCacheAsync(key);
        }
        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("SetCache")]
        public async Task<AppSrvResult<bool>> SetCacheAsync([FromQuery]string key, [FromQuery]string value)
        {
            return await _userService.SetCacheAsync(key, value);
        }
    }
}
