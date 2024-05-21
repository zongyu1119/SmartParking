using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using Zy.Shared.Repository.Contexts;


namespace Zy.Shared.Repository.UnitOfWorks
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected ZyShardingCoreDbContext ZyDbContext { get; init; }
        protected IDbContextTransaction? DbTransaction { get; set; }

        public bool IsStartingUow => ZyDbContext.Database.CurrentTransaction is not null;
        /// <summary>
        /// 组
        /// </summary>
        public IExecutionStrategy Strategy { get; private set; }
        protected UnitOfWork(ZyShardingCoreDbContext context)
        {
            ZyDbContext = context ?? throw new ArgumentNullException(nameof(context));
            Strategy = ZyDbContext.Database.CreateExecutionStrategy();
        }

        protected abstract IDbContextTransaction GetDbContextTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, bool distributed = false);

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, bool distributed = false)
        {
            ZyDbContext.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
            if (ZyDbContext.Database.CurrentTransaction is not null)
                throw new ArgumentException($"UnitOfWork Error,{ZyDbContext.Database.CurrentTransaction}");
            else
                DbTransaction = GetDbContextTransaction(isolationLevel, distributed);
        }

        public void Commit()
        {
            if (DbTransaction is null)
                throw new ArgumentNullException(nameof(DbTransaction), "IDbContextTransaction is null");
            else
                DbTransaction.Commit();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (DbTransaction is null)
                throw new ArgumentNullException(nameof(DbTransaction), "IDbContextTransaction is null");
            else
                await DbTransaction.CommitAsync(cancellationToken);
        }

        public void Rollback()
        {
            if (DbTransaction is null)
                throw new ArgumentNullException(nameof(DbTransaction), "IDbContextTransaction is null");
            else
                DbTransaction.Rollback();
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (DbTransaction is null)
                throw new ArgumentNullException(nameof(DbTransaction), "IDbContextTransaction is null");
            else
                await DbTransaction.RollbackAsync(cancellationToken);
        }

        public void Dispose()
        {
            ZyDbContext.Database.AutoTransactionBehavior = AutoTransactionBehavior.WhenNeeded;
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbTransaction is not null)
                {
                    DbTransaction.Dispose();
                    DbTransaction = null;
                }
            }
        }
    }
}
