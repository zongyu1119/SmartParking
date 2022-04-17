using AutoMapper;
using Microsoft.Extensions.Configuration;
using DataBaseHelper;
using Microsoft.Extensions.Logging;
using Service.Comm;
using Service.Models;
using Service.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseHelper.Entities;

/// <summary>
///  Namespace: Service.Service
///  Name： AuditService
///  Author: zy
///  Time:  2022-04-14 22:40:02
///  Version:  0.1
/// </summary>

namespace Service.Service
{
    /// <summary>
    /// 审计service
    /// </summary>
    public class AuditService : ServiceBase, IService.IAuditService
    {
        /// <summary>
        /// 实现依赖自动注入
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        /// <param name="_repository"></param>
        /// <param name="_mapper"></param>
        public AuditService(IConfiguration _configuration,
             ILogger<AuditService> _logger,
             IRepository _repository, IMapper _mapper) : base(_configuration, _logger, _repository, _mapper)
        {
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Res<bool> Add(AuditAddParam param)
        {
            var model = mapper.Map<OpAudit>(param);//使用AutoMapper
            model.CreatedTime = DateTime.Now;
            model.Revision = 1;
            repository.DbContext.OpAudits.Add(model);
            return new Res<bool>(repository.DbContext.SaveChanges()>0);
        }
        /// <summary>
        /// 获得不分页的列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Res<List<AuditModel>> GetList(AuditQueryParam param)
        {
            var resDb = repository.DbContext.OpAudits.Where(x => x.TenantId.Equals(param.TenantId));

            if (param.Type != null)
            {
                resDb.Where(x => x.Type.Equals(param.Type));
            }
            if (param.UserId != null)
            {
                resDb.Where(x => x.CreatedBy.Equals(param.UserId));
            }
            if (param.ActionNmae != null)
            {
                resDb.Where(x => x.ActionNmae.Contains(param.ActionNmae));
            }
            var list = resDb.Select(x => new AuditModel()
            {
                UserId = x.CreatedBy,
                Id = x.Id,
                ActionNmae = x.ActionNmae,
                CreateTime = x.CreatedTime,
                Description = x.Description,
                Type = x.Type,
                UserName = repository.DbContext.BcUserinfos.FirstOrDefault(u => u.UserId == x.CreatedBy).UserNameRel,

            });
            if (param.ActionNmae != null)
            {
                list = list.Where(x => x.UserName.Contains(param.UserName));
            }
            Res<List<AuditModel>> res = new(list != null);
            res.Data = list.ToList();
            if (!res.Success)
            {
                res.Message = "查询失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}执行失败！", param);
            }
            return res;
        }
        /// <summary>
        /// 获得分页的列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ResPage<AuditModel> GetList(ParamPage<AuditQueryParam> param)
        {
            var resDb = repository.DbContext.OpAudits.Where(x => x.TenantId.Equals(param.Param.TenantId));
          
            if (param.Param.Type != null)
            {
                resDb.Where(x => x.Type.Equals(param.Param.Type));
            }
            if (param.Param.UserId != null)
            {
                resDb.Where(x => x.CreatedBy.Equals(param.Param.UserId));
            }
            if (param.Param.ActionNmae != null)
            {
                resDb.Where(x => x.ActionNmae.Contains(param.Param.ActionNmae));
            }           
            var list = resDb.Select(x => new AuditModel()
            {
                UserId = x.CreatedBy,
                Id = x.Id,
                ActionNmae = x.ActionNmae,
                CreateTime = x.CreatedTime,
                Description = x.Description,
                Type = x.Type,
                UserName = repository.DbContext.BcUserinfos.FirstOrDefault(u => u.UserId == x.CreatedBy).UserNameRel,

            });
            if (param.Param.ActionNmae != null)
            {
                list = list.Where(x => x.UserName.Contains(param.Param.UserName));
            }
            int count = list.Count();
            list = list.Skip(param.PageCurrent * param.PageSize).Take(param.PageSize);       
            ResPage<AuditModel> res = new(list!=null);
            res.Data = list.ToList();
            res.PageSize = param.PageSize;
            res.PageCurrent = param.PageCurrent;
            res.TotalCount = count;
            res.PageCount = (int)Math.Ceiling((double)count / (double)param.PageSize);
            if (!res.Success)
            {
                res.Message = "查询失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}执行失败！", param);
            }
            return res;
        }
        /// <summary>
        /// 获得单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Res<AuditModel> GetModel(int id)
        {
            var user = repository.DbContext.OpAudits.Where(x => x.Id.Equals(id))
             .Select(x => new AuditModel()
             {
                 UserId = x.CreatedBy,
                 Id = x.Id,
                 ActionNmae = x.ActionNmae,
                 CreateTime = x.CreatedTime,
                 Description = x.Description,
                 Type = x.Type,
                 UserName = repository.DbContext.BcUserinfos.FirstOrDefault(u => u.UserId == x.CreatedBy).UserNameRel,

             }).FirstOrDefault();
            Res<AuditModel> res = new(user != null);
            res.Data = user;
            if (!res.Success)
            {
                res.Message = "查询失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}执行失败！", id);
            }
            return res;
        }
    }
}
