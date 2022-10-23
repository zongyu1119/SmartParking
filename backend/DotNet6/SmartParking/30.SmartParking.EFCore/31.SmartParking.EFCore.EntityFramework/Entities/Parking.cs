
namespace SmartParking.EFCore.EntityFramework.Entities
{
    /// <summary>
    /// 停车场表
    /// </summary>
    public partial class Parking : ParkingEntityBase
    {     
        /// <summary>
        /// 停车场名称
        /// </summary>
        public string? ParkingName { get; set; }
        /// <summary>
        /// 停车场面积
        /// </summary>
        public string? ParkingArea { get; set; }
        /// <summary>
        /// 停车场类型（0：平面分区；1：条状分区；立体）
        /// </summary>
        public int? ParkingType { get; set; } 
    }
}
