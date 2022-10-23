
namespace SmartParking.EFCore.EntityFramework.EntityBase
{
    public interface IParkingEntityBase:IEntity,IFullAuditInfo, IDeptEntity
    {

        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? Revision { get; set; }
    }
}
