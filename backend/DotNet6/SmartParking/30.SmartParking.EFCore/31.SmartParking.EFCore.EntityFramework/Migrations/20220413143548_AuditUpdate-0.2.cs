using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParking.EFCore.EntityFramework.Migrations
{
    public partial class AuditUpdate02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Revision",
                table: "op_audit",
                type: "int",
                nullable: true,
                comment: "乐观锁");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "op_audit",
                type: "int",
                nullable: true,
                comment: "租户号");

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 3,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 4,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3911));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 5,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 101,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 102,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 201,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 301,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 401,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 402,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 501,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3934));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 502,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(3936));

            migrationBuilder.UpdateData(
                table: "bc_role",
                keyColumn: "ROLE_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(5418));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 1, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 2, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 3, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 4, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 5, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 101, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 102, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 201, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 301, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 401, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 402, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 501, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 502, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 217, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 218, DateTimeKind.Local).AddTicks(2733));

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 35, 47, 218, DateTimeKind.Local).AddTicks(2754));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Revision",
                table: "op_audit");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "op_audit");

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 3,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 4,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 5,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 101,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 102,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 201,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 301,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 401,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 402,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 501,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 502,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 405, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "bc_role",
                keyColumn: "ROLE_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 1, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 2, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 3, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 4, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 5, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 101, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 102, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 201, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 301, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 401, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3109));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 402, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 501, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 502, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(3113));

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(7255));

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 18, 15, 406, DateTimeKind.Local).AddTicks(7270));
        }
    }
}
