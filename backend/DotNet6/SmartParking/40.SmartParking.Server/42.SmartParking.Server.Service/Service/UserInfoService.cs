

using SmartParking.Server.Const.Dtos.DtoBase;
using SmartParking.Server.Const.Dtos.Power;
using SmartParking.Server.Const.Dtos.Role;
using SmartParking.Server.Const.Dtos.User;
using SmartParking.Share.Str;

namespace Service.Service
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoService : AbstractAppService,IUserInfoService
    {
        /// <summary>
        /// 数据库资源
        /// </summary>
        private readonly IEFRepository<Userinfo> _repository;
        private readonly IEFRepository<Role> _roleRepository;
        private readonly IEFRepository<RolePower> _rolePowerRepository;
        private readonly IEFRepository<Power> _powerRepository;
        private readonly ILogger<UserInfoService> _logger;
        /// <summary>
        /// 实现依赖自动注入
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        /// <param name="repository"></param>
        /// <param name="_mapper"></param>
        public UserInfoService(
             ILogger<UserInfoService> logger,
             IEFRepository<Userinfo> repository,
             IEFRepository<Role> roleRepository,
             IEFRepository<RolePower> rolePowerRepository,
             IEFRepository<Power> powerRepository
            ) 
        {
            this._repository = repository;
            this._roleRepository = roleRepository;
            this._rolePowerRepository = rolePowerRepository;
            this._powerRepository = powerRepository;
            _logger = logger;
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="createByUserId"></param>
        /// <returns></returns>
        public async Task<ResDto<bool>> CreateAsync(UserCreateDto dto)
        {
            var model=Mapper.Map<Userinfo>(dto);//使用AutoMapper
            model.CreatedTime = DateTime.Now;
            model.Revision = 1;
            var success = await _repository.InsertAsync(model) > 0;
            var res = new ResDto<bool>(success);
            if (!res.Success)
            {
                res.Message = "新增用户失败！";
                _logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}新增失败！", dto);
            }
            return res;
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ResDto<bool>> DeleteAsync(long id)
        {
            var success = await _repository.DeleteAsync(id) > 0;
            var res = new ResDto<bool>(success);
            if (!res.Success)
            {
                res.Message = "删除用户失败！";
                _logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}执行失败！", id);
            }
            return res;
        }
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResDto<UserDetailOutputDto>> GetUserDetailInfoAsync(long id)
        {
            var roleRes = _roleRepository.GetAll();
            var rolePowerRes= _rolePowerRepository.GetAll();
            var powerRes = _powerRepository.GetAll();
            var user = await _repository.Where(x => x.Id.Equals(id))
                .Select(x => new UserDetailOutputDto()
                {
                    TenantId=x.TenantId,
                    UserId = x.Id,
                    Address = x.Address,
                    Password = x.Password,
                    Phone = x.Phone,
                    RoleId = x.RoleId,
                    Sex = x.Sex,
                    UserIdCardNum = x.UserIdCardNum,
                    UserName = x.UserName,
                    UserNameRel = x.UserNameRel,
                    Role = roleRes.Where(r => r.Id.Equals(x.RoleId)).Select(r => new RoleOutputDto
                    {
                        RoleId = r.Id,
                        RoleName = r.RoleName,
                    }).FirstOrDefault(),
                    RolePowers = rolePowerRes.Where(p => p.RoleId.Equals(x.RoleId))
                    .Select(rp => new RolePowerOutputDto
                    {
                        RoleId = rp.RoleId,
                        PowerId = rp.PowerId,
                        IsDelete = rp.IsDelete,
                        IsInsert = rp.IsInsert,
                        IsSelect = rp.IsSelect,
                        IsUpdate = rp.IsUpdate,
                        Power = powerRes.Where(p => p.Id.Equals(rp.PowerId))
                                   .Select(p => new PowerOutputDto
                                   {
                                       PowerId = p.Id,
                                       ParentId = p.ParentId,
                                       PowerLevel = p.PowerLevel,
                                       PowerName = p.PowerName,
                                       PowerPath = p.PowerPath,
                                       PowerType = p.PowerType,
                                   }).FirstOrDefault()
                    }).ToList(),
                }).FirstAsync();
            return new ResDto<UserDetailOutputDto>(user);
        }
        /// <summary>
        /// 根据用户名获得用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public async Task<ResDto<UserDetailOutputDto>> GetUserDetailInfoAsync(string userName)
        {
            var roleRes = _roleRepository.GetAll();
            var rolePowerRes = _rolePowerRepository.GetAll();
            var powerRes = _powerRepository.GetAll();
            var user = await _repository.Where(x => x.UserName.Equals(userName))
                .Select(x => new UserDetailOutputDto()
                {
                    TenantId = x.TenantId,
                    UserId = x.Id,
                    Address = x.Address,
                    Password = x.Password,
                    Phone = x.Phone,
                    RoleId = x.RoleId,
                    Sex = x.Sex,
                    UserIdCardNum = x.UserIdCardNum,
                    UserName = x.UserName,
                    UserNameRel = x.UserNameRel,
                    Role = roleRes.Where(r => r.Id.Equals(x.RoleId)).Select(r => new RoleOutputDto
                    {
                        RoleId = r.Id,
                        RoleName = r.RoleName,
                    }).FirstOrDefault(),
                    RolePowers = rolePowerRes.Where(p => p.RoleId.Equals(x.RoleId))
                    .Select(rp => new RolePowerOutputDto
                    {
                        RoleId = rp.RoleId,
                        PowerId = rp.PowerId,
                        IsDelete = rp.IsDelete,
                        IsInsert = rp.IsInsert,
                        IsSelect = rp.IsSelect,
                        IsUpdate = rp.IsUpdate,
                        Power = powerRes.Where(p => p.Id.Equals(rp.PowerId))
                                   .Select(p => new PowerOutputDto
                                   {
                                       PowerId = p.Id,
                                       ParentId = p.ParentId,
                                       PowerLevel = p.PowerLevel,
                                       PowerName = p.PowerName,
                                       PowerPath = p.PowerPath,
                                       PowerType = p.PowerType,
                                   }).FirstOrDefault()
                    }).ToList(),
                }).FirstAsync();
            return new ResDto<UserDetailOutputDto>(user);
        }
        /// <summary>
        /// 获得页面用户列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResDto<UserDetailOutputDto>> GetUserDetailInfoToViewAsync(long id)
        {
            var roleRes = _roleRepository.GetAll();
            var rolePowerRes = _rolePowerRepository.GetAll();
            var powerRes = _powerRepository.GetAll();
            var user = await _repository.Where(x => x.Id.Equals(id))
               .Select(x => new UserDetailOutputDto()
               {
                   TenantId = x.TenantId,
                   UserId = x.Id,
                   Address = x.Address,
                   Password = x.Password,
                   Phone = x.Phone,
                   RoleId = x.RoleId,
                   Sex = x.Sex,
                   UserIdCardNum = x.UserIdCardNum,
                   UserName = x.UserName,
                   UserNameRel = x.UserNameRel,
                   Role = roleRes.Where(r => r.Id.Equals(x.RoleId)).Select(r => new RoleOutputDto
                   {
                       RoleId = r.Id,
                       RoleName = r.RoleName,
                   }).FirstOrDefault(),
                   RolePowers = rolePowerRes.Where(p => p.RoleId.Equals(x.RoleId))
                   .Select(rp => new RolePowerOutputDto
                   {
                       RoleId = rp.RoleId,
                       PowerId = rp.PowerId,
                       IsDelete = rp.IsDelete,
                       IsInsert = rp.IsInsert,
                       IsSelect = rp.IsSelect,
                       IsUpdate = rp.IsUpdate,
                       Power = powerRes.Where(p => p.Id.Equals(rp.PowerId))
                                  .Select(p => new PowerOutputDto
                                  {
                                      PowerId = p.Id,
                                      ParentId = p.ParentId,
                                      PowerLevel = p.PowerLevel,
                                      PowerName = p.PowerName,
                                      PowerPath = p.PowerPath,
                                      PowerType = p.PowerType,
                                  }).FirstOrDefault()
                   }).ToList(),
               }).FirstAsync();
            var res = new ResDto<UserDetailOutputDto>(user);
            if (!res.Success)
            {
                res.Message = "查询用户失败！";
            }
            return res;
        }
        /// <summary>
        /// 获得用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResDto<UserOutputDto>> GetModelAsync(long id)
        {
            var roleRes = _roleRepository.GetAll();
            var user = await _repository.Where(x => x.Id.Equals(id))
             .Select(x => new UserOutputDto()
             {
                 Id=x.Id,
                 Address = x.Address,
                 Password = x.Password,
                 Phone = x.Phone,
                 RoleId = x.RoleId,
                 Sex = x.Sex,
                 UserIdCardNum = x.UserIdCardNum,
                 UserName = x.UserName,
                 UserNameRel = x.UserNameRel,
                 RoleName= roleRes.Where(r => r.Id.Equals(x.RoleId)).FirstOrDefault().RoleName

             }).FirstAsync();
            var res = new ResDto<UserOutputDto>(user);
            if (!res.Success)
            {
                res.Message = "查询用户失败！";
            }
            return res;
        }
        /// <summary>
        /// 查询用户列表-不分页
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ResDto<List<UserOutputDto>>> GetListAsync(UserPageSearchDto dto)
        {
            var whereCondition = ExpressionCreator.New<Userinfo>().
            AndIf(dto.UserName.IsNotNullOrWhiteSpace(), x => x.UserName.Contains(dto.UserName))
            .AndIf(dto.RoleId.HasValue, x => x.RoleId == dto.RoleId);
            var roleRes = _roleRepository.GetAll();
            var user=await _repository.Where(whereCondition).Select(x => new UserOutputDto()
             {
                 Id = x.Id,
                 Address = x.Address,
                 Password = x.Password,
                 Phone = x.Phone,
                 RoleId = x.RoleId,
                 Sex = x.Sex,
                 UserIdCardNum = x.UserIdCardNum,
                 UserName = x.UserName,
                 UserNameRel = x.UserNameRel,
                  RoleName= roleRes.Where(r=>r.Id.Equals(x.RoleId)).FirstOrDefault().RoleName
             }).ToListAsync();
            var res = new ResDto<List<UserOutputDto>>(user);
            if (!res.Success)
            {
                res.Message = "查询用户失败！";
            }
            return res;
        }

        /// <summary>
        /// 查询用户列表-分页
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ResPageDto<UserOutputDto>> GetPageListAsync(UserPageSearchDto dto)
        {
            var whereCondition = ExpressionCreator.New<Userinfo>().
            AndIf(dto.UserName.IsNotNullOrWhiteSpace(), x => x.UserName.Contains(dto.UserName))
            .AndIf(dto.RoleId.HasValue, x => x.RoleId == dto.RoleId);
            var roleRes = _roleRepository.GetAll();
            var count = await _repository.CountAsync(whereCondition);
            var user = await _repository.Where(whereCondition).Select(x => new UserOutputDto()
            {
                Id = x.Id,
                Address = x.Address,
                Password = x.Password,
                Phone = x.Phone,
                RoleId = x.RoleId,
                Sex = x.Sex,
                UserIdCardNum = x.UserIdCardNum,
                UserName = x.UserName,
                UserNameRel = x.UserNameRel,
                RoleName = roleRes.Where(r => r.Id.Equals(x.RoleId)).FirstOrDefault().RoleName
            }).Skip(dto.PageSize*(dto.Index-1)).Take(dto.PageSize).ToListAsync();
            var res = new ResPageDto<UserOutputDto>(user);
            res.PageSize = dto.PageSize;
            res.PageCurrent = dto.Index;
            res.TotalCount = count;
            if (!res.Success)
            {
                res.Message = "查询用户失败！";
            }
            return res;
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ResDto<bool>> UpdateAsync(UserUpdateDto dto, long id)
        {
            var user = await _repository.FindAsync(x => x.Id.Equals(id));            
            if (user == null)
            {
                var res = new ResDto<bool>(false);
                res.Data = false;
                res.Message = "未找到要修改的对象！";
                return res;
            }
            else
            {
                var newUser= Mapper.Map(dto, user);
                var success = await _repository.UpdateAsync(newUser) > 0;
                ResDto<bool> res = new ResDto<bool>(success);
                if (!res.Success)
                {
                    res.Message = "修改用户失败！";
                }
                return res;
            }
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResDto<bool>> UpdatePwdAsync(string pwd)
        {
            var user = await _repository.FindAsync(x => x.Id.Equals(id));
            if (user == null)
            {
                ResDto<bool> res = new ResDto<bool>(false);
                res.Data = false;
                res.Message = "未找到要修改的用户！";
                return res;
            }
            else
            {
                user.Password = pwd.GetMd5();
                var success = await _repository.UpdateAsync(user, UpdatingProps<Userinfo>(
                s => s.Password)) > 0;
                ResDto<bool> res = new ResDto<bool>(success);
                if (!res.Success)
                {
                    res.Message = "修改用户密码失败！";
                    _logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}失败！");
                }
                return res;
            }
        }
    }
}
