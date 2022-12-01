﻿


namespace SmartParking.EFCore.EntityFramework.Entities
{
    /// <summary>
    /// 车辆信息表
    /// </summary>
    public partial class CarInfo: ParkingEntityBase
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string? CarNum { get; set; }
        /// <summary>
        /// 车辆类型（0:普通车;1:新能源车;2:其他车）
        /// </summary>
        public int? CarType { get; set; }
        /// <summary>
        /// 车辆计费类型（0:临时车;1:月卡;2:年卡;3:免费）
        /// </summary>
        public int? CarPayType { get; set; }
        /// <summary>
        /// 车辆所属人ID
        /// </summary>
        public int? OwnerId { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string? Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string? Brand { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public string? Model { get; set; }
    }
}