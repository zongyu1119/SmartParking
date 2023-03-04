using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Constraint.Dtos;

namespace zy.webcore.Usr.Constraint.Dtos.User
{
    public class UserSearchDto:BasePageSearchDto
    {
        public string? Name { get; set; }
    }
}
