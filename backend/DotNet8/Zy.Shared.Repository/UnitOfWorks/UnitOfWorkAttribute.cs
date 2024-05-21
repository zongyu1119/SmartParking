using AspectCore.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.Shared.Repository.UnitOfWorks
{
    /// <summary>
    /// UnitOfWork
    /// </summary>
    /// <param name="isCapTranslation">是否同步开启CAP事务</param>
    public class UnitOfWorkAttribute(bool isCapTranslation=false) : AbstractInterceptorAttribute
    {
        public bool IsCapTranslation { get; set; } = false;
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            var unitOfWork = (IUnitOfWork)context.ServiceProvider.GetService(typeof(IUnitOfWork));
            if(unitOfWork is null)
                throw new ArgumentNullException(nameof(unitOfWork));
            try
            {
                //await unitOfWork.Strategy.Execute(async () =>
                //{
                    unitOfWork.BeginTransaction(distributed: false);
                    await next(context);
                    await unitOfWork.CommitAsync();
                //});
            }
            catch (Exception)
            {
               await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
               unitOfWork.Dispose();
            }
        }
    }
}
