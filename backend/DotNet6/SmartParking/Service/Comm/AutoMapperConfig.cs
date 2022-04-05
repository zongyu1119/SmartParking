using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseHelper.Entities;
using Service.Models;
using Service.Params;
using Common.Str;

/// <summary>
///  Namespace: Service.Comm
///  Name： AutoMapperConfig
///  Author: zy
///  Time:  2022-04-04 13:31:49
///  Version:  0.1
/// </summary>

namespace Service.Comm
{
    /// <summary>
    /// AutoMapper配置
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// AutoMap配置
        /// </summary>
        public AutoMapperConfig()
        {
            CreateMap<BcUserinfo, UserInfo>();
            CreateMap<UserInfoAddParam, BcUserinfo>().ForMember(d=>d.Password,o=>o.MapFrom(a=>a.Password.GetMd5()));
            CreateMap<UserInfoUpdateParam, BcUserinfo>();
        }
    }
}
