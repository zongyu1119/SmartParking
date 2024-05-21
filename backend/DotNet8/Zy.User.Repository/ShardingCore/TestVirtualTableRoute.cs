using ShardingCore.Core.EntityMetadatas;
using ShardingCore.VirtualRoutes.Mods;
using ShardingCore.VirtualRoutes.Months;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Repository.Entitys;
using Zy.User.Repository.Entitys;

namespace Zy.User.Repository.ShardingCore
{
    /// <summary>
    /// 测试分表
    /// </summary>
    public class ShardingCoreTestEntityVirtualTableRoute : AbstractSimpleShardingMonthKeyDateTimeVirtualTableRoute<ShardingCoreTestEntity>, IShardingCoreVirtualTableRoute
    {
        public override DateTime GetBeginTime()
        {
            return new DateTime(2024, 1, 1);
        }
        public override bool AutoCreateTableByTime()
        {
            return true;
        }
        //注意一定要配置或者采用接口+标签也是可以的
        public override void Configure(EntityMetadataTableBuilder<ShardingCoreTestEntity> builder)
        {
            builder.ShardingProperty(o => o.CreateTime);
        }
    }
}
