using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParking.EFCore.EntityFramework.Migrations
{
    public partial class AuditUpdate03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Revision",
                table: "op_audit",
                newName: "REVISION");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "op_audit",
                newName: "TENANT_ID");

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9674));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 3,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 4,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 5,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 101,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 102,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9682));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 201,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9687));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 301,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 401,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9684));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 402,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 501,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 502,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 334, DateTimeKind.Local).AddTicks(9691));

            migrationBuilder.UpdateData(
                table: "bc_role",
                keyColumn: "ROLE_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(993));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 1, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 2, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2873));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 3, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 4, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 5, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2878));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 101, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 102, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2881));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 201, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 301, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 401, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 402, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 501, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 502, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(2942));

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 13, 22, 37, 47, 335, DateTimeKind.Local).AddTicks(5675));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "REVISION",
                table: "op_audit",
                newName: "Revision");

            migrationBuilder.RenameColumn(
                name: "TENANT_ID",
                table: "op_audit",
                newName: "TenantId");

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
    }
}
