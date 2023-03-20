using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Usr.Constraint.Dtos.Role;

namespace zy.webcore.Usr.Constraint.Mapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<SysRole, RoleOutputDto>();
            CreateMap<SysRole, RoleInputDto>().ReverseMap();
        }
    }
}
