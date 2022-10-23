using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParking.EFCore.EntityFramework.Migrations
{
    public partial class addTableOpAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 3,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 4,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6450));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 5,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6452));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 101,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 102,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6458));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 201,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 301,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 401,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6460));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 402,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 501,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 502,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "bc_role",
                keyColumn: "ROLE_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 565, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 1, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 2, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 3, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(15));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 4, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 5, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(18));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 101, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(19));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 102, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(21));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 201, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 301, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 401, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 402, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 501, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 502, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 10, 59, 566, DateTimeKind.Local).AddTicks(3177));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 3,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 4,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2102));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 5,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 101,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 102,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 201,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 301,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 401,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 402,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 501,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 502,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "bc_role",
                keyColumn: "ROLE_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 1, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 2, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 3, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 4, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 5, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9739));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 101, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9741));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 102, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 201, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9745));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 301, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 401, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 402, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9754));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 501, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 502, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 4, 10, 50, 1, 745, DateTimeKind.Local).AddTicks(9758));

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
    }
}
