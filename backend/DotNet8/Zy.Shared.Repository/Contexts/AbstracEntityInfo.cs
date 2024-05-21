using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Zy.Shared.Constraint.Dtos;
using Zy.Shared.Entitys;
using Zy.Shared.Extensions;

namespace Zy.Shared.Repository.Contexts
{
    public abstract class AbstracEntityInfo: IEntityInfo
    {
        //private readonly ZyUserContext _userContext;
        //protected AbstracEntityInfo(ZyUserContext userContext)
        //{
        //    _userContext = userContext;
        //}

        protected abstract Assembly GetCurrentAssembly();

        protected virtual IEnumerable<Type> GetEntityTypes(Assembly assembly)
        {
            var typeList = assembly.GetTypes().Where(m =>
                                                       m.FullName != null
                                                       && typeof(IEntity).IsAssignableFrom(m)
                                                       && !m.IsAbstract);
            typeList ??= new List<Type>();

            return typeList;
        }
        /// <summary>
        /// 设置Comment
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="types"></param>
        protected void SetComment(ModelBuilder modelBuilder, IEnumerable<Type>? types)
        {
            if (types is null)
                return;

            var entityTypes = modelBuilder.Model.GetEntityTypes().Where(x => types.Contains(x.ClrType));
            entityTypes.ForEach(entityType =>
            {
                modelBuilder.Entity(entityType.Name, buider =>
                {
                    var typeSummary = entityType.ClrType.GetSummary();
                    buider.ToTable(t => t.HasComment(typeSummary));
                    entityType.GetProperties().ForEach(property =>
                    {
                        string propertyName = property.Name;
                        var memberSummary = entityType.ClrType?.GetMember(propertyName)?.FirstOrDefault()?.GetSummary();
                        buider.Property(propertyName).HasComment(memberSummary);
                    });
                });
            });
        }

        ///// <summary>
        ///// 获取操作者
        ///// </summary>
        ///// <returns></returns>
        //public Operater GetOperater()
        //{
        //    return new Operater
        //    {
        //        Id = _userContext.Id == 0 ? 1600000000000 : _userContext.Id,
        //        Account = _userContext.Account.IsNullOrEmpty() ? "system" : _userContext.Account,
        //        Name = _userContext.Name.IsNullOrEmpty() ? "system" : _userContext.Name
        //    };
        //}

        /// <summary>
        /// 表创建
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual void OnModelCreating(ModelBuilder builder)
        {
            var entityAssembly = GetCurrentAssembly();
            var assemblies = new List<Assembly> { entityAssembly };

            var entityTypes = GetEntityTypes(entityAssembly);
            entityTypes?.ForEach(t => builder.Entity(t));

            assemblies?.ForEach(assembly => builder.ApplyConfigurationsFromAssembly(assembly));

            //SetComment(modelBuilder, entityTypes);
        }
    }
}
