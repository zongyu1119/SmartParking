using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zy.User.Respository.Migrations
{
    /// <inheritdoc />
    public partial class INIT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sys_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false, comment: "姓名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    account = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false, comment: "账号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "密码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_online = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否在线"),
                    connection_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "连接ID")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "住址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_scope = table.Column<int>(type: "int", nullable: false, comment: "数据权限"),
                    user_id_card = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: true, comment: "身份证号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: true, comment: "手机号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: true, comment: "邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    photo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "照片")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sex = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: true, comment: "性别")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    create_time = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    create_by = table.Column<long>(type: "bigint", nullable: true, comment: "创建人"),
                    modify_by = table.Column<long>(type: "bigint", nullable: true, comment: "修改人"),
                    modify_time = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "修改时间"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否已删除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.id);
                },
                comment: "用户表")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_user");
        }
    }
}
