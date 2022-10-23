namespace SmartParking.EFCore.EntityFramework.EntityBase
{
    public class ParkingEntityBase : IParkingEntityBase
    {
        /// <summary>
        /// 乐观锁
        /// </summary>
        [Comment("乐观锁")]
        [Column("REVISION")]
        public int? Revision { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Column("ID")]
        [Comment("ID")]
        public long Id { get; set; }
        /// <summary>
        /// 租户ID
        /// </summary>
        [Column("TENANT_ID")]
        [Comment("租户号")]
        public long? TenantId { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Comment("创建人")]
        [Column("CREATE_BY")]
        public long? CreatedBy { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [Comment("修改人")]
        [Column("UPDATE_ID")]
        public long? UpdatedBy { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        [Comment("所属部门")]
        [Column("DEPT_ID")]
        public long DeptId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Comment("创建时间")]
        [Column(name: "CREATE_TIME", TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Comment("修改时间")]
        [Column(name: "UPDATE_TIME", TypeName = "datetime")]
        public DateTime? UpdatedTime { get; set; }
    }
}
