
namespace zy.webcore.Usr.Constraint.Mapper
{
    /// <summary>
    /// 映射
    /// </summary>
    public class UsrProfile:Profile
    { 
        /// <summary>
        /// 映射
        /// </summary>
        public UsrProfile()
        {
            CreateMap<SysUser, UserOutputDto>();
            CreateMap<UserInputDto, SysUser>();
        }
    }
}
