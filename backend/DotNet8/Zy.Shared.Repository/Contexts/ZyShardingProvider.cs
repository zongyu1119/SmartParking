using Microsoft.EntityFrameworkCore;
using ShardingCore.Core.DbContextCreator;
using ShardingCore.Core.RuntimeContexts;
using ShardingCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Zy.Shared.Repository.Contexts
{
    public class ZyShardingProvider
    {
        private static readonly IShardingRuntimeContext instance;
        public static IShardingRuntimeContext ShardingRuntimeContext => instance;
        static ZyShardingProvider()
        {
            instance = new ShardingRuntimeBuilder<ZyShardingCoreDbContext>()
                .Build();
        }
    }
}
