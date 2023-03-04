

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using zy.webcore.share.Repository.IRepositories;
using zy.webcore.Share.Application.Service;
using zy.webcore.Share.Cache.Services;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.Extensions;
using zy.webcore.Share.Redis.CacheProvider;
using zy.webcore.Usr.Constraint.Dtos.User;
using zy.webcore.Usr.Repository.Entities;

namespace zy.webcore.Usr.Application.Services
{
    public class UserService : AbstractAppService, IUserService
    {
        private readonly IEfRepository<SysUserinfo> _reposiory;
        private readonly ICacheService _cacheService;
        public UserService(IEfRepository<SysUserinfo> repository,
            ICacheService cacheService)
        {
            _reposiory = repository;
            _cacheService = cacheService;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppSrvResult<bool>> AddAsync(UserInputDto dto)
        {
            var model = Mapper.Map<SysUserinfo>(dto);
            model.Id=IdGenerator.NextId();
            return await _reposiory.InsertAsync(model)>0;
        }

        public async Task<AppSrvResult<object>> GetCacheAsync(string key)
        {
           return await _cacheService.GetAsync<string>(key);
        }

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppSrvResult<List<UserOutputDto>>> GetListAsync(UserSearchDto dto)
        {
            var expression = ExpressionCreator.New<SysUserinfo>()
                .AndIf(dto.Name.IsNotNullOrWhiteSpace(),x=>x.UserName.Contains(dto.Name));
            var res = await _reposiory.Where(expression)
                .ToListAsync();
            return Mapper.Map<List<UserOutputDto>>(res);
        }

        public Task<UserDetailInfoDto> GetUserDetailInfoAsync(string account)
        {
            throw new NotImplementedException();
        }

        public async Task<AppSrvResult<bool>> SetCacheAsync(string key,string value)
        {
             await _cacheService.SetAsync(key,value,500);
            return true;
        }
    }
}
