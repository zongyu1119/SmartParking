using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Core
{
    public class UserContext
    {
        public long Id { get; set; }

        public long ExationId { get; set; }

        public string Account { get; set; } = string.Empty;


        public string Name { get; set; } = string.Empty;


        public long RoleId { get; set; }

        public long? DeptId { get; set; }

        public string Device { get; set; } = string.Empty;


        public string RemoteIpAddress { get; set; } = string.Empty;

    }
}
