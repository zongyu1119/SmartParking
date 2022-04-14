using Autofac.Extras.DynamicProxy;
using Service.Comm;
using Service.Models;
using Service.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.IService
///  Name： IAuditService
///  Author: zy
///  Time:  2022-04-13 22:26:30
///  Version:  0.1
/// </summary>

namespace Service.IService
{
    /// <summary>
    /// 审计相关Service
    /// </summary>
    [Intercept(typeof(Comm.ServiceInterceptor))]
    public interface IAuditService
    {
        /// <summary>
        /// 获得模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Res<AuditModel> GetModel(int id);
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Res<List<AuditModel>> GetList(AuditQueryParam param);
        /// <summary>
        /// 获得分页列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ResPage<AuditModel> GetList(ParamPage<AuditQueryParam> param);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Res<bool> Add(AuditAddParam param);

    }
}
