using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBaseHelper.Entities
{
    public partial class smartparkingContext : DbContext
    {
        public smartparkingContext()
        {
            _connectionString = AppHelper.AppSettings.ReadAppSettings("ConnectionStrings:mysql");
        }
        private string _connectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }
        public smartparkingContext(DbContextOptions<smartparkingContext> options)
            : base(options)
        {
            _connectionString = AppHelper.AppSettings.ReadAppSettings("ConnectionString");
        }

        public virtual DbSet<BcCarinfo> BcCarinfos { get; set; } = null!;
        public virtual DbSet<BcConfig> BcConfigs { get; set; } = null!;
        public virtual DbSet<BcOwnerInfo> BcOwnerInfos { get; set; } = null!;
        public virtual DbSet<BcParking> BcParkings { get; set; } = null!;
        public virtual DbSet<BcParkingArea> BcParkingAreas { get; set; } = null!;
        public virtual DbSet<BcParkingAreaManager> BcParkingAreaManagers { get; set; } = null!;
        public virtual DbSet<BcParkingManager> BcParkingManagers { get; set; } = null!;
        public virtual DbSet<BcParkingRate> BcParkingRates { get; set; } = null!;
        public virtual DbSet<BcParkingSpace> BcParkingSpaces { get; set; } = null!;
        public virtual DbSet<BcPower> BcPowers { get; set; } = null!;
        public virtual DbSet<BcRole> BcRoles { get; set; } = null!;
        public virtual DbSet<BcRolePower> BcRolePowers { get; set; } = null!;
        public virtual DbSet<BcTenant> BcTenants { get; set; } = null!;
        public virtual DbSet<BcUserinfo> BcUserinfos { get; set; } = null!;
        public virtual DbSet<OpCarIo> OpCarIos { get; set; } = null!;
        public virtual DbSet<OpParkingStatusHi> OpParkingStatusHis { get; set; } = null!;

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<BcCarinfo>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PRIMARY");

                entity.ToTable("bc_carinfo");

                entity.HasComment("车辆信息表");

                entity.Property(e => e.CarId)
                    .HasColumnName("CAR_ID")
                    .HasComment("车辆ID");

                entity.Property(e => e.Brand)
                    .HasMaxLength(255)
                    .HasColumnName("BRAND")
                    .HasComment("品牌");

                entity.Property(e => e.CarNum)
                    .HasMaxLength(255)
                    .HasColumnName("CAR_NUM")
                    .HasComment("车牌号");

                entity.Property(e => e.CarPayType)
                    .HasColumnName("CAR_PAY_TYPE")
                    .HasComment("车辆计费类型（0:临时车;1:月卡;2:年卡;3:免费）");

                entity.Property(e => e.CarType)
                    .HasColumnName("CAR_TYPE")
                    .HasComment("车辆类型（0:普通车;1:新能源车;2:其他车）");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("CITY")
                    .HasComment("市");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.Model)
                    .HasMaxLength(255)
                    .HasColumnName("MODEL")
                    .HasComment("型号");

                entity.Property(e => e.OwnerId)
                    .HasColumnName("OWNER_ID")
                    .HasComment("车辆所属人ID");

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .HasColumnName("PROVINCE")
                    .HasComment("省");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<BcConfig>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.ConfigSort, e.ConfigKey, e.ConfigOrder })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                entity.ToTable("bc_config");

                entity.HasComment("配置信息表");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.ConfigSort)
                    .HasColumnName("CONFIG_SORT")
                    .HasComment("配置项类别");

                entity.Property(e => e.ConfigKey)
                    .HasColumnName("CONFIG_KEY")
                    .HasComment("配置项键");

                entity.Property(e => e.ConfigOrder)
                    .HasColumnName("CONFIG_ORDER")
                    .HasComment("配置项序号（某个键下得序号）");

                entity.Property(e => e.ConfigRemark)
                    .HasMaxLength(255)
                    .HasColumnName("CONFIG_REMARK")
                    .HasComment("配置项备注");

                entity.Property(e => e.ConfigValue)
                    .HasMaxLength(255)
                    .HasColumnName("CONFIG_VALUE")
                    .HasComment("配置项值");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<BcOwnerInfo>(entity =>
            {
                entity.HasKey(e => e.OwnerId)
                    .HasName("PRIMARY");

                entity.ToTable("bc_owner_info");

                entity.HasComment("车主/车位业主信息表");

                entity.Property(e => e.OwnerId)
                    .HasColumnName("OWNER_ID")
                    .HasComment("车主/业主ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("ADDRESS")
                    .HasComment("住址");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(255)
                    .HasColumnName("OWNER_NAME")
                    .HasComment("车主名");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("PHONE")
                    .HasComment("用户电话");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.Sex)
                    .HasMaxLength(255)
                    .HasColumnName("SEX")
                    .HasComment("用户性别");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");

                entity.Property(e => e.UserIdCardNum)
                    .HasMaxLength(255)
                    .HasColumnName("USER_ID_CARD_NUM")
                    .HasComment("用户身份证号");
            });

            modelBuilder.Entity<BcParking>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bc_parking");

                entity.HasComment("停车场表");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.ParkingArea)
                    .HasMaxLength(255)
                    .HasColumnName("PARKING_AREA")
                    .HasComment("停车场面积");

                entity.Property(e => e.ParkingId)
                    .HasMaxLength(255)
                    .HasColumnName("PARKING_ID")
                    .HasComment("停车场ID");

                entity.Property(e => e.ParkingName)
                    .HasMaxLength(255)
                    .HasColumnName("PARKING_NAME")
                    .HasComment("停车场名称");

                entity.Property(e => e.ParkingType)
                    .HasColumnName("PARKING_TYPE")
                    .HasComment("停车场类型（0：平面分区；1：条状分区；立体）");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<BcParkingArea>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("PRIMARY");

                entity.ToTable("bc_parking_area");

                entity.HasComment("停车场分区表");

                entity.Property(e => e.AreaId)
                    .HasColumnName("AREA_ID")
                    .HasComment("分区ID");

                entity.Property(e => e.AreaAddress)
                    .HasMaxLength(255)
                    .HasColumnName("AREA_ADDRESS")
                    .HasComment("分区地址");

                entity.Property(e => e.AreaCode)
                    .HasMaxLength(255)
                    .HasColumnName("AREA_CODE")
                    .HasComment("分区编码");

                entity.Property(e => e.AreaName)
                    .HasMaxLength(255)
                    .HasColumnName("AREA_NAME")
                    .HasComment("分区名称");

                entity.Property(e => e.AreaNo)
                    .HasColumnName("AREA_NO")
                    .HasComment("分区序号（立体停车场为层数，平面停车场为排序）");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.ParkingId)
                    .HasColumnName("PARKING_ID")
                    .HasComment("所属停车场ID");

                entity.Property(e => e.PsCount)
                    .HasMaxLength(255)
                    .HasColumnName("PS_COUNT")
                    .HasComment("分区车位数");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<BcParkingAreaManager>(entity =>
            {
                entity.HasKey(e => new { e.ManagerId, e.ParkingAreaId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("bc_parking_area_manager");

                entity.HasComment("停车场分区与管理员对应关系表(多对多关系)");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("MANAGER_ID")
                    .HasComment("管理员ID");

                entity.Property(e => e.ParkingAreaId)
                    .HasColumnName("PARKING_AREA_ID")
                    .HasComment("停车场分区ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<BcParkingManager>(entity =>
            {
                entity.HasKey(e => e.ManagerId)
                    .HasName("PRIMARY");

                entity.ToTable("bc_parking_manager");

                entity.HasComment("停车场管理员表");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("MANAGER_ID")
                    .HasComment("车主/业主ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("ADDRESS")
                    .HasComment("住址");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.ManagerIdCardNum)
                    .HasMaxLength(255)
                    .HasColumnName("MANAGER_ID_CARD_NUM")
                    .HasComment("用户身份证号");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(255)
                    .HasColumnName("MANAGER_NAME")
                    .HasComment("车主名");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("PHONE")
                    .HasComment("用户电话");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.Sex)
                    .HasMaxLength(255)
                    .HasColumnName("SEX")
                    .HasComment("用户性别");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<BcParkingRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bc_parking_rate");

                entity.HasComment("停车收费标准表");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.FreeTime)
                    .HasPrecision(24, 6)
                    .HasColumnName("FREE_TIME")
                    .HasComment("免费时长");

                entity.Property(e => e.FreeTimeAddToNormal)
                    .HasMaxLength(1)
                    .HasColumnName("FREE_TIME_ADD_TO_NORMAL")
                    .HasComment("超出免费时长后免费时长是否计费");

                entity.Property(e => e.ParkingId)
                    .HasColumnName("PARKING_ID")
                    .HasComment("停车场id");

                entity.Property(e => e.Price)
                    .HasPrecision(24, 6)
                    .HasColumnName("PRICE")
                    .HasComment("计费单价（超出起步后得正常计费单价）");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.StartPrice)
                    .HasPrecision(24, 6)
                    .HasColumnName("START_PRICE")
                    .HasComment("起步计费单价");

                entity.Property(e => e.StartTime)
                    .HasPrecision(24, 6)
                    .HasColumnName("START_TIME")
                    .HasComment("起步计费时长（如：前一小时每小时10元，本字段代表前一小时）");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.TopMoneyDay)
                    .HasPrecision(24, 6)
                    .HasColumnName("TOP_MONEY_DAY")
                    .HasComment("每日封顶计费金额（为0表示无）");

                entity.Property(e => e.TopMoneyMonth)
                    .HasPrecision(24, 6)
                    .HasColumnName("TOP_MONEY_MONTH")
                    .HasComment("每月封顶价格（为0表示无）");

                entity.Property(e => e.TopMoneyYear)
                    .HasPrecision(24, 6)
                    .HasColumnName("TOP_MONEY_YEAR")
                    .HasComment("每年封顶价格（为0表示无）");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<BcParkingSpace>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bc_parking_space");

                entity.HasComment("车位表");

                entity.Property(e => e.CarId)
                    .HasColumnName("CAR_ID")
                    .HasComment("占用车辆ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.OccupyStartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("OCCUPY_START_TIME")
                    .HasComment("占用起始时间");

                entity.Property(e => e.OccupyStatus)
                    .HasColumnName("OCCUPY_STATUS")
                    .HasComment("车位占用状态（0：空闲；1：占用）");

                entity.Property(e => e.ParkingAreaId)
                    .HasMaxLength(255)
                    .HasColumnName("PARKING_AREA_ID")
                    .HasComment("所属停车场区域");

                entity.Property(e => e.PsArea)
                    .HasPrecision(24, 6)
                    .HasColumnName("PS_AREA")
                    .HasComment("车位面积");

                entity.Property(e => e.PsCharg)
                    .HasMaxLength(255)
                    .HasColumnName("PS_CHARG")
                    .HasComment("是否有充电桩（0：无；1：有）");

                entity.Property(e => e.PsCode)
                    .HasMaxLength(255)
                    .HasColumnName("PS_CODE")
                    .HasComment("车位编码");

                entity.Property(e => e.PsId)
                    .HasColumnName("PS_ID")
                    .HasComment("车位ID");

                entity.Property(e => e.PsLash)
                    .HasColumnName("PS_LASH")
                    .HasComment("子母车位(0:标准车位；1：子母车位；)");

                entity.Property(e => e.PsOwner)
                    .HasMaxLength(255)
                    .HasColumnName("PS_OWNER")
                    .HasComment("车位当前归属（租受人/业主）");

                entity.Property(e => e.PsRentStatus)
                    .HasMaxLength(255)
                    .HasColumnName("PS_RENT_STATUS")
                    .HasComment("车位当前出租出售状态（0：普通车位；1：长租车位；2：：已经出售）");

                entity.Property(e => e.PsType)
                    .HasColumnName("PS_TYPE")
                    .HasComment("车位类型（0：普通车位；1：无障碍车位）");

                entity.Property(e => e.RentEndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("RENT_END_TIME")
                    .HasComment("租期截止时间");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<BcPower>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bc_power");

                entity.HasComment("权限表");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.ParentId)
                    .HasColumnName("PARENT_ID")
                    .HasComment("父权限ID");

                entity.Property(e => e.PowerId)
                    .HasColumnName("POWER_ID")
                    .HasComment("权限ID");

                entity.Property(e => e.PowerLevel)
                    .HasMaxLength(255)
                    .HasColumnName("POWER_LEVEL")
                    .HasComment("权限级别(多级权限区分权限级别)");

                entity.Property(e => e.PowerName)
                    .HasMaxLength(255)
                    .HasColumnName("POWER_NAME")
                    .HasComment("权限名称");

                entity.Property(e => e.PowerPath)
                    .HasMaxLength(255)
                    .HasColumnName("POWER_PATH")
                    .HasComment("权限路径");

                entity.Property(e => e.PowerType)
                    .HasColumnName("POWER_TYPE")
                    .HasComment("权限类型（0：菜单和功能；1：功能）");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<BcRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("bc_role");

                entity.HasComment("角色表");

                entity.Property(e => e.RoleId)
                    .HasColumnName("ROLE_ID")
                    .HasComment("角色ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .HasColumnName("ROLE_NAME")
                    .HasComment("角色名称");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<BcRolePower>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bc_role_power");

                entity.HasComment("角色权限中间表");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("IS_DELETE")
                    .HasComment("是否允许删除(1:允许;0:不允许)");

                entity.Property(e => e.IsInsert)
                    .HasColumnName("IS_INSERT")
                    .HasComment("是否允许新增(1:允许;0:不允许)");

                entity.Property(e => e.IsSelect)
                    .HasColumnName("IS_SELECT")
                    .HasComment("是否允许查询(1:允许;0:不允许)");

                entity.Property(e => e.IsUpdate)
                    .HasColumnName("IS_UPDATE")
                    .HasComment("是否允许修改(1:允许;0:不允许)");

                entity.Property(e => e.PowerId)
                    .HasColumnName("POWER_ID")
                    .HasComment("权限ID");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.RoleId)
                    .HasColumnName("ROLE_ID")
                    .HasComment("角色ID");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<BcTenant>(entity =>
            {
                entity.HasKey(e => e.TenantId)
                    .HasName("PRIMARY");

                entity.ToTable("bc_tenant");

                entity.HasComment("租户表");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.TenantName)
                    .HasMaxLength(255)
                    .HasColumnName("TENANT_NAME")
                    .HasComment("租户名称");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<BcUserinfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("bc_userinfo");

                entity.HasComment("用户表");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasComment("用户ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("ADDRESS")
                    .HasComment("住址");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("PASSWORD")
                    .HasComment("密码");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("PHONE")
                    .HasComment("用户电话");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.Sex)
                    .HasMaxLength(255)
                    .HasColumnName("SEX")
                    .HasComment("用户性别");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");

                entity.Property(e => e.UserIdCardNum)
                    .HasMaxLength(255)
                    .HasColumnName("USER_ID_CARD_NUM")
                    .HasComment("用户身份证号");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("USER_NAME")
                    .HasComment("用户名");

                entity.Property(e => e.UserNameRel)
                    .HasMaxLength(255)
                    .HasColumnName("USER_NAME_REL")
                    .HasComment("用户真实姓名");
            });

            modelBuilder.Entity<OpCarIo>(entity =>
            {
                entity.HasKey(e => e.IoId)
                    .HasName("PRIMARY");

                entity.ToTable("op_car_io");

                entity.HasComment("车辆进出历史表");

                entity.Property(e => e.IoId)
                    .HasColumnName("IO_ID")
                    .HasComment("进出流水ID");

                entity.Property(e => e.CarId)
                    .HasColumnName("CAR_ID")
                    .HasComment("车辆ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.IoPlaceType)
                    .HasMaxLength(255)
                    .HasColumnName("IO_PLACE_TYPE")
                    .HasComment("进出地点类别(0:停车场;1:车位)");

                entity.Property(e => e.IoType)
                    .HasMaxLength(255)
                    .HasColumnName("IO_TYPE")
                    .HasComment("进出类别（1:进;0:出）");

                entity.Property(e => e.ParkingId)
                    .HasColumnName("PARKING_ID")
                    .HasComment("停车场ID");

                entity.Property(e => e.PsId)
                    .HasColumnName("PS_ID")
                    .HasComment("车位ID");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            modelBuilder.Entity<OpParkingStatusHi>(entity =>
            {
                entity.ToTable("op_parking_status_his");

                entity.HasComment("车位出租出售历史信息表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("流水号");

                entity.Property(e => e.ChangeTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CHANGE_TIME")
                    .HasComment("操作时间");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasComment("创建人");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasComment("创建时间");

                entity.Property(e => e.DurationTime)
                    .HasColumnName("DURATION_TIME")
                    .HasComment("出租/出售时长（天）");

                entity.Property(e => e.OwnerId)
                    .HasColumnName("OWNER_ID")
                    .HasComment("出租出售对象(车主/业主表ID)");

                entity.Property(e => e.Price)
                    .HasPrecision(24, 6)
                    .HasColumnName("PRICE")
                    .HasComment("出租/出售价格(元)");

                entity.Property(e => e.PsId)
                    .HasColumnName("PS_ID")
                    .HasComment("车位ID");

                entity.Property(e => e.PsStatusType)
                    .HasColumnName("PS_STATUS_TYPE")
                    .HasComment("出租/出售类型（1：出租；2出售）");

                entity.Property(e => e.Revision)
                    .HasColumnName("REVISION")
                    .HasComment("乐观锁");

                entity.Property(e => e.TenantId)
                    .HasColumnName("TENANT_ID")
                    .HasComment("租户号");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasComment("更新人");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME")
                    .HasComment("更新时间");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
