namespace SmartParking.ViewModels
{
    /// <summary>
    /// 登录用户对象
    /// </summary>
    public class UserLoginArgs
    {
       
        /// <summary>
        /// 重写ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"UserName:{UserName};Password:{Password}";
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
