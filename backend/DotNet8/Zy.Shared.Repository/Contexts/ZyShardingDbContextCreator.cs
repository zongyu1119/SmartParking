using Microsoft.EntityFrameworkCore;
using ShardingCore;
using ShardingCore.Core.DbContextCreator;
using ShardingCore.Core.RuntimeContexts;
using ShardingCore.Core.ServiceProviders;
using ShardingCore.Sharding.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Constraint.Dtos;

namespace Zy.Shared.Repository.Contexts
{
    public class ZyShardingDbContextCreator : ActivatorDbContextCreator<ZyShardingCoreDbContext>, IDbContextCreator
    {
        public override DbContext CreateDbContext(DbContext mainDbContext, ShardingDbContextOptions shardingDbContextOptions)
        {
            var dbContext = new ZyShardingCoreDbContext((DbContextOptions<ZyShardingCoreDbContext>)shardingDbContextOptions.DbContextOptions, ((ZyShardingCoreDbContext)mainDbContext).ServiceProvider);
            Console.WriteLine("IsFrozen" + shardingDbContextOptions.DbContextOptions.IsFrozen);
            if (dbContext is IShardingTableDbContext shardingTableDbContext)
            {
                shardingTableDbContext.RouteTail = shardingDbContextOptions.RouteTail;
            }
            _ = dbContext.Model;
            return dbContext;
        }

        public override DbContext GetShellDbContext(IShardingProvider shardingProvider)
        {
            return shardingProvider.GetService<ZyShardingCoreDbContext>();
        }
    }
}
