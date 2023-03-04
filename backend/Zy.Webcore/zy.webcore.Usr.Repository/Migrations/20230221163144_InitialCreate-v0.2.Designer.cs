﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using zy.webcore.share.Repository.IRepositories;

#nullable disable

namespace zy.webcore.Usr.Repository.Migrations
{
    [DbContext(typeof(MySqlDbContext))]
    [Migration("20230221163144_InitialCreate-v0.2")]
    partial class InitialCreatev02
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySQL:Charset", "utf8mb4 ")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("zy.webcore.Usr.Repository.Entities.SysUserinfo", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasComment("ID");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("account")
                        .HasComment("用户账户");

                    b.Property<string>("Address")
                        .HasColumnType("longtext")
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

                    b.Property<long?>("JobId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_job")
                        .HasComment("职务");

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
                        .HasColumnType("longtext")
                        .HasColumnName("password")
                        .HasComment("Password");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext")
                        .HasColumnName("phone")
                        .HasComment("电话号码");

                    b.Property<string>("Sex")
                        .HasColumnType("longtext")
                        .HasColumnName("sex")
                        .HasComment("性别");

                    b.Property<string>("UserIdCardNum")
                        .HasColumnType("longtext")
                        .HasColumnName("user_id_card_num")
                        .HasComment("身份证号");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext")
                        .HasColumnName("user_name")
                        .HasComment("用户姓名");

                    b.HasKey("Id");

                    b.ToTable("sys_user", t =>
                        {
                            t.HasComment("用户表");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}