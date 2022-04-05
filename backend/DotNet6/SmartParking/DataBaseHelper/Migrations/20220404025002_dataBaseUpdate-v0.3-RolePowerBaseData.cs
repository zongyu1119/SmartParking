using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseHelper.Migrations
{
    public partial class dataBaseUpdatev03RolePowerBaseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "POWER_LEVEL",
                table: "bc_power",
                type: "int",
                nullable: true,
                comment: "权限级别(多级权限区分权限级别)",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldComment: "权限级别(多级权限区分权限级别)")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.InsertData(
                table: "bc_power",
                columns: new[] { "POWER_ID", "CREATED_BY", "CREATED_TIME", "PARENT_ID", "POWER_LEVEL", "POWER_NAME", "POWER_PATH", "POWER_TYPE", "REVISION", "TENANT_ID", "UPDATED_BY", "UPDATED_TIME" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2070), null, 0, "停车场监控", "/", 0, 1, 1, null, null },
                    { 2, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2093), null, 0, "停车场设置", "/", 0, 1, 1, null, null },
                    { 3, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2098), null, 0, "统计和报表", "/", 0, 1, 1, null, null },
                    { 4, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2102), null, 0, "用户和权限", "/", 0, 1, 1, null, null },
                    { 5, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2106), null, 0, "系统设置", "/", 0, 1, 1, null, null },
                    { 101, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2110), 1, 1, "工作台", "/Workbench", 0, 1, 1, null, null },
                    { 102, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2117), 1, 1, "停车监控", "/ParkingMonitor", 0, 1, 1, null, null },
                    { 201, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2128), 2, 1, "停车场管理", "/ParkingManagement", 0, 1, 1, null, null },
                    { 301, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2132), 3, 1, "停车统计", "/ParkingReport", 0, 1, 1, null, null },
                    { 401, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2121), 4, 1, "用户管理", "/UserInfoManagement", 0, 1, 1, null, null },
                    { 402, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2125), 4, 1, "角色管理", "/RoleInfoManagement", 0, 1, 1, null, null },
                    { 501, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2136), 5, 1, "配置管理", "/ConfigManagement", 0, 1, 1, null, null },
                    { 502, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2141), 5, 1, "租户管理", "/TenantManagement", 0, 1, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "bc_role",
                columns: new[] { "ROLE_ID", "CREATED_BY", "CREATED_TIME", "REVISION", "ROLE_NAME", "TENANT_ID", "UPDATED_BY", "UPDATED_TIME" },
                values: new object[] { 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(5570), 1, "管理员", 1, null, null });

            migrationBuilder.InsertData(
                table: "bc_role_power",
                columns: new[] { "POWER_ID", "ROLE_ID", "CREATED_BY", "CREATED_TIME", "IS_DELETE", "IS_INSERT", "IS_SELECT", "IS_UPDATE", "REVISION", "TENANT_ID", "UPDATED_BY", "UPDATED_TIME" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9718), 1, 1, 1, 1, 1, 1, null, null },
                    { 2, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9732), 1, 1, 1, 1, 1, 1, null, null },
                    { 3, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9734), 1, 1, 1, 1, 1, 1, null, null },
                    { 4, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9737), 1, 1, 1, 1, 1, 1, null, null },
                    { 5, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9739), 1, 1, 1, 1, 1, 1, null, null },
                    { 101, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9741), 1, 1, 1, 1, 1, 1, null, null },
                    { 102, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9743), 1, 1, 1, 1, 1, 1, null, null },
                    { 201, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9745), 1, 1, 1, 1, 1, 1, null, null },
                    { 301, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9750), 1, 1, 1, 1, 1, 1, null, null },
                    { 401, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9752), 1, 1, 1, 1, 1, 1, null, null },
                    { 402, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9754), 1, 1, 1, 1, 1, 1, null, null },
                    { 501, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9756), 1, 1, 1, 1, 1, 1, null, null },
                    { 502, 1, 1, new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9758), 1, 1, 1, 1, 1, 1, null, null }
                });

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 746, DateTimeKind.Local).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 746, DateTimeKind.Local).AddTicks(4358));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "bc_role",
                keyColumn: "ROLE_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 101, 1 });

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 102, 1 });

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 201, 1 });

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 301, 1 });

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 401, 1 });

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 402, 1 });

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 501, 1 });

            migrationBuilder.DeleteData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 502, 1 });

            migrationBuilder.AlterColumn<string>(
                name: "POWER_LEVEL",
                table: "bc_power",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                comment: "权限级别(多级权限区分权限级别)",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "权限级别(多级权限区分权限级别)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 3, 14, 7, 38, 267, DateTimeKind.Local).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 3, 14, 7, 38, 267, DateTimeKind.Local).AddTicks(6543));
        }
    }
}
