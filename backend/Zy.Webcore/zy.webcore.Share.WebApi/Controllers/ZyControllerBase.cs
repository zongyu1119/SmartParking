using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Application.Filter;

namespace zy.webcore.Share.WebApi.Controllers
{
    [ApiController]
    [ZyResource]
    [ZyAuthorization]
    [Route("api/[controller]")]
    public class ZyControllerBase: ControllerBase
    {
    }
}
