using Microsoft.AspNetCore.Http;
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
            UserContext userContext)
            : base(cacheService, configuration)
        {
            this.logger = _logger;
            this.service = _service;
            this._captchEnable = configuration.GetValue<bool>("Login:Captch:Enable");
            this._disableCaptchAccount = configuration.GetSection("Login:Captch:DisableAccount").Get<List<string>>();
            _userContext = userContext;
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
            var userDetailInfoModel = await service.GetUserDetailInfoAsync(user.UserAccount);
            if (userDetailInfoModel == null)
            {
                logger.LogError("登录用户不存在！");
                return Problem<LoginResDto>(HttpStatusCode.BadRequest, "登录用户不存在！");
            }
            var psd = RSAEncode.RSADecrypt(userDetailInfoModel.Password);
            if (user.Password != psd)
            {
                logger.LogError("用户名或密码错误！");
                return Problem<LoginResDto>(HttpStatusCode.BadRequest, "用户名或密码错误！");
            }
            var userinfo = new UserInfo
            {
                Account = userDetailInfoModel.Account,
                Address = userDetailInfoModel.Address,
                JobName = userDetailInfoModel.JobName,
                MenuCodeList = userDetailInfoModel?.MenuList?.Select(x => x.MenuCode).ToList(),
                Phone = userDetailInfoModel?.Phone,
                RoleIds = userDetailInfoModel.RoleIds,
                Sex = userDetailInfoModel.Sex,
                UserId = userDetailInfoModel.UserId,
                UserIdCardNum = userDetailInfoModel.UserIdCardNum,
                UserName = userDetailInfoModel.UserName,
            };
             await base.GetJwtTokenAsync(userinfo, ClientTypeEnum.PC);
            return new LoginResDto
            {
                Token = $"Bearer {userinfo.Token}",
                UserInfo = userDetailInfoModel
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
