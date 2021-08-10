﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniCompnay.Data;

namespace MiniCompnay.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20210809100508_empSkillEdit")]
    partial class empSkillEdit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MiniCompnay.Models.EmployeeModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "John@gmail.com",
                            Name = "John"
                        });
                });

            modelBuilder.Entity("MiniCompnay.Models.EmployeeSkillModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeesID")
                        .HasColumnType("int");

                    b.Property<int>("SkillID")
                        .HasColumnType("int");

                    b.Property<int?>("SkillsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmployeesID");

                    b.HasIndex("SkillsID");

                    b.ToTable("EmployeeSkills");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            EmployeeID = 1,
                            SkillID = 1
                        });
                });

            modelBuilder.Entity("MiniCompnay.Models.SkillModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "ASP"
                        },
                        new
                        {
                            ID = 2,
                            Name = "PHP"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Database"
                        });
                });

            modelBuilder.Entity("MiniCompnay.Models.EmployeeSkillModel", b =>
                {
                    b.HasOne("MiniCompnay.Models.EmployeeModel", "Employees")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("EmployeesID");

                    b.HasOne("MiniCompnay.Models.SkillModel", "Skills")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("SkillsID");

                    b.Navigation("Employees");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("MiniCompnay.Models.EmployeeModel", b =>
                {
                    b.Navigation("EmployeeSkills");
                });

            modelBuilder.Entity("MiniCompnay.Models.SkillModel", b =>
                {
                    b.Navigation("EmployeeSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
