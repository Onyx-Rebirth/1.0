﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OnyxSAT.Data;
using System;

namespace OnyxSAT.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171019095556_ReleaseTwo")]
    partial class ReleaseTwo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnyxSAT.Models.Attendance", b =>
                {
                    b.Property<DateTime>("DateTime");

                    b.Property<string>("CardNo");

                    b.Property<DateTime?>("SessionDateTime");

                    b.Property<bool?>("Verified");

                    b.HasKey("DateTime", "CardNo");

                    b.HasIndex("CardNo");

                    b.HasIndex("SessionDateTime");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("OnyxSAT.Models.Card", b =>
                {
                    b.Property<string>("CardNo")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("UserId");

                    b.HasKey("CardNo");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("OnyxSAT.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DayOfWeek")
                        .IsRequired();

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("UserId");

                    b.HasKey("ClassId");

                    b.HasIndex("UserId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("OnyxSAT.Models.Enrolment", b =>
                {
                    b.Property<int>("ClassId");

                    b.Property<int>("UserId");

                    b.Property<string>("Status");

                    b.HasKey("ClassId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Enrolments");
                });

            modelBuilder.Entity("OnyxSAT.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("OnyxSAT.Models.Session", b =>
                {
                    b.Property<DateTime>("DateTime");

                    b.Property<int>("ClassId");

                    b.Property<string>("RoomNumber");

                    b.HasKey("DateTime");

                    b.HasIndex("ClassId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("OnyxSAT.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Mobile")
                        .HasMaxLength(10);

                    b.Property<string>("StaffId")
                        .HasMaxLength(20);

                    b.Property<string>("StudentId")
                        .HasMaxLength(20);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnyxSAT.Models.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("OnyxSAT.Models.Attendance", b =>
                {
                    b.HasOne("OnyxSAT.Models.Card", "Card")
                        .WithMany("Attendances")
                        .HasForeignKey("CardNo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnyxSAT.Models.Session", "Session")
                        .WithMany("Attendances")
                        .HasForeignKey("SessionDateTime");
                });

            modelBuilder.Entity("OnyxSAT.Models.Card", b =>
                {
                    b.HasOne("OnyxSAT.Models.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OnyxSAT.Models.Class", b =>
                {
                    b.HasOne("OnyxSAT.Models.User", "User")
                        .WithMany("Classes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnyxSAT.Models.Enrolment", b =>
                {
                    b.HasOne("OnyxSAT.Models.Class", "Class")
                        .WithMany("Enrolments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OnyxSAT.Models.User", "User")
                        .WithMany("Enrolments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnyxSAT.Models.Session", b =>
                {
                    b.HasOne("OnyxSAT.Models.Class", "Class")
                        .WithMany("Sessions")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnyxSAT.Models.UserRole", b =>
                {
                    b.HasOne("OnyxSAT.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnyxSAT.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}