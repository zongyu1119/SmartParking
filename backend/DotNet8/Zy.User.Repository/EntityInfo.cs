namespace Zy.User.Repository
{
    /// <summary>
    /// 实体信息
    /// </summary>
    public class EntityInfo : AbstracEntityInfo
    {
        protected override Assembly GetCurrentAssembly() => GetType().Assembly;
    }
}
