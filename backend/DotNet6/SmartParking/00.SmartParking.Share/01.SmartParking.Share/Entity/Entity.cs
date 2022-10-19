﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public interface IEntity
    {
        public long Id { get; set; }
        /// <summary>
        /// 租户号
        /// </summary>
        public long? TenantId { get; set; }
    }
    public class Entity : IEntity
    {
        public long Id { get; set; }
        /// <summary>
        /// 租户号
        /// </summary>
        public long? TenantId { get; set; }
    }
}
