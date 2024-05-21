using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Constraint.Dtos;
using Zy.Shared.Repository.Contexts;

namespace Zy.Message.Repository
{
    public class EntityInfo : AbstracEntityInfo
    {
        protected override Assembly GetCurrentAssembly() => GetType().Assembly;
    }
}
