using System;
using System.Collections.Generic;

namespace SmartParking.EFCore.EntityFramework.Entities
{
    /// <summary>
    /// 停车收费标准表
    /// </summary>
    public partial class ParkingCostRate : ParkingEntityBase
    {      
        /// <summary>
        /// 停车场id
        /// </summary>
        public int ParkingId { get; set; }
        /// <summary>
        /// 免费时长
        /// </summary>
        public decimal? FreeTime { get; set; }
        /// <summary>
        /// 超出免费时长后免费时长是否计费
        /// </summary>
        public string? FreeTimeAddToNormal { get; set; }
        /// <summary>
        /// 起步计费时长（如：前一小时每小时10元，本字段代表前一小时）
        /// </summary>
        public decimal? StartTime { get; set; }
        /// <summary>
        /// 起步计费单价
        /// </summary>
        public decimal? StartPrice { get; set; }
        /// <summary>
        /// 计费单价（超出起步后得正常计费单价）
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// 每日封顶计费金额（为0表示无）
        /// </summary>
        public decimal? TopMoneyDay { get; set; }
        /// <summary>
        /// 每月封顶价格（为0表示无）
        /// </summary>
        public decimal? TopMoneyMonth { get; set; }
        /// <summary>
        /// 每年封顶价格（为0表示无）
        /// </summary>
        public decimal? TopMoneyYear { get; set; }
    }
}
