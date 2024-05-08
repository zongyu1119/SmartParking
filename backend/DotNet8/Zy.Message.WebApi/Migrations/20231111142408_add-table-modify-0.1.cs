using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zy.Message.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addtablemodify01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "chat_group",
                type: "longtext",
                nullable: true,
                comment: "聊天组名称",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldComment: "聊天组名称")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "is_group",
                table: "chat_group",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                comment: "是否群聊，否则是单聊");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_group",
                table: "chat_group");

            migrationBuilder.UpdateData(
                table: "chat_group",
                keyColumn: "name",
                keyValue: null,
                column: "name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "chat_group",
                type: "longtext",
                nullable: false,
                comment: "聊天组名称",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldComment: "聊天组名称")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
