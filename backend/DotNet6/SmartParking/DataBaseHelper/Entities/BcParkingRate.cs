using System;
using System.Collections.Generic;

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 停车收费标准表
    /// </summary>
    public partial class BcParkingRate : Entity
    {
        /// <summary>
        /// 租户号
        /// </summary>
        public int? TenantId { get; set; }
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? Revision { get; set; }
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
        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreatedBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public int? UpdatedBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }
    }
}
