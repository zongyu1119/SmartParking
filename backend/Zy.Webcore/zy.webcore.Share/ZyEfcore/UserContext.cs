﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.ZyEfcore
{
    public class UserContext
    {
        public long Id { get; set; }
        public long ExationId { get; set; }
        public string Account { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<long> RoleIds { get; set; }
        public string Device { get; set; } = string.Empty;
        public string RemoteIpAddress { get; set; } = string.Empty;
        public long DeptId { get; set; }
        //TODO 数据权限
    }
}
