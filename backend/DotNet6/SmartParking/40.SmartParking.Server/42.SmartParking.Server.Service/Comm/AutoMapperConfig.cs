using AutoMapper;
using SmartParking.Server.Const.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
///  Namespace: Service.Comm
///  Name： AutoMapperConfig
///  Author: zy
///  Time:  2022-04-04 13:31:49
///  Version:  0.1
/// </summary>

namespace SmartParking.Server.Service.Comm
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
            CreateMap<Userinfo, UserOutputDto>();
            CreateMap<UserCreateDto, Userinfo>().ForMember(d=>d.Password,o=>o.MapFrom(a=>a.Password.GetMd5()));
            CreateMap<UserUpdateDto, Userinfo>();
            CreateMap<AuditCreateDto, Audit>().ForMember(d => d.CreatedTime,o=>o.MapFrom(a=>DateTime.Now));
        }
    }
}
