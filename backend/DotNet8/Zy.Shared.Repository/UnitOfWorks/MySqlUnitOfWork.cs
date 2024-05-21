using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using Zy.Shared.Repository.Contexts;

namespace Zy.Shared.Repository.UnitOfWorks
{
    public class MySqlUnitOfWork(
        ZyShardingCoreDbContext context
            , ICapPublisher? publisher = null) : UnitOfWork(context)
    {
        protected override IDbContextTransaction GetDbContextTransaction(
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted
            , bool distributed = false)
        {
            if (distributed)
                if (publisher is null)
                    throw new ArgumentException("CapPublisher is null");
                else
                    return ZyDbContext.Database.BeginTransaction(publisher, false);
            else
                return ZyDbContext.Database.BeginTransaction();
        }
    }
}
