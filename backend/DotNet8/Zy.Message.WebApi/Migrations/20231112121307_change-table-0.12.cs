using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zy.Message.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class changetable012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_group",
                table: "message");

            migrationBuilder.AlterColumn<bool>(
                name: "is_group",
                table: "chat_group",
                type: "tinyint(1)",
                nullable: false,
                comment: "是否群聊(多人聊天)，否则是单聊",
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldComment: "是否群聊，否则是单聊");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_group",
                table: "message",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "is_group",
                table: "chat_group",
                type: "tinyint(1)",
                nullable: false,
                comment: "是否群聊，否则是单聊",
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldComment: "是否群聊(多人聊天)，否则是单聊");
        }
    }
}
