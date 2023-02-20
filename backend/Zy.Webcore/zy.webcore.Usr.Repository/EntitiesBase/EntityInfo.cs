using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.share.Repository.IRepositories;
using zy.webcore.Share.ZyEfcore;

namespace zy.webcore.Usr.Repository.EntitiesBase
{
    public class EntityInfo : AbstracSharedEntityInfo
    {
        public EntityInfo(UserContext userContext) : base(userContext)
        {
        }

        protected override Assembly GetCurrentAssembly() => GetType().Assembly;
    }
}
