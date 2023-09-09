using Microsoft.AspNetCore.Http;
using System.Security.Principal;
using zy.webcore.Share.Yitter.Services;

namespace zy.webcore.Usr.Application.Services
{
    /// <summary>
    /// 登录认证
    /// </summary>
    public class AccountService : BaseAccountService, IAccountService
    {
        private readonly ILogger<AccountService> logger;
        private readonly IUserService service;
        private const string _userCaptchCacheKeyPrefix = CacheKeyConsts.userCaptchCacheKeyPrefix;
        private bool _captchEnable;
        private List<string> _disableCaptchAccount;
        private readonly UserContext _userContext;
        private readonly IEfRepository<SysUser> _reposiory;
        private readonly IEfRepository<SysRoleMenu> _roleMenuReposiory;
        private readonly IEfRepository<SysUserRole> _userRoleReposiory;
        private readonly IEfRepository<SysMenu> _menuReposiory;
        private readonly IEfRepository<SysJob> _jobReposiory;
        private readonly IEfRepository<SysUserJob> _userJobReposiory;
        /// <summary>
        /// JWT认证
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        /// <param name="_service"></param>
        public AccountService(IConfiguration configuration, 
            ILogger<AccountService> _logger,
            IUserService _service,
            ICacheService cacheService,
            UserContext userContext,
            IEfRepository<SysUser> reposiory,
            IEfRepository<SysRoleMenu> roleMenuReposiory,
            IEfRepository<SysUserRole> userRoleReposiory,
            IEfRepository<SysMenu> menuReposiory,
            IEfRepository<SysJob> jobReposiory,
            IEfRepository<SysUserJob> userJobReposiory)
            : base(cacheService, configuration)
        {
            this.logger = _logger;
            this.service = _service;
            this._captchEnable = configuration.GetValue<bool>("Login:Captch:Enable");
            this._disableCaptchAccount = configuration.GetSection("Login:Captch:DisableAccount").Get<List<string>>();
            _userContext = userContext;
            _reposiory = reposiory;
            _roleMenuReposiory = roleMenuReposiory;
            _userRoleReposiory = userRoleReposiory;
            _menuReposiory = menuReposiory;
            _jobReposiory = jobReposiory;
            _userJobReposiory = userJobReposiory;
        }
        /// <summary>
        /// 获得JWTBear
        /// </summary>
        /// <param name="user"></param>
        /// <param name="clientType"></param>
        /// <returns></returns>
        public async Task<AppSrvResult<LoginResDto>> LoginAsync(AccountLoginDto user, ClientTypeEnum clientType = ClientTypeEnum.PC)
        {
            if (_captchEnable && (!this._disableCaptchAccount.Contains(user.UserAccount)))
            {
                var captchCode = await _cacheService.GetAsync<string>($"{_userCaptchCacheKeyPrefix}:{user.CaptchId}");
                if (captchCode == null || captchCode.ToUpper() != user.CaptchCode.ToUpper())
                    return Problem<LoginResDto>(HttpStatusCode.BadRequest, "验证码不正确！");
            }
            var userRoleRep = _userRoleReposiory.GetAll();
            var roleMenuRep = _roleMenuReposiory.GetAll();
            var userInfo = await _reposiory.Where(x => x.Account == user.UserAccount)
                .Select(x => new
                {
                    x.Address,
                    x.Password,
                    x.Phone,
                    x.Sex,
                    UserId = x.Id,
                    x.UserIdCardNum,
                    UserName = x.UserName,
                    Account = x.Account,
                    RoleIds = userRoleRep.Where(s => s.UserId == x.Id).Select(s => s.Id).ToList(),
                }).FirstOrDefaultAsync();
            if (userInfo == null)
            {
                logger.LogError("登录用户不存在！");
                return Problem<LoginResDto>(HttpStatusCode.BadRequest, "登录用户不存在！");
            }
          
            var psd = RSAEncode.RSADecrypt(userInfo.Password);
            if (user.Password != psd)
            {
                logger.LogError("用户名或密码错误！");
                return Problem<LoginResDto>(HttpStatusCode.BadRequest, "用户名或密码错误！");
            }
            var menuList = await _menuReposiory
              .Where(x => roleMenuRep.Where(s => userInfo.RoleIds.Contains(s.RoleId)).Select(s => s.MenuId).Contains(x.Id)).ToListAsync();
            var MenuList = Mapper.Map<List<MenuOutputDto>>(menuList);
            var userJob = _userJobReposiory.GetAll();
            var jobName = await _jobReposiory
                .Where(s => s.Id == userJob.FirstOrDefault(x => x.UserId == userInfo.UserId && x.IsMainJob).JobId)
                .Select(x => x.JobName).FirstOrDefaultAsync();
            var userinfo = new UserInfo
            {
                Account = userInfo.Account,
                Address = userInfo.Address,
                JobName = jobName,
                MenuCodeList = menuList?.Select(x => x.MenuCode).ToList(),
                Phone = userInfo?.Phone,
                RoleIds = userInfo.RoleIds,
                Sex = userInfo.Sex,
                UserId = userInfo.UserId,
                UserIdCardNum = userInfo.UserIdCardNum,
                UserName = userInfo.UserName,
            };
             await base.GetJwtTokenAsync(userinfo, ClientTypeEnum.PC);
            return new LoginResDto
            {
                Token = $"Bearer {userinfo.Token}"
            };
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public async Task<AppSrvResult<CaptchOutputDto>> GetCaptchAsync()
        {
            var (code, bytes) = Captcha.CreateValidateGraphic(4, 100, 36);           
            var id = ZyIdGenerator.NextId();
            await _cacheService.SetAsync($"{_userCaptchCacheKeyPrefix}:{id}", code,30);
            return new CaptchOutputDto
            {
                CaptchId = id,
                CaptchBase64Str = Convert.ToBase64String(bytes)
            };
        }

        public async Task<AppSrvResult<UserDetailInfoDto>> GetVerifyInfoAsync()
        {
            if (_userContext == null || _userContext.Id == 0)
                return Problem<UserDetailInfoDto>(HttpStatusCode.BadRequest, "用户未登录！");
            var userDetailInfoModel = await service.GetUserDetailInfoAsync(_userContext.Account);
            return userDetailInfoModel;
        }
    }
}
