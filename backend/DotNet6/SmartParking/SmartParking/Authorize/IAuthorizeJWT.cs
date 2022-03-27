namespace SmartParking.Authorize
{
    /// <summary>
    /// 用户验证相关接口
    /// </summary>
    public interface IAuthorizeJWT
    {
        /// <summary>
        /// 获得JWTBear
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string GetJWTBear(ViewModels.UserLogin user);
    }
}
