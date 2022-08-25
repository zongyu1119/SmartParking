using AutoMapper;
using DataBaseHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class ServiceBase
    {
        /// <summary>
        /// 数据库资源
        /// </summary>
        protected  IEFRepository repository;
        /// <summary>
        /// 配置
        /// </summary>
        protected  IConfiguration configuration;
        /// <summary>
        /// 日志
        /// </summary>
        protected  ILogger<ServiceBase> logger;
        /// <summary>
        /// AutoMapper
        /// </summary>
        protected IMapper mapper;
        public ServiceBase(IConfiguration _configuration,
            ILogger<ServiceBase> _logger,
            IEFRepository _repository,IMapper _mapper)
        {
            this.configuration = _configuration;
            this.logger = _logger;
            this.repository = _repository;
            this.mapper = _mapper;
        }
    }
}
