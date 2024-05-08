using AspectCore.DynamicProxy;

namespace Zy.Shared.Constraint.Interceptors
{
    /// <summary>
    /// 审计拦截器
    /// </summary>
    public class AuditInterceptorAttribute(string OperationName) : AbstractInterceptorAttribute
    {
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                Console.WriteLine($"Before service call,{OperationName}");
                await next(context);
            }
            catch (Exception)
            {
                Console.WriteLine("Service throw an exception!");
                throw;
            }
            finally
            {
                Console.WriteLine("After service call");
            }
        }
    }
}
