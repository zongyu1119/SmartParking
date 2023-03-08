using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zy.webcore.Usr.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatev032 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "parent_menu_id",
                table: "sys_menu",
                type: "bigint",
                nullable: true,
                comment: "父菜单");

            migrationBuilder.CreateTable(
                name: "sys_user_role",
                columns: table => new
                {
                    user_role_id = table.Column<long>(type: "bigint", nullable: false, comment: "ID"),
                    user_id = table.Column<long>(type: "bigint", nullable: false, comment: "用户ID"),
                    role_id = table.Column<long>(type: "bigint", nullable: false, comment: "角色ID"),
                    create_by = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    modify_by = table.Column<long>(type: "bigint", nullable: true, comment: "修改人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user_role", x => x.user_role_id);
                },
                comment: "用户角色表")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_user_role");

            migrationBuilder.DropColumn(
                name: "parent_menu_id",
                table: "sys_menu");
        }
    }
}
