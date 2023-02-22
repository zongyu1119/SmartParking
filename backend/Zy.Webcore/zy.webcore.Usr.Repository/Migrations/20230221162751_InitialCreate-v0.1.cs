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
                name: "sys_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "ID"),
                    account = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "用户账户")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false, comment: "Password")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_name = table.Column<string>(type: "longtext", nullable: true, comment: "用户姓名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_job = table.Column<long>(type: "bigint", nullable: true, comment: "职务"),
                    user_id_card_num = table.Column<string>(type: "longtext", nullable: true, comment: "身份证号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sex = table.Column<string>(type: "longtext", nullable: true, comment: "性别")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "longtext", nullable: true, comment: "电话号码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "longtext", nullable: true, comment: "住址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateBy = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime", nullable: true)
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
