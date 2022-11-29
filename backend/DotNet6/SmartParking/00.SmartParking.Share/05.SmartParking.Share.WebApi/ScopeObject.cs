using Microsoft.AspNetCore.Http;
using SmartParking.Share.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.WebApi
{
    public  class ScopeObject
    {
        public static UserContext GetUserContext()
        {
            return new UserContext();
        }
    }
}
