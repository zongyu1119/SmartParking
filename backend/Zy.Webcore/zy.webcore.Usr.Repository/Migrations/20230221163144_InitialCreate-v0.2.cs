using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zy.webcore.Usr.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatev02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifyTime",
                table: "sys_user",
                newName: "modify_time");

            migrationBuilder.RenameColumn(
                name: "ModifyBy",
                table: "sys_user",
                newName: "modify_by");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "sys_user",
                newName: "create_time");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "sys_user",
                newName: "create_by");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modify_time",
                table: "sys_user",
                type: "datetime",
                nullable: true,
                comment: "修改时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "modify_by",
                table: "sys_user",
                type: "bigint",
                nullable: true,
                comment: "修改人",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_time",
                table: "sys_user",
                type: "datetime",
                nullable: false,
                comment: "创建时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<long>(
                name: "create_by",
                table: "sys_user",
                type: "bigint",
                nullable: false,
                comment: "创建人",
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "modify_time",
                table: "sys_user",
                newName: "ModifyTime");

            migrationBuilder.RenameColumn(
                name: "modify_by",
                table: "sys_user",
                newName: "ModifyBy");

            migrationBuilder.RenameColumn(
                name: "create_time",
                table: "sys_user",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "sys_user",
                newName: "CreateBy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "sys_user",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldComment: "修改时间");

            migrationBuilder.AlterColumn<long>(
                name: "ModifyBy",
                table: "sys_user",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true,
                oldComment: "修改人");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "sys_user",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldComment: "创建时间");

            migrationBuilder.AlterColumn<long>(
                name: "CreateBy",
                table: "sys_user",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "创建人");
        }
    }
}
