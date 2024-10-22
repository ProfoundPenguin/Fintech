﻿// <auto-generated />
using System;
using HRMS.Areas.HRMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace core.Migrations
{
    [DbContext(typeof(HRMSContext))]
    [Migration("20241022130216_AddAcessLevelAndPermission")]
    partial class AddAcessLevelAndPermission
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HRMS.Areas.HRMS.Models.Attendance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("MemberId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("MemberId");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("HRMS.Areas.HRMS.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("HRMS.Areas.HRMS.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateOfJoining")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EmployeeCategory")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeType")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("PayrollID")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleID")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("numeric");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("PayrollID");

                    b.HasIndex("RoleID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("HRMS.Areas.HRMS.Models.Payroll", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("MemberID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.ToTable("Payroll");
                });

            modelBuilder.Entity("HRMS.Areas.HRMS.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("HRMS.Areas.HRMS.Models.Attendance", b =>
                {
                    b.HasOne("HRMS.Areas.HRMS.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("HRMS.Areas.HRMS.Models.Member", b =>
                {
                    b.HasOne("HRMS.Areas.HRMS.Models.Department", "Department")
                        .WithMany("Members")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRMS.Areas.HRMS.Models.Payroll", null)
                        .WithMany("Members")
                        .HasForeignKey("PayrollID");

                    b.HasOne("HRMS.Areas.HRMS.Models.Role", "Role")
                        .WithMany("Members")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HRMS.Areas.HRMS.Models.Payroll", b =>
                {
                    b.HasOne("HRMS.Areas.HRMS.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("HRMS.Areas.HRMS.Models.Department", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("HRMS.Areas.HRMS.Models.Payroll", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("HRMS.Areas.HRMS.Models.Role", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
