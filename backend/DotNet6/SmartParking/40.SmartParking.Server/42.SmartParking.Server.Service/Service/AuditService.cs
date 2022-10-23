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
        public async Task<ResDto<bool>> CreateAsync(AuditCreateDto param)
        {
            var model = mapper.Map<Audit>(param);//使用AutoMapper
            model.CreatedTime = DateTime.Now;
            model.Revision = 1;
            return new ResDto<bool>(await _repository.InsertAsync(model) > 0);
        }
        /// <summary>
        /// 获得不分页的列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ResDto<List<AuditOutputDto>>> GetListAsync(AuditPageSearchDto dto)
        {
            var whereCondition = getExpression(dto);
            var resDb = getIqueryable(whereCondition);
            var list =await  resDb
                .WhereIf(dto.UserName.IsNotNullOrWhiteSpace(), x => x.UserName.Contains(dto.UserName))
                .ToListAsync();
          
            var res = new ResDto<List<AuditOutputDto>>(list);
            res.Data = list.ToList();
            if (!res.Success)
            {
                res.Message = "查询失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}执行失败！", dto);
            }
            return res;
        }
        /// <summary>
        /// 获得分页的列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ResPageDto<AuditOutputDto>> GetPageListAsync(AuditPageSearchDto dto)
        {
            var whereCondition = getExpression(dto);
            var resDb = getIqueryable(whereCondition);
            resDb = resDb
                .WhereIf(dto.UserName.IsNotNullOrWhiteSpace(), x => x.UserName.Contains(dto.UserName))
                .Skip(dto.Index * dto.PageSize).Take(dto.PageSize);
            int count = resDb.Count();
            var list  = await resDb.Skip(dto.Index * dto.PageSize).Take(dto.PageSize).ToListAsync();       
            var res = new ResPageDto<AuditOutputDto>(list);
            res.Data =  list.ToList();
            res.PageSize = dto.PageSize;
            res.PageCurrent = dto.Index;
            res.TotalCount = count;
            if (!res.Success)
            {
                res.Message = "查询失败！";
                logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name}执行失败！", dto);
            }
            return res;
        }
        /// <summary>
        /// 获得单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResDto<AuditOutputDto>> GetModelAsync(long Id)
        {
            var resDb = getIqueryable(ExpressionCreator.New<Audit>(x => x.Id == Id));
            var user = await resDb.FirstOrDefaultAsync();
            var res = new ResDto<AuditOutputDto>(user);
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
        private Expression<Func<Audit, bool>> getExpression(AuditPageSearchDto param)
        {
            var whereCondition = ExpressionCreator.New<Audit>(x => true);
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
            var UserRes = _userRepository.GetAll();
            var resDb = from audit in _repository.Where(expression)
                        join user in UserRes
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
