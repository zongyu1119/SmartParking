using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.Shared.Repository.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsStartingUow { get; }
        IExecutionStrategy Strategy {  get; }
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, bool distributed = false);

        void Rollback();

        void Commit();

        Task RollbackAsync(CancellationToken cancellationToken = default);

        Task CommitAsync(CancellationToken cancellationToken = default);
    }


}
