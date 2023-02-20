using MySql.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.share.Repository.IRepositories
{
    public class MySqlDbContext : SysDbContext
    {
        public MySqlDbContext(
            DbContextOptions options,
            IEntityInfo entityInfo)
            : base(options, entityInfo)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //System.Diagnostics.Debugger.Launch();
            modelBuilder.HasCharSet("utf8mb4 ");
            base.OnModelCreating(modelBuilder);
        }
    }
}
