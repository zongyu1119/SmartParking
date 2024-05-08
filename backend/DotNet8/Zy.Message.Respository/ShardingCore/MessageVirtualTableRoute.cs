using ShardingCore.Core.EntityMetadatas;
using ShardingCore.VirtualRoutes.Mods;
using ShardingCore.VirtualRoutes.Months;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Respository.Entitys;

namespace Zy.Message.Respository.ShardingCore
{
    public class MessageVirtualTableRoute : AbstractSimpleShardingMonthKeyDateTimeVirtualTableRoute<Message.Respository.Entitys.Message>, IShardingCoreVirtualTableRoute
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
        public override void Configure(EntityMetadataTableBuilder<Entitys.Message> builder)
        {
            builder.ShardingProperty(o => o.CreateTime);
        }
    }
}
