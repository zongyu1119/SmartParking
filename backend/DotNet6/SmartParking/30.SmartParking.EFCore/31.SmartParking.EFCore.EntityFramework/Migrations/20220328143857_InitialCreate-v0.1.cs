using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParking.EFCore.EntityFramework.Migrations
{
    public partial class InitialCreatev01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bc_carinfo",
                columns: table => new
                {
                    CAR_ID = table.Column<int>(type: "int", nullable: false, comment: "车辆ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    CAR_NUM = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "车牌号", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CAR_TYPE = table.Column<int>(type: "int", nullable: true, comment: "车辆类型（0:普通车;1:新能源车;2:其他车）"),
                    CAR_PAY_TYPE = table.Column<int>(type: "int", nullable: true, comment: "车辆计费类型（0:临时车;1:月卡;2:年卡;3:免费）"),
                    OWNER_ID = table.Column<int>(type: "int", nullable: true, comment: "车辆所属人ID"),
                    PROVINCE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "省", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CITY = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "市", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BRAND = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "品牌", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MODEL = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "型号", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.CAR_ID);
                },
                comment: "车辆信息表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_config",
                columns: table => new
                {
                    TENANT_ID = table.Column<int>(type: "int", nullable: false, comment: "租户号"),
                    CONFIG_SORT = table.Column<string>(type: "varchar(255)", nullable: false, comment: "配置项类别", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONFIG_KEY = table.Column<string>(type: "varchar(255)", nullable: false, comment: "配置项键", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONFIG_ORDER = table.Column<string>(type: "varchar(255)", nullable: false, comment: "配置项序号（某个键下得序号）", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    CONFIG_VALUE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "配置项值", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONFIG_REMARK = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "配置项备注", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.TENANT_ID, x.CONFIG_SORT, x.CONFIG_KEY, x.CONFIG_ORDER })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });
                },
                comment: "配置信息表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_owner_info",
                columns: table => new
                {
                    OWNER_ID = table.Column<int>(type: "int", nullable: false, comment: "车主/业主ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    OWNER_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "车主名", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USER_ID_CARD_NUM = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "用户身份证号", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SEX = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "用户性别", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PHONE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "用户电话", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDRESS = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "住址", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.OWNER_ID);
                },
                comment: "车主/车位业主信息表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_parking",
                columns: table => new
                {
                    PARKING_ID = table.Column<int>(type: "int", maxLength: 255, nullable: false, comment: "停车场ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    PARKING_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "停车场名称", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PARKING_AREA = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "停车场面积", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PARKING_TYPE = table.Column<int>(type: "int", nullable: true, comment: "停车场类型（0：平面分区；1：条状分区；立体）"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PARKING_ID);
                },
                comment: "停车场表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_parking_area",
                columns: table => new
                {
                    AREA_ID = table.Column<int>(type: "int", nullable: false, comment: "分区ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    AREA_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "分区名称", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AREA_CODE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "分区编码", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PARKING_ID = table.Column<int>(type: "int", nullable: true, comment: "所属停车场ID"),
                    PS_COUNT = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "分区车位数", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AREA_ADDRESS = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "分区地址", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AREA_NO = table.Column<int>(type: "int", nullable: true, comment: "分区序号（立体停车场为层数，平面停车场为排序）"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.AREA_ID);
                },
                comment: "停车场分区表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_parking_area_manager",
                columns: table => new
                {
                    MANAGER_ID = table.Column<int>(type: "int", nullable: false, comment: "管理员ID"),
                    PARKING_AREA_ID = table.Column<int>(type: "int", nullable: false, comment: "停车场分区ID"),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.MANAGER_ID, x.PARKING_AREA_ID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                },
                comment: "停车场分区与管理员对应关系表(多对多关系)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_parking_manager",
                columns: table => new
                {
                    MANAGER_ID = table.Column<int>(type: "int", nullable: false, comment: "车主/业主ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    MANAGER_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "车主名", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MANAGER_ID_CARD_NUM = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "用户身份证号", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SEX = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "用户性别", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PHONE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "用户电话", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDRESS = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "住址", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MANAGER_ID);
                },
                comment: "停车场管理员表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_parking_rate",
                columns: table => new
                {
                    PARKING_ID = table.Column<int>(type: "int", nullable: false, comment: "停车场id")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    FREE_TIME = table.Column<decimal>(type: "decimal(24,6)", precision: 24, scale: 6, nullable: true, comment: "免费时长"),
                    FREE_TIME_ADD_TO_NORMAL = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: true, comment: "超出免费时长后免费时长是否计费", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    START_TIME = table.Column<decimal>(type: "decimal(24,6)", precision: 24, scale: 6, nullable: true, comment: "起步计费时长（如：前一小时每小时10元，本字段代表前一小时）"),
                    START_PRICE = table.Column<decimal>(type: "decimal(24,6)", precision: 24, scale: 6, nullable: true, comment: "起步计费单价"),
                    PRICE = table.Column<decimal>(type: "decimal(24,6)", precision: 24, scale: 6, nullable: true, comment: "计费单价（超出起步后得正常计费单价）"),
                    TOP_MONEY_DAY = table.Column<decimal>(type: "decimal(24,6)", precision: 24, scale: 6, nullable: true, comment: "每日封顶计费金额（为0表示无）"),
                    TOP_MONEY_MONTH = table.Column<decimal>(type: "decimal(24,6)", precision: 24, scale: 6, nullable: true, comment: "每月封顶价格（为0表示无）"),
                    TOP_MONEY_YEAR = table.Column<decimal>(type: "decimal(24,6)", precision: 24, scale: 6, nullable: true, comment: "每年封顶价格（为0表示无）"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PARKING_ID);
                },
                comment: "停车收费标准表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_parking_space",
                columns: table => new
                {
                    PS_ID = table.Column<int>(type: "int", nullable: false, comment: "车位ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    PS_CODE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "车位编码", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PARKING_AREA_ID = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "所属停车场区域", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PS_TYPE = table.Column<int>(type: "int", nullable: true, comment: "车位类型（0：普通车位；1：无障碍车位）"),
                    PS_AREA = table.Column<decimal>(type: "decimal(24,6)", precision: 24, scale: 6, nullable: true, comment: "车位面积"),
                    PS_LASH = table.Column<int>(type: "int", nullable: true, comment: "子母车位(0:标准车位；1：子母车位；)"),
                    PS_CHARG = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "是否有充电桩（0：无；1：有）", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PS_RENT_STATUS = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "车位当前出租出售状态（0：普通车位；1：长租车位；2：：已经出售）", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PS_OWNER = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "车位当前归属（租受人/业主）", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RENT_END_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "租期截止时间"),
                    OCCUPY_STATUS = table.Column<int>(type: "int", nullable: true, comment: "车位占用状态（0：空闲；1：占用）"),
                    CAR_ID = table.Column<int>(type: "int", nullable: true, comment: "占用车辆ID"),
                    OCCUPY_START_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "占用起始时间"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PS_ID);
                },
                comment: "车位表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_power",
                columns: table => new
                {
                    POWER_ID = table.Column<int>(type: "int", nullable: false, comment: "权限ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    POWER_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "权限名称", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    POWER_PATH = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "权限路径", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    POWER_LEVEL = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "权限级别(多级权限区分权限级别)", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PARENT_ID = table.Column<int>(type: "int", nullable: true, comment: "父权限ID"),
                    POWER_TYPE = table.Column<int>(type: "int", nullable: true, comment: "权限类型（0：菜单和功能；1：功能）"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.POWER_ID);
                },
                comment: "权限表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_role",
                columns: table => new
                {
                    ROLE_ID = table.Column<int>(type: "int", nullable: false, comment: "角色ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    ROLE_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "角色名称", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ROLE_ID);
                },
                comment: "角色表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_role_power",
                columns: table => new
                {
                    ROLE_ID = table.Column<int>(type: "int", nullable: false, comment: "角色ID"),
                    POWER_ID = table.Column<int>(type: "int", nullable: false, comment: "权限ID"),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    IS_SELECT = table.Column<int>(type: "int", nullable: true, comment: "是否允许查询(1:允许;0:不允许)"),
                    IS_INSERT = table.Column<int>(type: "int", nullable: true, comment: "是否允许新增(1:允许;0:不允许)"),
                    IS_UPDATE = table.Column<int>(type: "int", nullable: true, comment: "是否允许修改(1:允许;0:不允许)"),
                    IS_DELETE = table.Column<int>(type: "int", nullable: true, comment: "是否允许删除(1:允许;0:不允许)"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.ROLE_ID, x.POWER_ID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                },
                comment: "角色权限中间表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_tenant",
                columns: table => new
                {
                    TENANT_ID = table.Column<int>(type: "int", nullable: false, comment: "租户号")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    TENANT_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "租户名称", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.TENANT_ID);
                },
                comment: "租户表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "bc_userinfo",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false, comment: "用户ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    USER_NAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "用户名", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PASSWORD = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "密码", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USER_NAME_REL = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "用户真实姓名", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USER_ID_CARD_NUM = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "用户身份证号", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SEX = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "用户性别", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PHONE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "用户电话", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDRESS = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "住址", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ROLE_ID = table.Column<int>(type: "int", maxLength: 255, nullable: true, comment: "用户角色"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.USER_ID);
                },
                comment: "用户表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "op_car_io",
                columns: table => new
                {
                    IO_ID = table.Column<int>(type: "int", nullable: false, comment: "进出流水ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    IO_TYPE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "进出类别（1:进;0:出）", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IO_PLACE_TYPE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "进出地点类别(0:停车场;1:车位)", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PARKING_ID = table.Column<int>(type: "int", nullable: true, comment: "停车场ID"),
                    PS_ID = table.Column<int>(type: "int", nullable: true, comment: "车位ID"),
                    CAR_ID = table.Column<int>(type: "int", nullable: true, comment: "车辆ID"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IO_ID);
                },
                comment: "车辆进出历史表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "op_parking_status_his",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "流水号")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TENANT_ID = table.Column<int>(type: "int", nullable: true, comment: "租户号"),
                    REVISION = table.Column<int>(type: "int", nullable: true, comment: "乐观锁"),
                    PS_ID = table.Column<int>(type: "int", nullable: false, comment: "车位ID"),
                    OWNER_ID = table.Column<int>(type: "int", nullable: true, comment: "出租出售对象(车主/业主表ID)"),
                    PRICE = table.Column<decimal>(type: "decimal(24,6)", precision: 24, scale: 6, nullable: true, comment: "出租/出售价格(元)"),
                    DURATION_TIME = table.Column<int>(type: "int", nullable: true, comment: "出租/出售时长（天）"),
                    PS_STATUS_TYPE = table.Column<int>(type: "int", nullable: true, comment: "出租/出售类型（1：出租；2出售）"),
                    CHANGE_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "操作时间"),
                    CREATED_BY = table.Column<int>(type: "int", nullable: true, comment: "创建人"),
                    CREATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "创建时间"),
                    UPDATED_BY = table.Column<int>(type: "int", nullable: true, comment: "更新人"),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_op_parking_status_his", x => x.ID);
                },
                comment: "车位出租出售历史信息表")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bc_carinfo");

            migrationBuilder.DropTable(
                name: "bc_config");

            migrationBuilder.DropTable(
                name: "bc_owner_info");

            migrationBuilder.DropTable(
                name: "bc_parking");

            migrationBuilder.DropTable(
                name: "bc_parking_area");

            migrationBuilder.DropTable(
                name: "bc_parking_area_manager");

            migrationBuilder.DropTable(
                name: "bc_parking_manager");

            migrationBuilder.DropTable(
                name: "bc_parking_rate");

            migrationBuilder.DropTable(
                name: "bc_parking_space");

            migrationBuilder.DropTable(
                name: "bc_power");

            migrationBuilder.DropTable(
                name: "bc_role");

            migrationBuilder.DropTable(
                name: "bc_role_power");

            migrationBuilder.DropTable(
                name: "bc_tenant");

            migrationBuilder.DropTable(
                name: "bc_userinfo");

            migrationBuilder.DropTable(
                name: "op_car_io");

            migrationBuilder.DropTable(
                name: "op_parking_status_his");
        }
    }
}
