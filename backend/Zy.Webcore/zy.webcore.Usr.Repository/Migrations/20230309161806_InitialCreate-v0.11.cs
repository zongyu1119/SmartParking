using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zy.webcore.Usr.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatev011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "sys_user",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                comment: "是否已删除");

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "sys_menu",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                comment: "是否已删除");

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "sys_job",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                comment: "是否已删除");

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "sys_dept",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                comment: "是否已删除");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "sys_user");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "sys_menu");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "sys_job");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "sys_dept");
        }
    }
}
