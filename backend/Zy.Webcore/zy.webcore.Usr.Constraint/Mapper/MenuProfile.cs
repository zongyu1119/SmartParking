using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Usr.Constraint.Mapper
{
    public class MenuProfile: Profile
    {
        public MenuProfile()
        {
            CreateMap<SysMenu, MenuOutputDto>();
        }
    }
}
