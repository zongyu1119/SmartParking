using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Constraint.Dtos;
using Zy.Shared.Respository.Contexts;

namespace Zy.Message.Respository
{
    public class EntityInfo : AbstracEntityInfo
    {
        protected override Assembly GetCurrentAssembly() => GetType().Assembly;
    }
}
