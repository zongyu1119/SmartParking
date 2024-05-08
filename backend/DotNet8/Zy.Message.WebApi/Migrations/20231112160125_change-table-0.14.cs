using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zy.Message.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class changetable014 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "message_type",
                table: "message",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "message_type",
                table: "message");
        }
    }
}
