
using zy.webcore.Share.Constraint.Dtos;
using zy.webcore.Share.Yitter.Services;

namespace zy.webcore.Usr.Application.Services
{
    public class UserService : AbstractAppService, IUserService
    {
        private readonly IEfRepository<SysUser> _reposiory;
        private readonly IEfRepository<SysRole> _roleReposiory;
        private readonly IEfRepository<SysRoleMenu> _roleMenuReposiory;
        private readonly IEfRepository<SysUserRole> _userRoleReposiory;
        private readonly IEfRepository<SysMenu> _menuReposiory;
        private readonly ICacheService _cacheService;
        private readonly UserContext _userContext;
        public UserService(IEfRepository<SysUser> repository,
            ICacheService cacheService,
            UserContext userContext,
            IEfRepository<SysRole> roleReposiory,
            IEfRepository<SysRoleMenu> roleMenuReposiory,
            IEfRepository<SysUserRole> userRoleReposiory,
            IEfRepository<SysMenu> menuReposiory)
        {
            _reposiory = repository;
            _cacheService = cacheService;
            _userContext = userContext;
            _roleReposiory = roleReposiory;
            _roleMenuReposiory = roleMenuReposiory;
            _userRoleReposiory= userRoleReposiory;
            _menuReposiory = menuReposiory;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppSrvResult<bool>> AddAsync(UserInputDto dto)
        {
            if (await _reposiory.AnyAsync(x => x.Account == dto.Account))
                return Problem<bool>(System.Net.HttpStatusCode.BadRequest, "用户账户已存在！");
            var psd = RSAEncode.RSAEncryption(dto.Password);
            var model = Mapper.Map<SysUser>(dto);            
            model.Id=ZyIdGenerator.NextId();
            model.Password = psd;
            return await _reposiory.InsertAsync(model)>0;
        }

        /// <summary>
        /// 分页查找用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppSrvResult<PageResDto<UserOutputDto>>> GetListAsync(UserSearchDto dto)
        {
            var expression = ExpressionCreator.New<SysUser>()
                .AndIf(dto.Name.IsNotNullOrWhiteSpace(),x=>x.UserName.Contains(dto.Name));
            var count=await _reposiory.CountAsync(expression);
            var res = await _reposiory.Where(expression)
                .Skip(dto.SkipRows)
                .Take(dto.PageSize)
                .ToListAsync();
            var data= Mapper.Map<List<UserOutputDto>>(res);
            return new PageResDto<UserOutputDto>
            {
                Data = data,
                PageSize = dto.PageSize,
                PageIndex = dto.PageIndex,
                TotalCount = count
            };
        }
        /// <summary>
        /// 查找用户详细信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<UserDetailInfoDto> GetUserDetailInfoAsync(string account)
        {
            var userRoleRep = _userRoleReposiory.GetAll();
            var roleMenuRep=_roleMenuReposiory.GetAll();
            var res = await _reposiory.Where(x => x.Account == account)
                .Select(x => new UserDetailInfoDto
                {
                    Address = x.Address,
                    Password = x.Password,
                    Phone = x.Phone,
                    Sex = x.Sex,
                    UserId = x.Id,
                    UserIdCardNum = x.UserIdCardNum,
                    UserName = x.UserName,
                    Account=x.Account,
                    RoleIds=userRoleRep.Where(s=>s.UserId==x.Id).Select(s=>s.Id).ToList(),
                }).FirstOrDefaultAsync();
            var menuList = await _menuReposiory
                .Where(x => roleMenuRep.Where(s => res.RoleIds.Contains(s.RoleId)).Select(s => s.MenuId).Contains(x.Id)).ToListAsync();
            res.MenuList = Mapper.Map<List<MenuOutputDto>>(menuList);
            return res;
        }

        public async Task<AppSrvResult<object>> GetCacheAsync(string key)
        {
            return await _cacheService.GetAsync(key);
        }

        public async Task<AppSrvResult<bool>> SetCacheAsync(string key,string value)
        {
            await _cacheService.SetAsync(key,value,500);
            return true;
        }
    }
}
