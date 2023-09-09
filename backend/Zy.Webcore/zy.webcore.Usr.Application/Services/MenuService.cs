using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Constraint.Dtos;
using zy.webcore.Share.Yitter.Services;
using zy.webcore.Usr.Constraint.Dtos.Role;

namespace zy.webcore.Usr.Application.Services
{
    public class MenuService:AbstractAppService, IMenuService
    {
        private readonly IEfRepository<SysMenu> _repository;
        public MenuService(IEfRepository<SysMenu> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppSrvResult> AddAsync(MenuInputDto dto)
        {
            if (await _repository.AnyAsync(x => x.MenuCode == dto.MenuCode))
                return Problem(HttpStatusCode.BadRequest, "菜单已存在！");
            var model = Mapper.Map<SysMenu>(dto);
            model.Id = ZyIdGenerator.NextId();
            await _repository.InsertAsync(model);
            return new AppSrvResult();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppSrvResult<PageResDto<MenuOutputDto>>> GetListAsync(MenuSearchDto dto)
        {
            var expression = ExpressionCreator.New<SysMenu>()
               .AndIf(dto.Name.IsNotNullOrWhiteSpace(), x => x.MenuName.Contains(dto.Name))
               .AndIf(dto.Code.IsNotNullOrWhiteSpace(),x=>x.MenuCode.Contains(dto.Code));
            var count = await _repository.CountAsync(expression);
            var res = await _repository.Where(expression)
                .Skip(dto.SkipRows)
                .Take(dto.PageSize)
                .ToListAsync();
            return new PageResDto<MenuOutputDto>
            {
                Data = Mapper.Map<List<MenuOutputDto>>(res),
                PageSize = dto.PageSize,
                PageIndex = dto.PageIndex,
                TotalCount = count
            };
        }
    }
}
