using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zy.webcore.Usr.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatev01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_dept",
                columns: table => new
                {
                    dept_id = table.Column<long>(type: "bigint", nullable: false, comment: "部门ID"),
                    dept_name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "部门名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    parent_dept_id = table.Column<long>(type: "bigint", nullable: false, comment: "父部门ID"),
                    remark = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_by = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    modify_by = table.Column<long>(type: "bigint", nullable: true, comment: "修改人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_dept", x => x.dept_id);
                },
                comment: "部门表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_job",
                columns: table => new
                {
                    job_id = table.Column<long>(type: "bigint", nullable: false, comment: "职务ID"),
                    job_name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "职务名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    remark = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_by = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    modify_by = table.Column<long>(type: "bigint", nullable: true, comment: "修改人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_job", x => x.job_id);
                },
                comment: "职务表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_menu",
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
                    parent_menu_id = table.Column<long>(type: "bigint", nullable: true, comment: "父菜单"),
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
                    table.PrimaryKey("PK_sys_menu", x => x.menu_id);
                },
                comment: "菜单表")
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    role_menu_id = table.Column<long>(type: "bigint", nullable: false, comment: "ID"),
                    role_id = table.Column<long>(type: "bigint", nullable: false, comment: "角色ID"),
                    menu_id = table.Column<long>(type: "bigint", nullable: false, comment: "权限ID"),
                    create_by = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    modify_by = table.Column<long>(type: "bigint", nullable: true, comment: "修改人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_role_menu", x => x.role_menu_id);
                },
                comment: "角色权限表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_user",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false, comment: "ID"),
                    account = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "用户账户")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "密码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "用户姓名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id_card_num = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "身份证号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sex = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true, comment: "性别")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "电话号码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "住址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_scope = table.Column<int>(type: "int", nullable: false, comment: "数据权限"),
                    email = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    remark = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_by = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    modify_by = table.Column<long>(type: "bigint", nullable: true, comment: "修改人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.user_id);
                },
                comment: "用户表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_user_job",
                columns: table => new
                {
                    user_job_id = table.Column<long>(type: "bigint", nullable: false, comment: "ID"),
                    dept_id = table.Column<long>(type: "bigint", nullable: false, comment: "部门ID"),
                    user_id = table.Column<long>(type: "bigint", nullable: false, comment: "用户ID"),
                    job_id = table.Column<long>(type: "bigint", nullable: true, comment: "职务ID"),
                    is_main_job = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否主要职务"),
                    is_manager = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否部门管理者"),
                    is_main_manager = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否部门主要管理者（正职）"),
                    remark = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_by = table.Column<long>(type: "bigint", nullable: false, comment: "创建人"),
                    create_time = table.Column<DateTime>(type: "datetime", nullable: false, comment: "创建时间"),
                    modify_by = table.Column<long>(type: "bigint", nullable: true, comment: "修改人"),
                    modify_time = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user_job", x => x.user_job_id);
                },
                comment: "用户职务表")
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "sys_dept");

            migrationBuilder.DropTable(
                name: "sys_job");

            migrationBuilder.DropTable(
                name: "sys_menu");

            migrationBuilder.DropTable(
                name: "sys_role");

            migrationBuilder.DropTable(
                name: "sys_role_menu");

            migrationBuilder.DropTable(
                name: "sys_user");

            migrationBuilder.DropTable(
                name: "sys_user_job");

            migrationBuilder.DropTable(
                name: "sys_user_role");
        }
    }
}
