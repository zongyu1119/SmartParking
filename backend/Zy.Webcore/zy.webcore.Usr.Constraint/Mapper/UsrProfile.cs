using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Usr.Constraint.Dtos.User;
using zy.webcore.Usr.Repository.Entities;

namespace zy.webcore.Usr.Constraint.Mapper
{
    /// <summary>
    /// 映射
    /// </summary>
    public class UsrProfile:Profile
    { 
        /// <summary>
        /// 映射
        /// </summary>
        public UsrProfile()
        {
            CreateMap<SysUserinfo, UserOutputDto>();
            CreateMap<UserInputDto, SysUserinfo>();
        }
    }
}
