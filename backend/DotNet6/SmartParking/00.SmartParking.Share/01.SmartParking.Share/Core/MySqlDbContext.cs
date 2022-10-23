using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartParking.Share.Entity;
using SmartParking.Share.Infra;
using SmartParking.Share.ObjExt;
using System.Reflection;

namespace SmartParking.Share.Core
{
    public class MySqlDbContext : DbContext
    {
       
        private readonly Operater _operater;

        private readonly IEntityInfo _entityInfo;

        public MySqlDbContext(DbContextOptions options, Operater operater, IEntityInfo entityInfo)
            : base(options)
        {
            _operater = operater;
            _entityInfo = entityInfo;
            Database.AutoTransactionsEnabled = false;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            int num = SetAuditFields();
            bool flag = false;
            if (!Database.AutoTransactionsEnabled && Database.CurrentTransaction == null && num > 1)
            {
                flag = true;
                Database.AutoTransactionsEnabled = true;
            }

            Task<int> result = base.SaveChangesAsync(cancellationToken);
            if (flag)
            {
                Database.AutoTransactionsEnabled = false;
            }

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4 ");
            IEnumerable<EntityTypeInfo> entitiesTypeInfo = _entityInfo.GetEntitiesTypeInfo();
            if (entitiesTypeInfo.IsNullOrEmpty())
            {
                return;
            }

            foreach (EntityTypeInfo item in entitiesTypeInfo)
            {
                if (item.DataSeeding == null)
                {
                    modelBuilder.Entity(item.Type);
                }
                else
                {
                    modelBuilder.Entity(item.Type).HasData(item.DataSeeding);
                }
            }

            Assembly assembly = entitiesTypeInfo.First().Type.Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
        /// <summary>
        /// 设置数据的审计参数（）
        /// </summary>
        /// <returns></returns>
        protected virtual int SetAuditFields()
        {
            (from x in ChangeTracker.Entries<ITenant>()
             where x.State == EntityState.Added
             select x).ToList().ForEach(delegate (EntityEntry<ITenant> entry)
             {
                 entry.Entity.TenantId = _operater.TenantId;
             });
            (from x in ChangeTracker.Entries<IBaseAuditInfo>()
             where x.State == EntityState.Added
             select x).ToList().ForEach(delegate (EntityEntry<IBaseAuditInfo> entry)
             {
                 entry.Entity.CreatedBy = _operater.Id;
                 entry.Entity.CreatedTime = DateTime.Now;
             });
            (from x in ChangeTracker.Entries<IFullAuditInfo>()
             where x.State == EntityState.Modified
             select x).ToList().ForEach(delegate (EntityEntry<IFullAuditInfo> entry)
             {
                 entry.Entity.UpdatedBy = _operater.Id;
                 entry.Entity.UpdatedTime = DateTime.Now;
             });
            return ChangeTracker.Entries<IEntity>().Count();
        }

        protected virtual void SetComment(ModelBuilder modelBuilder, IEnumerable<EntityTypeInfo> entityInfos)
        {
            ModelBuilder modelBuilder2 = modelBuilder;
            IEnumerable<Type> types = entityInfos.Select((EntityTypeInfo x) => x.Type);
            (from x in modelBuilder2.Model.GetEntityTypes()
             where types.Contains(x.ClrType)
             select x).ForEach(delegate (IMutableEntityType entityType)
             {
                 modelBuilder2.Entity(entityType.Name, delegate (EntityTypeBuilder buider)
                 {
                     EntityTypeBuilder buider2 = buider;
                     string summary = entityType.ClrType.GetSummary();
                     buider2.HasComment(summary);
                     entityType.GetProperties().ForEach(delegate (IMutableProperty property)
                     {
                         string name = property.Name;
                         string comment = entityType.ClrType?.GetMember(name)?.FirstOrDefault()?.GetSummary();
                         buider2.Property(name).HasComment(comment);
                     });
                 });
             });
        }
    }
}
