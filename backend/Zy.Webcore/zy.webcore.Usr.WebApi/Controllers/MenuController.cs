using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.Constraint.Dtos;
using zy.webcore.Share.WebApi.Controllers;
using zy.webcore.Usr.Constraint.Dtos.Role;
using zy.webcore.Usr.Constraint.IServices;
using zy.webcore.Usr.Constraint.Dtos.Menu;

namespace zy.webcore.Usr.WebApi.Controllers
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Route("usr/[controller]")]
    public class MenuController : ZyControllerBase
    {
        private readonly IMenuService _service;
        public MenuController(IMenuService service)
        {
            _service = service;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<AppSrvResult<PageResDto<MenuOutputDto>>> GetListAsync([FromQuery]MenuSearchDto dto)
        {
            return await _service.GetListAsync(dto);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AppSrvResult> AddAsync([FromBody]MenuInputDto dto)
        {
            return await _service.AddAsync(dto);
        }
    }
}
