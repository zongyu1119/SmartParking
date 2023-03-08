using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zy.webcore.Usr.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatev031 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SysMenu",
                table: "SysMenu");

            migrationBuilder.RenameTable(
                name: "SysMenu",
                newName: "sys_menu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sys_menu",
                table: "sys_menu",
                column: "menu_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sys_menu",
                table: "sys_menu");

            migrationBuilder.RenameTable(
                name: "sys_menu",
                newName: "SysMenu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SysMenu",
                table: "SysMenu",
                column: "menu_id");
        }
    }
}
