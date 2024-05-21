using AutoMapper;
using System.Net;

namespace Zy.User.Services.AppServices
{
    /// <summary>
    /// 用户表增删改服务
    /// </summary>
    public class SysUserService(IEfRepository<SysUser> repository) : AbstractService, ISysUserService
    {
        #region 新增用户表
        /// <summary>
        /// 新增用户表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ZyResult<bool>> AddAsync(SysUserInputDto dto)
        {
            var model =Mapper.Map<SysUser>(dto);
            model.Id = ZyIdGenerator.NextId();
            return await repository.InsertAsync(model) > 0;
        }
        #endregion
        #region  用户表修改
        /// <summary>
        ///  用户表修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<ZyResult<bool>> UpdateAsync(long id, SysUserInputDto dto)
        {
            var model = await repository.FindAsync(id);
            var newModel = Mapper.Map(dto, model);
            await repository.UpdateAsync(newModel, UpdatingProps<SysUser>(
                    x => x.Id,
                    x => x.Name,
                    x => x.Account,
                    x => x.Password,
                    x => x.IsOnline,
                    x => x.ConnectionId,
                    x => x.Address,
                    x => x.DataScope,
                    x => x.UserIdCard,
                    x => x.Phone,
                    x => x.Email,
                    x => x.Photo,
                    x => x.Sex
                ));
            return true;
        }
        #endregion

        #region 删除用户表
        /// <summary>
        /// 删除用户表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ZyResult<bool>> DeleteAsync(long id)
        {
            var model = await repository.FindAsync(id);
            if (model == null)
                return Problem<bool>(HttpStatusCode.BadRequest, "无数据");
            model.IsDeleted = true;
            await repository.UpdateAsync(model, UpdatingProps<SysUser>(
               s => s.IsDeleted));
            return await repository.DeleteAsync(id) > 0;
        }
        #endregion
        #region 批量删除删除用户表
        /// <summary>
        /// 删除用户表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ZyResult<bool>> DeleteRangeAsync(List<long> ids)
        {
            var models = await repository.CountAsync(x => ids.Contains(x.Id));
            if (models==0)
                return Problem<bool>(HttpStatusCode.BadRequest, "无数据");
           
            return await repository.DeleteRangeAsync(ids)>0;
        }
        #endregion
    }
}
