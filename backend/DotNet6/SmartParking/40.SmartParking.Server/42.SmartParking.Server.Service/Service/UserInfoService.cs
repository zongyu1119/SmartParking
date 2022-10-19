using Const.Dtos.User;
namespace Service.Service
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoService : ServiceBase<Userinfo>,IUserInfoService
    {
        /// <summary>
        /// 数据库资源
        /// </summary>
        private readonly IEFRepository<Userinfo> _repository;
        private readonly IEFRepository<Role> _roleRepository;
        private readonly IEFRepository<RolePower> _rolePowerRepository;
        private readonly IEFRepository<Power> _powerRepository;
        /// <summary>
        /// 实现依赖自动注入
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        /// <param name="repository"></param>
        /// <param name="_mapper"></param>
        public UserInfoService(IConfiguration _configuration,
             ILogger<UserInfoService> _logger,
             IEFRepository<Userinfo> repository,
             IMapper _mapper,
             IEFRepository<Role> roleRepository,
             IEFRepository<RolePower> rolePowerRepository,
             IEFRepository<Power> powerRepository
            ) : base(_configuration,_logger,_mapper)
        {
            this._repository = repository;
            this._roleRepository = roleRepository;
            this._rolePowerRepository = rolePowerRepository;
            this._powerRepository = powerRepository;
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="param"></param>
        /// <param name="createByUserId"></param>
        /// <returns></returns>
        public async Task<Res<bool>> AddUserInfo(UserInfoAddParam param)
        {
            var model=mapper.Map<Userinfo>(param);//使用AutoMapper
            model.CreatedTime = DateTime.Now;
            model.Revision = 1;
            Res<bool> res =new Res<bool>(await _repository.InsertAsync(model) > 0);
            res.Data = res.Success;
            if (!res.Success)
            {
                res.Message = "新增用户失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}新增失败！", param);
            }
            return res;
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Res<bool>> DeleteUserInfo(int id)
        {
            Res<bool> res = new Res<bool>(await _repository.DeleteAsync(id) > 0);
            res.Data = res.Success;
            if (!res.Success)
            {
                res.Message = "删除用户失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}执行失败！", id);
            }
            return res;
        }
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserDetailInfoOutputDto?> GetUserDetailInfo(int id)
        {
            var user = _repository.Where(x => x.UserId.Equals(id))
                .Select(x => new UserDetailInfoOutputDto()
                {
                    TenantId=x.TenantId,
                    UserId = x.UserId,
                    Address = x.Address,
                    Password = x.Password,
                    Phone = x.Phone,
                    RoleId = x.RoleId,
                    Sex = x.Sex,
                    UserIdCardNum = x.UserIdCardNum,
                    UserName = x.UserName,
                    UserNameRel = x.UserNameRel,
                    Role = _repository.Where(r => r.RoleId.Equals(x.RoleId)).Select(r => new RoleOutputDto
                    {
                        RoleId = r.RoleId,
                        RoleName = r.RoleName,
                    }).FirstOrDefault(),
                    RolePowers = _rolePowerRepository.Where(p => p.RoleId.Equals(x.RoleId))
                    .Select(rp => new RolePowerOutputDto
                    {
                        RoleId = rp.RoleId,
                        PowerId = rp.PowerId,
                        IsDelete = rp.IsDelete,
                        IsInsert = rp.IsInsert,
                        IsSelect = rp.IsSelect,
                        IsUpdate = rp.IsUpdate,
                        Power = _powerRepository.Where(p => p.PowerId.Equals(rp.PowerId))
                                   .Select(p => new PowerOutputDto
                                   {
                                       PowerId = p.PowerId,
                                       ParentId = p.ParentId,
                                       PowerLevel = p.PowerLevel,
                                       PowerName = p.PowerName,
                                       PowerPath = p.PowerPath,
                                       PowerType = p.PowerType,
                                   }).FirstOrDefault()
                    }).ToList(),
                }).FirstOrDefault();
            return user;
        }
        /// <summary>
        /// 根据用户名获得用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public UserDetailInfoOutputDto? GetUserDetailInfo(string userName)
        {
            var user = _repository.Where(x => x.UserName.Equals(userName))
                .Select(x => new UserDetailInfoOutputDto()
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
                    Role = _repository.DbContext.BcRoles.Where(r => r.RoleId.Equals(x.RoleId)).Select(r => new RoleOutputDto
                    {
                        RoleId = r.RoleId,
                        RoleName = r.RoleName,
                    }).FirstOrDefault(),
                    RolePowers = _repository.DbContext.BcRolePowers.Where(p => p.RoleId.Equals(x.RoleId))
                    .Select(rp => new RolePowerOutputDto
                    {
                        RoleId = rp.RoleId,
                        PowerId = rp.PowerId,
                        IsDelete = rp.IsDelete,
                        IsInsert = rp.IsInsert,
                        IsSelect = rp.IsSelect,
                        IsUpdate = rp.IsUpdate,
                        Power = _repository.DbContext.BcPowers.Where(p => p.PowerId.Equals(rp.PowerId))
                                   .Select(p => new PowerOutputDto
                                   {
                                       PowerId = p.PowerId,
                                       ParentId = p.ParentId,
                                       PowerLevel = p.PowerLevel,
                                       PowerName = p.PowerName,
                                       PowerPath = p.PowerPath,
                                       PowerType = p.PowerType,
                                   }).FirstOrDefault()
                    }).ToList(),
                }).FirstOrDefault();
            return user;
        }
        /// <summary>
        /// 获得页面用户列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Res<UserDetailInfoOutputDto> GetUserDetailInfoToView(int id)
        {
            var user = _repository.Where(x => x.UserId.Equals(id))
               .Select(x => new UserDetailInfoOutputDto()
               {
                   TenantId = x.TenantId,
                   UserId = x.UserId,
                   Address = x.Address,
                   Password = x.Password,
                   Phone = x.Phone,
                   RoleId = x.RoleId,
                   Sex = x.Sex,
                   UserIdCardNum = x.UserIdCardNum,
                   UserName = x.UserName,
                   UserNameRel = x.UserNameRel,
                   Role = _repository.DbContext.BcRoles.Where(r => r.RoleId.Equals(x.RoleId)).Select(r => new RoleOutputDto
                   {
                       RoleId = r.RoleId,
                       RoleName = r.RoleName,
                   }).FirstOrDefault(),
                   RolePowers = _repository.DbContext.BcRolePowers.Where(p => p.RoleId.Equals(x.RoleId))
                   .Select(rp => new RolePowerOutputDto
                   {
                       RoleId = rp.RoleId,
                       PowerId = rp.PowerId,
                       IsDelete = rp.IsDelete,
                       IsInsert = rp.IsInsert,
                       IsSelect = rp.IsSelect,
                       IsUpdate = rp.IsUpdate,
                       Power = _repository.DbContext.BcPowers.Where(p => p.PowerId.Equals(rp.PowerId))
                                  .Select(p => new PowerOutputDto
                                  {
                                      PowerId = p.PowerId,
                                      ParentId = p.ParentId,
                                      PowerLevel = p.PowerLevel,
                                      PowerName = p.PowerName,
                                      PowerPath = p.PowerPath,
                                      PowerType = p.PowerType,
                                  }).FirstOrDefault()
                   }).ToList(),
               }).FirstOrDefault();
            Res<UserDetailInfoOutputDto> res = new(user!=null);
            res.Data = user;
            if (!res.Success)
            {
                res.Message = "查询用户失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}执行失败！", id);
            }
            return res;
        }
        /// <summary>
        /// 获得用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Res<UserInfoOutputDto> GetUserInfo(int id)
        {
            var user = _repository.Where(x => x.Id.Equals(id))
             .Select(x => new UserInfoOutputDto()
             {
                 UserId = x.Id,
                 Address = x.Address,
                 Password = x.Password,
                 Phone = x.Phone,
                 RoleId = x.RoleId,
                 Sex = x.Sex,
                 UserIdCardNum = x.UserIdCardNum,
                 UserName = x.UserName,
                 UserNameRel = x.UserNameRel,
                 RoleName= _repository.DbContext.BcRoles.Where(r => r.RoleId.Equals(x.RoleId)).FirstOrDefault().RoleName

             }).FirstOrDefault();
            Res<UserInfoOutputDto> res = new(user != null);
            res.Data = user;
            if (!res.Success)
            {
                res.Message = "查询用户失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}执行失败！", id);
            }
            return res;
        }
        /// <summary>
        /// 查询用户列表-不分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Res<List<UserInfoOutputDto>> GetUserInfoList(UserInfoQueryParam param)
        {
            var resDb = _repository.DbContext.BcUserinfos.Where(x=>x.TenantId==param.TenantId);
            if (param.UserName != null)
            {
                resDb.Where(x => x.UserName.Contains(param.UserName));
            }
            if (param.RoleId != null)
            {
                resDb.Where(x => x.RoleId.Equals(param.RoleId));
            }
            var user=resDb.Select(x => new UserInfoOutputDto()
             {
                 UserId = x.UserId,
                 Address = x.Address,
                 Password = x.Password,
                 Phone = x.Phone,
                 RoleId = x.RoleId,
                 Sex = x.Sex,
                 UserIdCardNum = x.UserIdCardNum,
                 UserName = x.UserName,
                 UserNameRel = x.UserNameRel,
                  RoleName=_repository.DbContext.BcRoles.Where(r=>r.RoleId.Equals(x.RoleId)).FirstOrDefault().RoleName
             }).ToList();
            Res<List<UserInfoOutputDto>> res = new(user != null);
            res.Data = user;
            if (!res.Success)
            {
                res.Message = "查询用户失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}执行失败！", param);
            }
            return res;
        }

        /// <summary>
        /// 查询用户列表-分页
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ResPage<UserInfoOutputDto> GetUserInfoList(ParamPage<UserInfoQueryParam> param)
        {
            var resDb = _repository.DbContext.BcUserinfos.Where(x => x.TenantId.Equals(param.Param.TenantId));
            if (param.Param.UserName != null)
            {
                resDb.Where(x => x.UserName.Contains(param.Param.UserName));
            }
            if (param.Param.RoleId != null)
            {
                resDb.Where(x => x.RoleId.Equals(param.Param.RoleId));
            }
            int count=resDb.Count();
            var user = resDb.Select(x => new UserInfoOutputDto()
            {
                UserId = x.UserId,
                Address = x.Address,
                Password = x.Password,
                Phone = x.Phone,
                RoleId = x.RoleId,
                Sex = x.Sex,
                UserIdCardNum = x.UserIdCardNum,
                UserName = x.UserName,
                UserNameRel = x.UserNameRel,
                RoleName = _repository.DbContext.BcRoles.Where(r => r.RoleId.Equals(x.RoleId)).FirstOrDefault().RoleName
            }).Skip(param.PageCurrent * param.PageSize).Take(param.PageSize).ToList();
            ResPage<UserInfoOutputDto> res = new(user != null);
            res.Data = user;
            res.PageSize = param.PageSize;
            res.PageCurrent = param.PageCurrent;
            res.TotalCount = count;
            res.PageCount =(int)Math.Ceiling((double)count / (double)param.PageSize);
            if (!res.Success)
            {
                res.Message = "查询用户失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}执行失败！", param);
            }
            return res;
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Res<bool> UpdateUserInfo(UserInfoUpdateParam param)
        {
            var user = _repository.DbContext.BcUserinfos.FirstOrDefault(x => x.UserId.Equals(param.UserId));            
            if (user == null)
            {
                Res<bool> res = new Res<bool>(false);
                res.Data = false;
                res.Message = "未找到要修改的对象！";
                return res;
            }
            else
            {
                mapper.Map(param, user);
                Res<bool> res = new Res<bool>(_repository.SaveChanges() > 0);
                if (!res.Success)
                {
                    res.Message = "修改用户失败！";
                    logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}新增失败！", param);
                }
                return res;
            }
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Res<bool> UpdateUserInfoPassword(UserInfoUpdatePasswordParam param)
        {
            var user = _repository.DbContext.BcUserinfos.FirstOrDefault(x => x.UserId.Equals(param.UserId));
            if (user == null)
            {
                Res<bool> res = new Res<bool>(false);
                res.Data = false;
                res.Message = "未找到要修改的用户！";
                return res;
            }
            else
            {
                user.Password = param.Password.GetMd5();
                Res<bool> res = new Res<bool>(_repository.DbContext.SaveChanges() > 0);
                if (!res.Success)
                {
                    res.Message = "修改用户密码失败！";
                    logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}新增失败！", param);
                }
                return res;
            }
        }
    }
}
