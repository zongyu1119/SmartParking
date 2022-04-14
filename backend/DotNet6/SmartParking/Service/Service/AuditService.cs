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

        public Res<List<AuditModel>> GetList(AuditQueryParam param)
        {
            throw new NotImplementedException();
        }

        public ResPage<AuditModel> GetList(ParamPage<AuditQueryParam> param)
        {
            throw new NotImplementedException();
        }

        public Res<AuditModel> GetModel(int id)
        {
            throw new NotImplementedException();
        }
    }
}
