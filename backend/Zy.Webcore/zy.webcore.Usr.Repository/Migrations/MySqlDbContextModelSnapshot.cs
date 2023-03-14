﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using zy.webcore.Share.Repository.IRepositories;

#nullable disable

namespace zy.webcore.Usr.Repository.Migrations
{
    [DbContext(typeof(MySqlDbContext))]
    partial class MySqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySQL:Charset", "utf8mb4 ")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("zy.webcore.Usr.Repository.Entities.SysDept", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("dept_id")
                        .HasComment("部门ID");

                    b.Property<long>("CreateBy")
                        .HasColumnType("bigint")
                        .HasColumnName("create_by")
                        .HasComment("创建人");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("create_time")
                        .HasComment("创建时间");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("dept_name")
                        .HasComment("部门名称");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_delete")
                        .HasComment("是否已删除");

                    b.Property<long?>("ModifyBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modify_by")
                        .HasComment("修改人");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime")
                        .HasColumnName("modify_time")
                        .HasComment("修改时间");

                    b.Property<long>("ParentDeptId")
                        .HasColumnType("bigint")
                        .HasColumnName("parent_dept_id")
                        .HasComment("父部门ID");

                    b.Property<string>("Remark")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("remark")
                        .HasComment("备注");

                    b.HasKey("Id");

                    b.ToTable("sys_dept", t =>
                        {
                            t.HasComment("部门表");
                        });
                });

            modelBuilder.Entity("zy.webcore.Usr.Repository.Entities.SysJob", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("job_id")
                        .HasComment("职务ID");

                    b.Property<long>("CreateBy")
                        .HasColumnType("bigint")
                        .HasColumnName("create_by")
                        .HasComment("创建人");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("create_time")
                        .HasComment("创建时间");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_delete")
                        .HasComment("是否已删除");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("job_name")
                        .HasComment("职务名称");

                    b.Property<long?>("ModifyBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modify_by")
                        .HasComment("修改人");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime")
                        .HasColumnName("modify_time")
                        .HasComment("修改时间");

                    b.Property<string>("Remark")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("remark")
                        .HasComment("备注");

                    b.HasKey("Id");

                    b.ToTable("sys_job", t =>
                        {
                            t.HasComment("职务表");
                        });
                });

            modelBuilder.Entity("zy.webcore.Usr.Repository.Entities.SysMenu", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("menu_id")
                        .HasComment("菜单ID");

                    b.Property<long>("CreateBy")
                        .HasColumnType("bigint")
                        .HasColumnName("create_by")
                        .HasComment("创建人");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("create_time")
                        .HasComment("创建时间");

                    b.Property<bool>("Enable")
                        .HasMaxLength(1)
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("enable")
                        .HasComment("是否启用");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_delete")
                        .HasComment("是否已删除");

                    b.Property<string>("MenuCode")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("menu_code")
                        .HasComment("菜单编码");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("menu_name")
                        .HasComment("菜单名称");

                    b.Property<string>("MenuPath")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("menu_path")
                        .HasComment("菜单路径");

                    b.Property<int>("MenuType")
                        .HasColumnType("int")
                        .HasColumnName("menu_type")
                        .HasComment("菜单类型");

                    b.Property<long?>("ModifyBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modify_by")
                        .HasComment("修改人");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime")
                        .HasColumnName("modify_time")
                        .HasComment("修改时间");

                    b.Property<int>("Order")
                        .HasColumnType("int")
                        .HasColumnName("order")
                        .HasComment("排序");

                    b.Property<long?>("ParentMenuId")
                        .HasColumnType("bigint")
                        .HasColumnName("parent_menu_id")
                        .HasComment("父菜单");

                    b.Property<string>("Remark")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("remark")
                        .HasComment("备注");

                    b.HasKey("Id");

                    b.ToTable("sys_menu", t =>
                        {
                            t.HasComment("菜单表");
                        });
                });

            modelBuilder.Entity("zy.webcore.Usr.Repository.Entities.SysRole", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id")
                        .HasComment("角色ID");

                    b.Property<long>("CreateBy")
                        .HasColumnType("bigint")
                        .HasColumnName("create_by")
                        .HasComment("创建人");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("create_time")
                        .HasComment("创建时间");

                    b.Property<long?>("ModifyBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modify_by")
                        .HasComment("修改人");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime")
                        .HasColumnName("modify_time")
                        .HasComment("修改时间");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("role_name")
                        .HasComment("角色名称");

                    b.HasKey("Id");

                    b.ToTable("sys_role", t =>
                        {
                            t.HasComment("角色表");
                        });
                });

            modelBuilder.Entity("zy.webcore.Usr.Repository.Entities.SysRoleMenu", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("role_menu_id")
                        .HasComment("ID");

                    b.Property<long>("CreateBy")
                        .HasColumnType("bigint")
                        .HasColumnName("create_by")
                        .HasComment("创建人");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("create_time")
                        .HasComment("创建时间");

                    b.Property<long>("MenuId")
                        .HasColumnType("bigint")
                        .HasColumnName("menu_id")
                        .HasComment("权限ID");

                    b.Property<long?>("ModifyBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modify_by")
                        .HasComment("修改人");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime")
                        .HasColumnName("modify_time")
                        .HasComment("修改时间");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id")
                        .HasComment("角色ID");

                    b.HasKey("Id");

                    b.ToTable("sys_role_menu", t =>
                        {
                            t.HasComment("角色权限表");
                        });
                });

            modelBuilder.Entity("zy.webcore.Usr.Repository.Entities.SysUser", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id")
                        .HasComment("ID");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("account")
                        .HasComment("用户账户");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address")
                        .HasComment("住址");

                    b.Property<long>("CreateBy")
                        .HasColumnType("bigint")
                        .HasColumnName("create_by")
                        .HasComment("创建人");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("create_time")
                        .HasComment("创建时间");

                    b.Property<int>("DataScope")
                        .HasColumnType("int")
                        .HasColumnName("data_scope")
                        .HasComment("数据权限");

                    b.Property<string>("Email")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("email")
                        .HasComment("邮箱");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_delete")
                        .HasComment("是否已删除");

                    b.Property<long?>("ModifyBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modify_by")
                        .HasComment("修改人");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime")
                        .HasColumnName("modify_time")
                        .HasComment("修改时间");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password")
                        .HasComment("密码");

                    b.Property<string>("Phone")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("phone")
                        .HasComment("电话号码");

                    b.Property<string>("Remark")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("remark")
                        .HasComment("备注");

                    b.Property<string>("Sex")
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)")
                        .HasColumnName("sex")
                        .HasComment("性别");

                    b.Property<string>("UserIdCardNum")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("user_id_card_num")
                        .HasComment("身份证号");

                    b.Property<string>("UserName")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("user_name")
                        .HasComment("用户姓名");

                    b.HasKey("Id");

                    b.ToTable("sys_user", t =>
                        {
                            t.HasComment("用户表");
                        });
                });

            modelBuilder.Entity("zy.webcore.Usr.Repository.Entities.SysUserJob", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("user_job_id")
                        .HasComment("ID");

                    b.Property<long>("CreateBy")
                        .HasColumnType("bigint")
                        .HasColumnName("create_by")
                        .HasComment("创建人");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("create_time")
                        .HasComment("创建时间");

                    b.Property<long>("DeptId")
                        .HasColumnType("bigint")
                        .HasColumnName("dept_id")
                        .HasComment("部门ID");

                    b.Property<bool>("IsMainJob")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_main_job")
                        .HasComment("是否主要职务");

                    b.Property<bool>("IsMainManager")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_main_manager")
                        .HasComment("是否部门主要管理者（正职）");

                    b.Property<bool>("IsManager")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_manager")
                        .HasComment("是否部门管理者");

                    b.Property<long?>("JobId")
                        .HasColumnType("bigint")
                        .HasColumnName("job_id")
                        .HasComment("职务ID");

                    b.Property<long?>("ModifyBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modify_by")
                        .HasComment("修改人");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime")
                        .HasColumnName("modify_time")
                        .HasComment("修改时间");

                    b.Property<string>("Remark")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("remark")
                        .HasComment("备注");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id")
                        .HasComment("用户ID");

                    b.HasKey("Id");

                    b.ToTable("sys_user_job", t =>
                        {
                            t.HasComment("用户职务表");
                        });
                });

            modelBuilder.Entity("zy.webcore.Usr.Repository.Entities.SysUserRole", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("user_role_id")
                        .HasComment("ID");

                    b.Property<long>("CreateBy")
                        .HasColumnType("bigint")
                        .HasColumnName("create_by")
                        .HasComment("创建人");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("create_time")
                        .HasComment("创建时间");

                    b.Property<long?>("ModifyBy")
                        .HasColumnType("bigint")
                        .HasColumnName("modify_by")
                        .HasComment("修改人");

                    b.Property<DateTime?>("ModifyTime")
                        .HasColumnType("datetime")
                        .HasColumnName("modify_time")
                        .HasComment("修改时间");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id")
                        .HasComment("角色ID");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id")
                        .HasComment("用户ID");

                    b.HasKey("Id");

                    b.ToTable("sys_user_role", t =>
                        {
                            t.HasComment("用户角色表");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
