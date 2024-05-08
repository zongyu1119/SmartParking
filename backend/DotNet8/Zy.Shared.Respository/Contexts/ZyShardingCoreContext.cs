using ShardingCore.Sharding.Abstractions;
using ShardingCore.Sharding;
using ShardingCore.Core.VirtualRoutes.TableRoutes.RouteTails.Abstractions;
using Microsoft.EntityFrameworkCore;
using Zy.Shared.Entitys;
using Microsoft.Extensions.DependencyInjection;
using Zy.Shared.ServicesLocator;

namespace Zy.Shared.Respository.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public class ZyShardingCoreContext(DbContextOptions<ZyShardingCoreContext> options) 
        : AbstractShardingDbContext(options), IShardingTableDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           var entityInfo= ServiceLocator.Instance.GetService<IEntityInfo>();
            if (entityInfo != null)
                entityInfo.OnModelCreating(modelBuilder);
        }
        public IRouteTail RouteTail {  get; set; }
    }
}
