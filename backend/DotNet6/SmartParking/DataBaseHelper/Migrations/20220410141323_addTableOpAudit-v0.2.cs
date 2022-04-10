using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseHelper.Migrations
{
    public partial class addTableOpAuditv02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "op_audit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, comment: "ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TYPE = table.Column<string>(type: "longtext", nullable: true, comment: "操作类型", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ACTION_NAME = table.Column<string>(type: "longtext", nullable: true, comment: "操作方法名", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRIPTION = table.Column<string>(type: "longtext", nullable: true, comment: "操作说明", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USER_ID = table.Column<int>(type: "int", nullable: true, comment: "操作用户"),
                    CREATE_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "操作时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_op_audit", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 3,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 4,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 5,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 101,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9443));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 102,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 201,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 301,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 401,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 402,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 501,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "bc_power",
                keyColumn: "POWER_ID",
                keyValue: 502,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 294, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "bc_role",
                keyColumn: "ROLE_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 1, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3257));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 2, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3323));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 3, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3326));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 4, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 5, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3329));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 101, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3331));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 102, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3333));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 201, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 301, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3336));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 401, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3338));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 402, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 501, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3341));

            migrationBuilder.UpdateData(
                table: "bc_role_power",
                keyColumns: new[] { "POWER_ID", "ROLE_ID" },
                keyValues: new object[] { 502, 1 },
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(3343));

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 1,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 2,
                column: "CREATED_TIME",
                value: new DateTime(2022, 4, 10, 22, 13, 22, 295, DateTimeKind.Local).AddTicks(7350));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "op_audit");

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
    }
}
