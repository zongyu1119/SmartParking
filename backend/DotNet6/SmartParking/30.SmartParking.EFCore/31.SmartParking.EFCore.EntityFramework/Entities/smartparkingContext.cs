using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace SmartParking.EFCore.EntityFramework.Entities
{
    public partial class smartparkingContext : DbContext
    {
        private static IConfiguration _config;
      
        public smartparkingContext(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config["ConnectionStrings:mysql"];
        }
        private string _connectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }
        public smartparkingContext(DbContextOptions<smartparkingContext> options, IConfiguration configuration)
            : base(options)
        {
            _config = configuration;
            _connectionString = _config["ConnectionString"];
        }
        #region DbSet
        public virtual DbSet<CarInfo> Carinfos { get; set; } = null!;
        public virtual DbSet<Config> Configs { get; set; } = null!;
        public virtual DbSet<OwnerInfo> OwnerInfos { get; set; } = null!;
        public virtual DbSet<Parking> Parkings { get; set; } = null!;
        public virtual DbSet<ParkingArea> ParkingAreas { get; set; } = null!;
        public virtual DbSet<ParkingAreaManager> ParkingAreaManagers { get; set; } = null!;
        public virtual DbSet<ParkingManager> ParkingManagers { get; set; } = null!;
        public virtual DbSet<ParkingCostRate> ParkingRates { get; set; } = null!;
        public virtual DbSet<ParkingSpace> ParkingSpaces { get; set; } = null!;
        public virtual DbSet<Power> Powers { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RolePower> RolePowers { get; set; } = null!;
        public virtual DbSet<Tenant> Tenants { get; set; } = null!;
        public virtual DbSet<Userinfo> Userinfos { get; set; } = null!;
        public virtual DbSet<CarIo> CarIos { get; set; } = null!;
        public virtual DbSet<ParkingStatusHi> ParkingStatusHis { get; set; } = null!;
        public virtual DbSet<Audit> Audits { get; set; } = null!;
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<CarInfo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("bc_carinfo");

                entity.HasComment("车辆信息表");

                entity.Property(e => e.Id)
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

            modelBuilder.Entity<Config>(entity =>
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

            modelBuilder.Entity<OwnerInfo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("bc_owner_info");

                entity.HasComment("车主/车位业主信息表");

                entity.Property(e => e.Id)
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

            modelBuilder.Entity<Parking>(entity =>
            {
                entity.HasKey(e=>e.Id)
                    .HasName("PRIMARY");

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

                entity.Property(e => e.Id)
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

            modelBuilder.Entity<ParkingArea>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("bc_parking_area");

                entity.HasComment("停车场分区表");

                entity.Property(e => e.Id)
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

            modelBuilder.Entity<ParkingAreaManager>(entity =>
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

            modelBuilder.Entity<ParkingManager>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("bc_parking_manager");

                entity.HasComment("停车场管理员表");

                entity.Property(e => e.Id)
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

            modelBuilder.Entity<ParkingCostRate>(entity =>
            {
                entity.HasKey(e=>e.ParkingId)
                    .HasName("PRIMARY");

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

            modelBuilder.Entity<ParkingSpace>(entity =>
            {
                entity.HasKey(e=>e.Id)
                    .HasName("PRIMARY");

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

                entity.Property(e => e.Id)
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

            modelBuilder.Entity<Power>(entity =>
            {
                entity.HasKey(e=>e.Id)
                    .HasName("PRIMARY");

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

                entity.Property(e => e.Id)
                    .HasColumnName("POWER_ID")
                    .HasComment("权限ID");

                entity.Property(e => e.PowerLevel)
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
                entity.HasData(new Power[]
                {
                    new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=null,
                            Id=1,
                             PowerLevel=0,
                              PowerName="停车场监控",
                               PowerPath="/",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    },new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=null,
                            Id=2,
                             PowerLevel=0,
                              PowerName="停车场设置",
                               PowerPath="/",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    },  new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=null,
                            Id=3,
                             PowerLevel=0,
                              PowerName="统计和报表",
                               PowerPath="/",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    }
                    ,new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=null,
                            Id=4,
                             PowerLevel=0,
                              PowerName="用户和权限",
                               PowerPath="/",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    },
                    new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=null,
                            Id=5,
                             PowerLevel=0,
                              PowerName="系统设置",
                               PowerPath="/",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    },new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=1,
                            Id=101,
                             PowerLevel=1,
                              PowerName="工作台",
                               PowerPath="/Workbench",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    }
                    ,new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=1,
                            Id=102,
                             PowerLevel=1,
                              PowerName="停车监控",
                               PowerPath="/ParkingMonitor",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    },new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=4,
                            Id=401,
                             PowerLevel=1,
                              PowerName="用户管理",
                               PowerPath="/UserInfoManagement",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    }
                    ,new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=4,
                            Id=402,
                             PowerLevel=1,
                              PowerName="角色管理",
                               PowerPath="/RoleInfoManagement",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    },new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=2,
                            Id=201,
                             PowerLevel=1,
                              PowerName="停车场管理",
                               PowerPath="/ParkingManagement",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    }
                    ,new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=3,
                            Id=301,
                             PowerLevel=1,
                              PowerName="停车统计",
                               PowerPath="/ParkingReport",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    },
                    new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=5,
                            Id=501,
                             PowerLevel=1,
                              PowerName="配置管理",
                               PowerPath="/ConfigManagement",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    },
                    new Power()
                    {
                         CreatedBy =1,
                          CreatedTime=DateTime.Now,
                           ParentId=5,
                            Id=502,
                             PowerLevel=1,
                              PowerName="租户管理",
                               PowerPath="/TenantManagement",
                                PowerType=0,
                                Revision=1,
                                 TenantId=1,
                    }
                });
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("bc_role");

                entity.HasComment("角色表");

                entity.Property(e => e.Id)
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
                entity.HasData(new Role[]{
                    new Role
                    {
                         TenantId =1,
                         RoleName ="管理员",
                         Id =1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         Revision=1
                    }
                });
            });

            modelBuilder.Entity<RolePower>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PowerId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

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
                entity.HasData(new RolePower[]
                {
                    new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=1,
                    },new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=2,
                    },new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=3,
                    },new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=4,
                    },new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=5,
                    },new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=101,
                    },new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=102,
                    },new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=201,
                    },new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=301,
                    },new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=401,
                    },new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=402,
                    },new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=501,
                    },new RolePower
                    {
                         Revision=1,
                         TenantId=1,
                         CreatedBy=1,
                         CreatedTime=DateTime.Now,
                         IsDelete=1,
                         IsInsert=1,
                         IsSelect=1,
                         IsUpdate=1,
                         RoleId =1,
                         PowerId=502,
                    }
                });
            });

            modelBuilder.Entity<Tenant>(entity =>
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
                //数据
                entity.HasData(new Tenant
                {
                     Revision=1,
                      TenantId=1,
                       TenantName="租户1"
                });
            });

            modelBuilder.Entity<Userinfo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("bc_userinfo");

                entity.HasComment("用户表");
                #region Property
                entity.Property(e => e.Id)
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
                entity.Property(e => e.RoleId)
                    .HasMaxLength(255)
                    .HasColumnName("ROLE_ID")
                    .HasComment("用户角色");
                #endregion Property
                entity.HasData(new List<Userinfo>
                {
                    new Userinfo
                    {
                        Id=1,
                          RoleId=1,
                          UserName="Admin",
                          UserNameRel="Administrator",
                           Address="北京市长安街1号",
                            CreatedBy=1,
                             CreatedTime=DateTime.Now,
                              Password="827ccb0eea8a706c4c34a16891f84e7b",
                               Phone="13333333332",
                                Revision=1,
                                 Sex="男",
                                  TenantId=1,
                                  UserIdCardNum="622222222222222221"

                    },
                    new Userinfo
                    {
                        Id=2,
                          RoleId=1,
                          UserName="User",
                          UserNameRel="User",
                          Address="北京市长安街1号",
                          CreatedBy=1,
                             CreatedTime=DateTime.Now,
                              Password="827ccb0eea8a706c4c34a16891f84e7b",
                               Phone="13333333333",
                                Revision=1,
                                 Sex="男",
                                  TenantId=1,
                                   UserIdCardNum="622222222222222222"

                    }
                });
            });

            modelBuilder.Entity<CarIo>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("op_car_io");

                entity.HasComment("车辆进出历史表");

                entity.Property(e => e.Id)
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

            modelBuilder.Entity<ParkingStatusHi>(entity =>
            {
                entity.ToTable("op_parking_status_his");

                entity.HasComment("车位出租出售历史信息表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("流水号");

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

            modelBuilder.Entity<Audit>(entity =>
            {

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
#region 每次更改需要执行的命令
// Add-Migration dataBaseUpdate-v0.3-mom
// Update-Database
#endregion