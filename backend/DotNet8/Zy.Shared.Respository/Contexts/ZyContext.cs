using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Zy.Shared.Constraint.Dtos;
using Zy.Shared.Entitys;

namespace Zy.Shared.Respository.Contexts
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
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
