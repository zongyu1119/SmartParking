using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Zy.Shared.Constraint.Dtos;
using Zy.Shared.WebApi.Authorizes;
using Zy.User.Constraint.Dtos;
using Zy.User.Constraint.IServices;

namespace Zy.User.WebApi.Controllers
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Route("user/sysUser")]
    [ApiController]
    public class SysUserController(ISysUserService sysUserService) : ControllerBase
    {
        #region 新增用户表
        /// <summary>
        /// 新增用户表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ZyAuthorize("user_sysUser_add")]
        public async Task<ZyResult<bool>> AddAsync([FromBody] SysUserInputDto dto)
        {
            return await sysUserService.AddAsync(dto);
        }
        #endregion
        #region 删除用户表
        /// <summary>
        /// 删除用户表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ZyAuthorize("user_sysUser_delete")]
        public async Task<ZyResult<bool>> DeleteAsync([FromRoute] long id)
        {
            return await sysUserService.DeleteAsync(id);
        }
        #endregion
        #region 批量删除用户表
        /// <summary>
        /// 批量删除用户表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete("deleteRange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ZyAuthorize("user_sysUser_deleteRange")]
        public async Task<ZyResult<bool>> DeleteRangeAsync([FromBody] List<long> ids)
        {
            return await sysUserService.DeleteRangeAsync(ids);
        }
        #endregion
       
        #region 用户表修改
        /// <summary>
        /// 用户表修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ZyAuthorize("user_sysUser_update")]
        public async Task<ZyResult<bool>> UpdateAsync([FromRoute] long id, [FromBody] SysUserInputDto dto)
        {
            return await sysUserService.UpdateAsync(id, dto);
        }
        #endregion
    }
}
