using Microsoft.EntityFrameworkCore;
using Zy.Message.Constraint.Dtos;
using Zy.Message.Repository.Entitys;
using Zy.Shared.Repository.Contexts;
using Zy.Shared.Extensions;
using Zy.Message.Constraint.IServices;
using Zy.Shared.Constraint.Dtos;

namespace Zy.Message.WebApi.Services
{
    public class UserService(IEfRepository<User> userRepository,
         IEfRepository<GroupUser> groupRepository,
          IEfRepository<ChatGroup> chatGroupRepository,
           IEfRepository<UserRelation> userRelRepository,
        ZyUserContext httpContext) : IUserService
    {
        /// <summary>
        /// 获得所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<ZyResult<List<UserOutputDto>>> GetList()
        {
            var list = await userRepository.GetAll().Select(x => new UserOutputDto
            {
                Account = x.Account,
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
            return new ZyResult<List<UserOutputDto>>(list);
        }
        /// <summary>
        /// 获得聊天组
        /// </summary>
        /// <returns></returns>
        public async Task<ZyResult<List<GroupOutputDto>>> GetChatGroupAsync()
        {
            var id = httpContext.Id;
            var resDate = await chatGroupRepository
                .Where(x => groupRepository.Where(s => s.UserId == id).Select(s => s.GroupId).Distinct().Contains(x.Id))
                .Select(x => new GroupOutputDto
                {
                    Id = x.Id,
                    IsGroup = x.IsGroup,
                    Name = x.GroupName,
                    Users = userRepository.Where(u => groupRepository.Where(s => s.GroupId == x.Id).Select(s => s.UserId).Distinct().Contains(u.Id))
                        .Select(u => new UserOutputDto
                        {
                            Account = u.Account,
                            Id = u.Id,
                            Name = u.Name,
                            IsOnline = u.IsOnline
                        }).ToList()
                })
                .ToListAsync();
            return new ZyResult<List<GroupOutputDto>>(resDate);
        }
        /// <summary>
        /// 查询我的好友
        /// </summary>
        /// <param name="searchVal"></param>
        /// <returns></returns>
        public async Task<ZyResult<List<UserOutputDto>>> GetFirendAsync(string? searchVal)
        {
            var listQueryable = userRepository
                .Where(x => userRelRepository.Where(s => s.UserId == httpContext.Id).Select(s => s.FirendUserId).Distinct().Contains(x.Id));
            if (searchVal.IsNotNullOrWhiteSpace())
            {
                listQueryable = listQueryable.Where(x => x.Name.Contains(searchVal) || x.Account.Contains(searchVal));
            }
            var list = await listQueryable
                .Select(x => new UserOutputDto
                {
                    Account = x.Account,
                    Name = x.Name,
                    Id = x.Id,
                    IsOnline = x.IsOnline
                }).ToListAsync();
            return new ZyResult<List<UserOutputDto>>(list);
        }
    }
}
