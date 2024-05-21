using ShardingCore.Sharding.Abstractions;
using ShardingCore.Sharding;
using ShardingCore.Core.VirtualRoutes.TableRoutes.RouteTails.Abstractions;
using Microsoft.EntityFrameworkCore;
using Zy.Shared.Entitys;
using Microsoft.Extensions.DependencyInjection;
using Zy.Shared.ServicesLocator;
using Zy.Shared.Constraint.Dtos;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection.Emit;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Reflection;
using Zy.Shared.Repository.Extensions;

namespace Zy.Shared.Repository.Contexts
{
    /// <summary>
    /// ShardingCore Dbcontext
    /// </summary>
    /// <param name="options"></param>
    public class ZyShardingCoreDbContext 
        : AbstractShardingDbContext, IShardingTableDbContext
    {
        public ZyShardingCoreDbContext(DbContextOptions<ZyShardingCoreDbContext> options
            ) : base(options)
        {
        }
        public ZyShardingCoreDbContext(DbContextOptions<ZyShardingCoreDbContext> options,
        IServiceProvider serviceProvider
            ):base(options)
        {
            ServiceProvider = serviceProvider;
        }
        public IServiceProvider ServiceProvider { get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeleted).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }
            var entityInfo= ServiceLocator.Instance.GetService<IEntityInfo>();
            if (entityInfo != null)
                entityInfo.OnModelCreating(modelBuilder);
        }
        public IRouteTail RouteTail {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }
        /// <summary>
        /// 保存更改
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var userContext=ServiceProvider.GetService<ZyUserContext>();
            foreach (var entry in ChangeTracker.Entries<IAuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateBy = userContext?.Id??0;
                        entry.Entity.CreateTime = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifyBy = userContext?.Id ?? 0;
                        entry.Entity.ModifyTime = DateTime.Now;
                        break;
                }
            }
            var changedEntities = ChangeTracker.Entries<Entity>().Count();
            //没有自动开启事务的情况下,保证主从表插入，主从表更新开启事务。
            var isManualTransaction = false;
            if (Database.AutoTransactionBehavior != AutoTransactionBehavior.Always && Database.CurrentTransaction is null && changedEntities > 1)
            {
                isManualTransaction = true;
                Database.AutoTransactionBehavior = AutoTransactionBehavior.Always;
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            //如果手工开启了自动事务，用完后关闭。
            if (isManualTransaction)
                Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
            return result;
        }
    }
}
