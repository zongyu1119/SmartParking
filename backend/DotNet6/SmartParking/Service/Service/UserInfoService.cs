/// <summary>
///  Namespace: Service.Service
///  Name： UserInfoService
///  Author: zy
///  Time:  2022-04-02 23:10:33
///  Version:  0.1
/// </summary>

namespace Service.Service
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoService : ServiceBase,IUserInfoService
    {
        /// <summary>
        /// 实现依赖自动注入
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        /// <param name="_repository"></param>
        /// <param name="_mapper"></param>
        public UserInfoService(IConfiguration _configuration,
             ILogger<UserInfoService> _logger,
             IEFRepository _repository, IMapper _mapper) : base(_configuration,_logger,_repository,_mapper)
        {
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="param"></param>
        /// <param name="createByUserId"></param>
        /// <returns></returns>
        public Res<bool> AddUserInfo(UserInfoAddParam param)
        {
            var model=mapper.Map<BcUserinfo>(param);//使用AutoMapper
            model.CreatedTime = DateTime.Now;
            model.Revision = 1;
            repository.DbContext.BcUserinfos.Add(model);
            Res<bool> res = new Res<bool>(repository.DbContext.SaveChanges() > 0);
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
        public Res<bool> DeleteUserInfo(int id)
        {
            repository.DbContext.BcUserinfos.Remove(repository.DbContext.BcUserinfos.FirstOrDefault(x => x.UserId.Equals(id)));
            Res<bool> res = new Res<bool>(repository.DbContext.SaveChanges() > 0);
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
        public UserDetailInfoModel? GetUserDetailInfo(int id)
        {
            var user = repository.DbContext.BcUserinfos.Where(x => x.UserId.Equals(id))
                .Select(x => new UserDetailInfoModel()
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
                    Role = repository.DbContext.BcRoles.Where(r => r.RoleId.Equals(x.RoleId)).Select(r => new RoleModel
                    {
                        RoleId = r.RoleId,
                        RoleName = r.RoleName,
                    }).FirstOrDefault(),
                    RolePowers = repository.DbContext.BcRolePowers.Where(p => p.RoleId.Equals(x.RoleId))
                    .Select(rp => new RolePowerModel
                    {
                        RoleId = rp.RoleId,
                        PowerId = rp.PowerId,
                        IsDelete = rp.IsDelete,
                        IsInsert = rp.IsInsert,
                        IsSelect = rp.IsSelect,
                        IsUpdate = rp.IsUpdate,
                        Power = repository.DbContext.BcPowers.Where(p => p.PowerId.Equals(rp.PowerId))
                                   .Select(p => new PowerModel
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
        public UserDetailInfoModel? GetUserDetailInfo(string userName)
        {
            var user = repository.DbContext.BcUserinfos.Where(x => x.UserName.Equals(userName))
                .Select(x => new UserDetailInfoModel()
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
                    Role = repository.DbContext.BcRoles.Where(r => r.RoleId.Equals(x.RoleId)).Select(r => new RoleModel
                    {
                        RoleId = r.RoleId,
                        RoleName = r.RoleName,
                    }).FirstOrDefault(),
                    RolePowers = repository.DbContext.BcRolePowers.Where(p => p.RoleId.Equals(x.RoleId))
                    .Select(rp => new RolePowerModel
                    {
                        RoleId = rp.RoleId,
                        PowerId = rp.PowerId,
                        IsDelete = rp.IsDelete,
                        IsInsert = rp.IsInsert,
                        IsSelect = rp.IsSelect,
                        IsUpdate = rp.IsUpdate,
                        Power = repository.DbContext.BcPowers.Where(p => p.PowerId.Equals(rp.PowerId))
                                   .Select(p => new PowerModel
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
        public Res<UserDetailInfoModel> GetUserDetailInfoToView(int id)
        {
            var user = repository.DbContext.BcUserinfos.Where(x => x.UserId.Equals(id))
               .Select(x => new UserDetailInfoModel()
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
                   Role = repository.DbContext.BcRoles.Where(r => r.RoleId.Equals(x.RoleId)).Select(r => new RoleModel
                   {
                       RoleId = r.RoleId,
                       RoleName = r.RoleName,
                   }).FirstOrDefault(),
                   RolePowers = repository.DbContext.BcRolePowers.Where(p => p.RoleId.Equals(x.RoleId))
                   .Select(rp => new RolePowerModel
                   {
                       RoleId = rp.RoleId,
                       PowerId = rp.PowerId,
                       IsDelete = rp.IsDelete,
                       IsInsert = rp.IsInsert,
                       IsSelect = rp.IsSelect,
                       IsUpdate = rp.IsUpdate,
                       Power = repository.DbContext.BcPowers.Where(p => p.PowerId.Equals(rp.PowerId))
                                  .Select(p => new PowerModel
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
            Res<UserDetailInfoModel> res = new(user!=null);
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
        public Res<UserInfo> GetUserInfo(int id)
        {
            var user = repository.DbContext.BcUserinfos.Where(x => x.UserId.Equals(id))
             .Select(x => new UserInfo()
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
                 RoleName= repository.DbContext.BcRoles.Where(r => r.RoleId.Equals(x.RoleId)).FirstOrDefault().RoleName

             }).FirstOrDefault();
            Res<UserInfo> res = new(user != null);
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
        public Res<List<UserInfo>> GetUserInfoList(UserInfoQueryParam param)
        {
            var resDb = repository.DbContext.BcUserinfos.Where(x=>x.TenantId==param.TenantId);
            if (param.UserName != null)
            {
                resDb.Where(x => x.UserName.Contains(param.UserName));
            }
            if (param.RoleId != null)
            {
                resDb.Where(x => x.RoleId.Equals(param.RoleId));
            }
            var user=resDb.Select(x => new UserInfo()
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
                  RoleName=repository.DbContext.BcRoles.Where(r=>r.RoleId.Equals(x.RoleId)).FirstOrDefault().RoleName
             }).ToList();
            Res<List<UserInfo>> res = new(user != null);
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
        public ResPage<UserInfo> GetUserInfoList(ParamPage<UserInfoQueryParam> param)
        {
            var resDb = repository.DbContext.BcUserinfos.Where(x => x.TenantId.Equals(param.Param.TenantId));
            if (param.Param.UserName != null)
            {
                resDb.Where(x => x.UserName.Contains(param.Param.UserName));
            }
            if (param.Param.RoleId != null)
            {
                resDb.Where(x => x.RoleId.Equals(param.Param.RoleId));
            }
            int count=resDb.Count();
            var user = resDb.Select(x => new UserInfo()
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
                RoleName = repository.DbContext.BcRoles.Where(r => r.RoleId.Equals(x.RoleId)).FirstOrDefault().RoleName
            }).Skip(param.PageCurrent * param.PageSize).Take(param.PageSize).ToList();
            ResPage<UserInfo> res = new(user != null);
            res.Data = user;
            res.PageSize = param.PageSize;
            res.PageCurrent = param.PageCurrent;
            res.TotalCount = count;
            res.PageCount =(int)Math.Ceiling((double)count / (double)param.PageSize);
            if (!res.Success)
            {
                res.Message = "查询用户失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}执行失败！", param);
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
            var user = repository.DbContext.BcUserinfos.FirstOrDefault(x => x.UserId.Equals(param.UserId));            
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
                Res<bool> res = new Res<bool>(repository.DbContext.SaveChanges() > 0);
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
            var user = repository.DbContext.BcUserinfos.FirstOrDefault(x => x.UserId.Equals(param.UserId));
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
                Res<bool> res = new Res<bool>(repository.DbContext.SaveChanges() > 0);
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
