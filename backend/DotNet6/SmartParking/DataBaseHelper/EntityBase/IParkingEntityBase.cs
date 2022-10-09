
namespace DataBaseHelper.EntityBase
{
    public interface IParkingEntityBase:IEntity,IAuditEntity,ITimeEntity
    {

        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? Revision { get; set; }
    }
}
