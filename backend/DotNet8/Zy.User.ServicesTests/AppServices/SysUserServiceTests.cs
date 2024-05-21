using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zy.User.Services.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Zy.User.Services.AppServices.Tests
{
    [TestClass()]
    public class SysUserServiceTests
    {
        [TestMethod()]
        public  void AddAsyncTest()
        {

            ZyShardingCoreDbContext dbContext = new(new DbContextOptions<ZyShardingCoreDbContext>
            { 
            });
            dbContext.Database.BeginTransaction();
             dbContext.Database.CommitTransaction();
        }
    }
}

namespace Zy.User.ServicesTests.AppServices
{
    internal class SysUserServiceTests
    {
    }
}
