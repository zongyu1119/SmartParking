

using zy.webcore.Share.Application.Service;
using zy.webcore.Usr.Constraint.Dtos.User;

namespace zy.webcore.Usr.Application.Services
{
    public class UserService : AbstractAppService, IUserService
    {
        public UserService()
        {

        }

        public Task<UserOutputDto> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDetailInfoDto> GetUserDetailInfoAsync(string account)
        {
            throw new NotImplementedException();
        }
    }
}
