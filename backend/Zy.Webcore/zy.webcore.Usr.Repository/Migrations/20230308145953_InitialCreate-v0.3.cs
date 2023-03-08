using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zy.webcore.Usr.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatev03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_name",
                table: "sys_user",
                type: "varchar(32)",
                maxLength: 32,
                nullable: true,
                comment: "用户姓名",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldComment: "用户姓名")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "user_id_card_num",
                table: "sys_user",
                type: "varchar(32)",
                maxLength: 32,
                nullable: true,
                comment: "身份证号",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldComment: "身份证号")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "sex",
                table: "sys_user",
                type: "varchar(4)",
                maxLength: 4,
                nullable: true,
                comment: "性别",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldComment: "性别")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "sys_user",
                type: "varchar(32)",
                maxLength: 32,
                nullable: true,
                comment: "电话号码",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldComment: "电话号码")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "sys_user",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                comment: "密码",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldComment: "Password")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "sys_user",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                comment: "住址",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldComment: "住址")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_role",
                columns: table => new
                {
                    role_id = table.Column<long>(type: "bigint", nullable: false, comment: "角色ID"),
                    role_name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "角色名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_by = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    modify_by = table.Column<long>(type: "bigint", nullable: true, comment: "修改人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role", x => x.role_id);
                },
                comment: "角色表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_role_menu",
                columns: table => new
                {
                    role_power_id = table.Column<long>(type: "bigint", nullable: false, comment: "ID"),
                    role_id = table.Column<long>(type: "bigint", nullable: false, comment: "角色ID"),
                    menu_id = table.Column<long>(type: "bigint", nullable: false, comment: "权限ID"),
                    create_by = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    modify_by = table.Column<long>(type: "bigint", nullable: true, comment: "修改人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role_menu", x => x.role_power_id);
                },
                comment: "角色权限表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SysMenu",
                columns: table => new
                {
                    menu_id = table.Column<long>(type: "bigint", nullable: false, comment: "菜单ID"),
                    menu_name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "菜单名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    menu_code = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "菜单编码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    enable = table.Column<bool>(type: "tinyint(1)", maxLength: 1, nullable: false, comment: "是否启用"),
                    menu_path = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "菜单路径")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    menu_type = table.Column<int>(type: "int", nullable: false, comment: "菜单类型"),
                    order = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    remark = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_by = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    modify_by = table.Column<long>(type: "bigint", nullable: true, comment: "修改人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenu", x => x.menu_id);
                },
                comment: "菜单表")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_role");

            migrationBuilder.DropTable(
                name: "sys_role_menu");

            migrationBuilder.DropTable(
                name: "SysMenu");

            migrationBuilder.AlterColumn<string>(
                name: "user_name",
                table: "sys_user",
                type: "longtext",
                nullable: true,
                comment: "用户姓名",
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldMaxLength: 32,
                oldNullable: true,
                oldComment: "用户姓名")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "user_id_card_num",
                table: "sys_user",
                type: "longtext",
                nullable: true,
                comment: "身份证号",
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldMaxLength: 32,
                oldNullable: true,
                oldComment: "身份证号")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "sex",
                table: "sys_user",
                type: "longtext",
                nullable: true,
                comment: "性别",
                oldClrType: typeof(string),
                oldType: "varchar(4)",
                oldMaxLength: 4,
                oldNullable: true,
                oldComment: "性别")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "sys_user",
                type: "longtext",
                nullable: true,
                comment: "电话号码",
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldMaxLength: 32,
                oldNullable: true,
                oldComment: "电话号码")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "sys_user",
                type: "longtext",
                nullable: false,
                comment: "Password",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldComment: "密码")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "sys_user",
                type: "longtext",
                nullable: true,
                comment: "住址",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldComment: "住址")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
