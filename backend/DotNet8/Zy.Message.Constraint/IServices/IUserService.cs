using Zy.Message.Constraint.Dtos;
using Zy.Shared.Constraint.Dtos;
using Zy.Shared.Constraint.IServices;

namespace Zy.Message.Constraint.IServices
{
    public interface IUserService : IAppService
    {

        /// <summary>
        /// 获得所有用户
        /// </summary>
        /// <returns></returns>
        Task<ZyResult<List<UserOutputDto>>> GetList();
        /// <summary>
        /// 获得聊天组
        /// </summary>
        /// <returns></returns>
        Task<ZyResult<List<GroupOutputDto>>> GetChatGroupAsync();
        /// <summary>
        /// 查询我的好友
        /// </summary>
        /// <param name="searchVal"></param>
        /// <returns></returns>
        Task<ZyResult<List<UserOutputDto>>> GetFirendAsync(string? searchVal);
    }
}
