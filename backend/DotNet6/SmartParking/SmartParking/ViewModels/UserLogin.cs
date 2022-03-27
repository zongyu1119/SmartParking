namespace SmartParking.ViewModels
{
    /// <summary>
    /// 登录用户对象
    /// </summary>
    public class UserLogin
    {
        public UserLogin(string userNmae,string password)
        {
            UserName = userNmae;
            Password = password;
        }
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 返回的地址
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
