using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Zy.Shared.Constraint.Dtos;
using Zy.Shared.Entitys;

namespace Zy.Shared.Repository.Contexts
{
    public  class ZyContext : DbContext
    {
        private readonly ZyUserContext _user;
        private readonly IEntityInfo _entityInfo;
        public ZyContext(ZyUserContext user, IEntityInfo entityInfo)
        {
            _user = user;
            _entityInfo = entityInfo;
        }

        public ZyContext(DbContextOptions<ZyContext> options,ZyUserContext user,IEntityInfo entityInfo)
            : base(options)
        {
            _user = user;
            _entityInfo = entityInfo;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _entityInfo.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// 保存更改
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {

            foreach (var entry in ChangeTracker.Entries<IAuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateBy = _user.Id;
                        entry.Entity.CreateTime = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifyBy = _user.Id;
                        entry.Entity.ModifyTime = DateTime.Now;
                        break;
                }
            }
            var changedEntities = ChangeTracker.Entries<Entity>().Count();
            //没有自动开启事务的情况下,保证主从表插入，主从表更新开启事务。
            var isManualTransaction = false;
            if (Database.AutoTransactionBehavior!=AutoTransactionBehavior.Always && Database.CurrentTransaction is null && changedEntities > 1)
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
