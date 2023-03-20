using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.Constraint.Dtos;
using zy.webcore.Share.WebApi.Controllers;
using zy.webcore.Usr.Constraint.Dtos.Role;
using zy.webcore.Usr.Constraint.IServices;

namespace zy.webcore.Usr.WebApi.Controllers
{
    /// <summary>
    /// 角色
    /// </summary>
    public class RoleController : ZyControllerBase
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService service)
        {
            _service = service;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<AppSrvResult<PageResDto<RoleOutputDto>>> GetListAsync([FromQuery]RoleSearchDto dto)
        {
            return await _service.GetListAsync(dto);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AppSrvResult> AddAsync([FromBody]RoleInputDto dto)
        {
            return await _service.AddAsync(dto);
        }
    }
}
