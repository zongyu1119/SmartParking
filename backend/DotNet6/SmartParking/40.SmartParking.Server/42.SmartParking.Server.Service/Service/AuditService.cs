

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
    [AppService(Lifetime = ServiceLifetime.Scoped)]
    public class AuditService : ServiceBase<Audit>, IAuditService
    {
        private readonly IEFRepository<Userinfo> _userRepository;
        private readonly IEFRepository<Audit> _repository;
        /// <summary>
        /// 实现依赖自动注入
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        /// <param name="repository"></param>
        /// <param name="_mapper"></param>
        public AuditService(IConfiguration _configuration,
             ILogger<AuditService> _logger,
             IEFRepository<Audit> repository,
             IMapper _mapper,
             IEFRepository<Userinfo> userRepository) 
            : base(_configuration, _logger, _mapper)
        {
            _userRepository = userRepository;
            _repository = repository;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Res<bool>> Add(AuditAddParam param)
        {
            var model = mapper.Map<Audit>(param);//使用AutoMapper
            model.CreatedTime = DateTime.Now;
            model.Revision = 1;
            return new Res<bool>(await _repository.InsertAsync(model) > 0);
        }
        /// <summary>
        /// 获得不分页的列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<Res<List<AuditOutputDto>>> GetList(AuditQueryParam param)
        {
            var whereCondition = getExpression(param);
            var resDb = getIqueryable(whereCondition);
            var list =await  resDb
                .WhereIf(param.UserName.IsNotNullOrWhiteSpace(), x => x.UserName.Contains(param.UserName))
                .ToListAsync();
          
            Res<List<AuditOutputDto>> res = new(list != null);
            res.Data = list.ToList();
            if (!res.Success)
            {
                res.Message = "查询失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}执行失败！", param);
            }
            return res;
        }
        /// <summary>
        /// 获得分页的列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ResPage<AuditOutputDto>> GetList(ParamPage<AuditQueryParam> param)
        {
            var whereCondition = getExpression(param.Param);
            var resDb = getIqueryable(whereCondition);
            resDb = resDb
                .WhereIf(param.Param.UserName.IsNotNullOrWhiteSpace(), x => x.UserName.Contains(param.Param.UserName))
                .Skip(param.PageCurrent * param.PageSize).Take(param.PageSize);
            int count = resDb.Count();
            var list  = await resDb.Skip(param.PageCurrent * param.PageSize).Take(param.PageSize).ToListAsync();       
            ResPage<AuditOutputDto> res = new(list!=null);
            res.Data =  list.ToList();
            res.PageSize = param.PageSize;
            res.PageCurrent = param.PageCurrent;
            res.TotalCount = count;
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
        public async Task<Res<AuditOutputDto>> GetModel(long Id)
        {
            var resDb = getIqueryable(ExpressionCreator.New<Audit>(x => x.Id == Id));
            var user = await resDb.FirstOrDefaultAsync();
            Res<AuditOutputDto> res = new(user != null);
            res.Data = user;
            if (!res.Success)
            {
                res.Message = "查询失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}执行失败！", Id);
            }
            return res;
        }
        /// <summary>
        /// 查询条件拼接
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private Expression<Func<Audit, bool>> getExpression(AuditQueryParam param)
        {
            var whereCondition = ExpressionCreator.New<Audit>(x => x.TenantId == param.TenantId);
            whereCondition = whereCondition.AndIf(param.Type != null, x => x.Type == param.Type)
                .AndIf(param.UserId != null, x => x.CreatedBy == param.UserId)
                .AndIf(param.ActionNmae.IsNotNullOrWhiteSpace(), x => x.ActionNmae == param.ActionNmae);
            return whereCondition;
        }
        /// <summary>
        /// 获得查询对象
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private IQueryable<AuditOutputDto> getIqueryable(Expression<Func<Audit,bool>> expression)
        {           
            var resDb = from audit in _repository.SmartparkingContext.Audits.WhereIf(expression!=null,expression)
                        join user in _repository.SmartparkingContext.Userinfos
                        on audit.CreatedBy equals user.Id
                        select new AuditOutputDto()
                        {
                            ActionNmae = audit.ActionNmae,
                            CreateTime = audit.CreatedTime,
                            Description = audit.Description,
                            Id = audit.Id,
                            Type = audit.Type,
                            UserId = audit.CreatedBy,
                            UserName = user.UserNameRel
                        };
            return resDb;
        }
    }
}
