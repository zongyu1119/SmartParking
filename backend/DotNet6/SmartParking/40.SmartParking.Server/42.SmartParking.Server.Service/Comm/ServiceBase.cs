/// <summary>
///  Namespace: Service.Comm
///  Name： ServiceBase
///  Author: zy
///  Time:  2022-04-03 16:09:30
///  Version:  0.1
/// </summary>

namespace Service.Comm
{
    /// <summary>
    /// 所有Service的基类
    /// </summary>
    public class ServiceBase<TEntity>
    {
       
        /// <summary>
        /// 配置
        /// </summary>
        protected  IConfiguration configuration;
        /// <summary>
        /// 日志
        /// </summary>
        protected  ILogger<ServiceBase<TEntity>> logger;
        /// <summary>
        /// AutoMapper
        /// </summary>
        protected IMapper mapper;
        public ServiceBase(IConfiguration _configuration
            ,ILogger<ServiceBase<TEntity>> _logger
            ,IMapper _mapper)
        {
            this.configuration = _configuration;
            this.logger = _logger;
            this.mapper = _mapper;
        }

    }
}
