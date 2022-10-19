using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseHelper.Migrations
{
    public partial class _20220403CreateUserv02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "bc_tenant",
                columns: new[] { "TENANT_ID", "CREATED_BY", "CREATED_TIME", "REVISION", "TENANT_NAME", "UPDATED_BY", "UPDATED_TIME" },
                values: new object[] { 1, null, null, 1, "租户1", null, null });

            migrationBuilder.InsertData(
                table: "bc_userinfo",
                columns: new[] { "USER_ID", "ADDRESS", "CREATED_BY", "CREATED_TIME", "PASSWORD", "PHONE", "REVISION", "ROLE_ID", "SEX", "TENANT_ID", "UPDATED_BY", "UPDATED_TIME", "USER_ID_CARD_NUM", "USER_NAME", "USER_NAME_REL" },
                values: new object[] { 1, "北京市长安街1号", 1, new DateTime(2022, 4, 3, 14, 7, 38, 267, DateTimeKind.Local).AddTicks(6518), "827ccb0eea8a706c4c34a16891f84e7b", "13333333332", 1, 1, "男", 1, null, null, "622222222222222221", "Admin", "Administrator" });

            migrationBuilder.InsertData(
                table: "bc_userinfo",
                columns: new[] { "USER_ID", "ADDRESS", "CREATED_BY", "CREATED_TIME", "PASSWORD", "PHONE", "REVISION", "ROLE_ID", "SEX", "TENANT_ID", "UPDATED_BY", "UPDATED_TIME", "USER_ID_CARD_NUM", "USER_NAME", "USER_NAME_REL" },
                values: new object[] { 2, "北京市长安街1号", 1, new DateTime(2022, 4, 3, 14, 7, 38, 267, DateTimeKind.Local).AddTicks(6543), "827ccb0eea8a706c4c34a16891f84e7b", "13333333333", 1, 1, "男", 1, null, null, "622222222222222222", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bc_tenant",
                keyColumn: "TENANT_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "bc_userinfo",
                keyColumn: "USER_ID",
                keyValue: 2);
        }
    }
}
