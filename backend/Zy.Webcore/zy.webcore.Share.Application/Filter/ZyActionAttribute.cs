using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace zy.webcore.Share.Application.Filter
{
    [AttributeUsage(AttributeTargets.All)]
    public class ZyActionAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //模型验证
            if (!context.ModelState.IsValid)
            {
                context.Result = new ObjectResult(new AppSrvResult(HttpStatusCode.BadRequest, context.ModelState.Values.First(p => p.Errors.Count > 0).Errors[0].ErrorMessage));
            }
        }
    }
}
