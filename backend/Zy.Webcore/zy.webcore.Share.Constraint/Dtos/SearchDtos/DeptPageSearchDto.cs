﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Constraint.Dtos.SearchDtos
{
    /// <summary>
    /// 名称分页查询参数
    /// </summary>
    public class DeptPageSearchDto : BasePageSearchDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public long? DeptId { get; set; }
    }
}
