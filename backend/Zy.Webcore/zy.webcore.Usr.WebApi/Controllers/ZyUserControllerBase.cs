using Microsoft.AspNetCore.Components;
using zy.webcore.Share.WebApi.Controllers;

namespace zy.webcore.Usr.WebApi.Controllers
{
    /// <summary>
    /// 用户服务控制器基类
    /// </summary>
    [Route("usr/[controller]")]
    public class ZyUserControllerBase: ZyControllerBase
    {
    }
}
