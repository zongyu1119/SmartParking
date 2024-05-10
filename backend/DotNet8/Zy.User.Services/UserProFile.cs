using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.User.Services
{
    public class UserProFile:Profile
    {
        public UserProFile() {
            // 用户表
            //CreateMap<SysUser, SysUserOutputDto>();
            //CreateMap<SysUser, SysUserExportDto>();
            CreateMap<SysUserInputDto, SysUser>();
           // CreateMap<SysUserImportDto, SysUser>();
        }
       
    }
}
