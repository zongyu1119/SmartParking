using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseHelper
{
    /// <summary>
    /// 一些常量
    /// </summary>
    public static class RepositoryConsts
    {
        public static readonly string MYCAT_ROUTE_TO_MASTER = "#mycat:db_type=master";
        /// <summary>
        /// 强制选择主库
        /// </summary>
        public static readonly string MAXSCALE_ROUTE_TO_MASTER = "maxscale route to master";
        /// <summary>
        /// 强制选择查询库
        /// </summary>
        public static readonly string MAXSCALE_ROUTE_TO_SLAVE="maxscale route to slave";
    }
}
