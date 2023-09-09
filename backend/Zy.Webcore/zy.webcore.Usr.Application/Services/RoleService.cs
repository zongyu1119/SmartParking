using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Constraint.Dtos;
using zy.webcore.Share.Repository.IRepositories;
using zy.webcore.Share.Yitter.Services;
using zy.webcore.Usr.Constraint.Dtos.Role;

namespace zy.webcore.Usr.Application.Services
{
    /// <summary>
    /// 角色Service
    /// </summary>
    public class RoleService : AbstractAppService, IRoleService
    {
        private readonly IEfRepository<SysRole> _repository;
        private readonly IEfRepository<SysRoleMenu> _roleMenuRepository;
        public RoleService(IEfRepository<SysRole> repository,
            IEfRepository<SysRoleMenu> roleMenuRepository)
        {
            _repository = repository;
            _roleMenuRepository = roleMenuRepository;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppSrvResult> AddAsync(RoleInputDto dto)
        {
            if (await _repository.AnyAsync(x => x.RoleName == dto.RoleName))
                return Problem(HttpStatusCode.BadRequest, "角色已存在！");
            var model=Mapper.Map<SysRole>(dto);
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
        public async Task<AppSrvResult<PageResDto<RoleOutputDto>>> GetListAsync(RoleSearchDto dto)
        {
            var expression = ExpressionCreator.New<SysRole>()
               .AndIf(dto.Name.IsNotNullOrWhiteSpace(), x => x.RoleName.Contains(dto.Name));
            var count = await _repository.CountAsync(expression);
            var res = await _repository.Where(expression)
                .Skip(dto.SkipRows)
                .Take(dto.PageSize)
                .ToListAsync();
            return new PageResDto<RoleOutputDto>
            {
                Data = Mapper.Map<List<RoleOutputDto>>(res),
                PageSize = dto.PageSize,
                PageIndex = dto.PageIndex,
                TotalCount = count
            };
        }
    }
}
