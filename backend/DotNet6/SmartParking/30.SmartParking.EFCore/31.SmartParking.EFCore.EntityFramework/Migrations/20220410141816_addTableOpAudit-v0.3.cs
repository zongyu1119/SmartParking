using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseHelper.Migrations
{
    public partial class addTableOpAuditv03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TYPE",
                table: "op_audit",
                type: "varchar(16)",
                maxLength: 16,
                nullable: true,
                comment: "操作类型",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldComment: "操作类型")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "op_audit",
                type: "varchar(512)",
                maxLength: 512,
                nullable: true,
                comment: "操作说明",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldComment: "操作说明")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "ACTION_NAME",
                table: "op_audit",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                comment: "操作方法名",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldComment: "操作方法名")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TYPE",
                table: "op_audit",
                type: "longtext",
                nullable: true,
                comment: "操作类型",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldMaxLength: 16,
                oldNullable: true,
                oldComment: "操作类型")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "op_audit",
                type: "longtext",
                nullable: true,
                comment: "操作说明",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(512)",
                oldMaxLength: 512,
                oldNullable: true,
                oldComment: "操作说明")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "ACTION_NAME",
                table: "op_audit",
                type: "longtext",
                nullable: true,
                comment: "操作方法名",
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldComment: "操作方法名")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

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
    }
}
