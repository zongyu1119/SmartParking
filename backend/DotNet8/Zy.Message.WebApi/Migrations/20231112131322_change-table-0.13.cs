using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zy.Message.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class changetable013 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "create_by",
                table: "user_relation",
                type: "bigint",
                nullable: true,
                comment: "创建人");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "user_relation",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                comment: "是否已删除");

            migrationBuilder.AddColumn<long>(
                name: "modify_by",
                table: "user_relation",
                type: "bigint",
                nullable: true,
                comment: "修改人");

            migrationBuilder.AddColumn<DateTime>(
                name: "modify_time",
                table: "user_relation",
                type: "datetime(6)",
                nullable: true,
                comment: "修改时间");

            migrationBuilder.AddColumn<long>(
                name: "create_by",
                table: "user",
                type: "bigint",
                nullable: true,
                comment: "创建人");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "user",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                comment: "是否已删除");

            migrationBuilder.AddColumn<long>(
                name: "modify_by",
                table: "user",
                type: "bigint",
                nullable: true,
                comment: "修改人");

            migrationBuilder.AddColumn<DateTime>(
                name: "modify_time",
                table: "user",
                type: "datetime(6)",
                nullable: true,
                comment: "修改时间");

            migrationBuilder.AddColumn<long>(
                name: "create_by",
                table: "message",
                type: "bigint",
                nullable: true,
                comment: "创建人");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "message",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                comment: "是否已删除");

            migrationBuilder.AddColumn<long>(
                name: "modify_by",
                table: "message",
                type: "bigint",
                nullable: true,
                comment: "修改人");

            migrationBuilder.AddColumn<DateTime>(
                name: "modify_time",
                table: "message",
                type: "datetime(6)",
                nullable: true,
                comment: "修改时间");

            migrationBuilder.AddColumn<long>(
                name: "create_by",
                table: "group_user",
                type: "bigint",
                nullable: true,
                comment: "创建人");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "group_user",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                comment: "是否已删除");

            migrationBuilder.AddColumn<long>(
                name: "modify_by",
                table: "group_user",
                type: "bigint",
                nullable: true,
                comment: "修改人");

            migrationBuilder.AddColumn<DateTime>(
                name: "modify_time",
                table: "group_user",
                type: "datetime(6)",
                nullable: true,
                comment: "修改时间");

            migrationBuilder.AddColumn<long>(
                name: "create_by",
                table: "chat_group",
                type: "bigint",
                nullable: true,
                comment: "创建人");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "chat_group",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                comment: "是否已删除");

            migrationBuilder.AddColumn<long>(
                name: "modify_by",
                table: "chat_group",
                type: "bigint",
                nullable: true,
                comment: "修改人");

            migrationBuilder.AddColumn<DateTime>(
                name: "modify_time",
                table: "chat_group",
                type: "datetime(6)",
                nullable: true,
                comment: "修改时间");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create_by",
                table: "user_relation");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "user_relation");

            migrationBuilder.DropColumn(
                name: "modify_by",
                table: "user_relation");

            migrationBuilder.DropColumn(
                name: "modify_time",
                table: "user_relation");

            migrationBuilder.DropColumn(
                name: "create_by",
                table: "user");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "user");

            migrationBuilder.DropColumn(
                name: "modify_by",
                table: "user");

            migrationBuilder.DropColumn(
                name: "modify_time",
                table: "user");

            migrationBuilder.DropColumn(
                name: "create_by",
                table: "message");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "message");

            migrationBuilder.DropColumn(
                name: "modify_by",
                table: "message");

            migrationBuilder.DropColumn(
                name: "modify_time",
                table: "message");

            migrationBuilder.DropColumn(
                name: "create_by",
                table: "group_user");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "group_user");

            migrationBuilder.DropColumn(
                name: "modify_by",
                table: "group_user");

            migrationBuilder.DropColumn(
                name: "modify_time",
                table: "group_user");

            migrationBuilder.DropColumn(
                name: "create_by",
                table: "chat_group");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "chat_group");

            migrationBuilder.DropColumn(
                name: "modify_by",
                table: "chat_group");

            migrationBuilder.DropColumn(
                name: "modify_time",
                table: "chat_group");
        }
    }
}
