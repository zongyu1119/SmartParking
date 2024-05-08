namespace Zy.Shared.Constraint.Dtos { 

    /// <summary>
    /// 登录成功返回model
    /// </summary>
    public class JwtTokenResult
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        /// <summary>
        /// 过期时间(单位秒)
        /// </summary>
        public int ExpiresIn { get; set; }
        public LoginUserModel User { get; set; }
    }
    /// <summary>
    /// 用户信息
    /// </summary>
    public class LoginUserModel
    {
        public long UserId { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
    }
}
