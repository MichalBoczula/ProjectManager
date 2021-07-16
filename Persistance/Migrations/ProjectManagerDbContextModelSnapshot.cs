﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance.Context;

namespace Persistance.Migrations
{
    [DbContext(typeof(ProjectManagerDbContext))]
    partial class ProjectManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Inactivated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5c562275-12ed-4851-8128-3252934811f2"),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Adam",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            LastName = "Kowalski",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            StatusId = 0
                        },
                        new
                        {
                            Id = new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Tomasz",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            LastName = "Nowak",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            StatusId = 0
                        },
                        new
                        {
                            Id = new Guid("f27effc7-4efe-4025-a408-d7948a001478"),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Adam",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            LastName = "Smith",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            StatusId = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Inactivated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Created = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            FirstName = "Paul",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            LastName = "Allen",
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            StatusId = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Inactivated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 70, DateTimeKind.Unspecified).AddTicks(7375), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            Description = "Backend API project in CQRS architecture pattern.",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Status = 0,
                            StatusId = 1,
                            Title = "Backend"
                        },
                        new
                        {
                            Id = new Guid("29e6baf3-6cf3-43d5-a0d3-442eb33936e7"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8579), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            Description = "DB infrastructure create in Code First approach.",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Status = 0,
                            StatusId = 1,
                            Title = "Persistance Layer"
                        },
                        new
                        {
                            Id = new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8713), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            Description = "Create consumer for API in Angular framework.",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Status = 0,
                            StatusId = 1,
                            Title = "Frontend"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ProjectAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("DeadLine")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Done")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Established")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Inactivated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("InactivatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectActions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5ee2167-0f5e-4d5b-9d24-9e9779c02171"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(6513), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            DeadLine = new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Make domain classes",
                            Done = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            EmployeeId = new Guid("5c562275-12ed-4851-8128-3252934811f2"),
                            Established = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(6569), new TimeSpan(0, 2, 0, 0, 0)),
                            Feedback = "",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ProjectId = new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"),
                            Status = 0,
                            StatusId = 1,
                            Title = "Domain"
                        },
                        new
                        {
                            Id = new Guid("3845dcae-8c38-4861-b549-85c93e280a57"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7525), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            DeadLine = new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Write Queries and Commands",
                            Done = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            EmployeeId = new Guid("5c562275-12ed-4851-8128-3252934811f2"),
                            Established = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7538), new TimeSpan(0, 2, 0, 0, 0)),
                            Feedback = "",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ProjectId = new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"),
                            Status = 0,
                            StatusId = 1,
                            Title = "Application"
                        },
                        new
                        {
                            Id = new Guid("d3bfa87b-85bc-4958-acdd-92da101a4b4c"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7561), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            DeadLine = new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Write and run unit tests",
                            Done = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            EmployeeId = new Guid("5c562275-12ed-4851-8128-3252934811f2"),
                            Established = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7565), new TimeSpan(0, 2, 0, 0, 0)),
                            Feedback = "",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ProjectId = new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"),
                            Status = 0,
                            StatusId = 1,
                            Title = "UnitTests"
                        },
                        new
                        {
                            Id = new Guid("2a6ecb3d-caf8-4313-8dcd-3669970e879a"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            DeadLine = new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Create API Controllers",
                            Done = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            EmployeeId = new Guid("5c562275-12ed-4851-8128-3252934811f2"),
                            Established = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7591), new TimeSpan(0, 2, 0, 0, 0)),
                            Feedback = "",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ProjectId = new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"),
                            Status = 0,
                            StatusId = 1,
                            Title = "API"
                        },
                        new
                        {
                            Id = new Guid("1aa39b1e-78d4-4baf-8166-fd7a26ef2fef"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7613), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            DeadLine = new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Create and run Integration Tests",
                            Done = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            EmployeeId = new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"),
                            Established = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7616), new TimeSpan(0, 2, 0, 0, 0)),
                            Feedback = "",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ProjectId = new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"),
                            Status = 0,
                            StatusId = 1,
                            Title = "Integration Tests"
                        },
                        new
                        {
                            Id = new Guid("64fc7ece-f023-4cde-a216-c434e7a1085a"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8613), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            DeadLine = new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Create Db schema",
                            Done = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            EmployeeId = new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"),
                            Established = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8617), new TimeSpan(0, 2, 0, 0, 0)),
                            Feedback = "",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ProjectId = new Guid("29e6baf3-6cf3-43d5-a0d3-442eb33936e7"),
                            Status = 0,
                            StatusId = 1,
                            Title = "Schema"
                        },
                        new
                        {
                            Id = new Guid("2add4365-4ab9-4670-8616-1573a45d73ef"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8639), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            DeadLine = new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Create data seed",
                            Done = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            EmployeeId = new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"),
                            Established = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8642), new TimeSpan(0, 2, 0, 0, 0)),
                            Feedback = "",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ProjectId = new Guid("29e6baf3-6cf3-43d5-a0d3-442eb33936e7"),
                            Status = 0,
                            StatusId = 1,
                            Title = "Data seed"
                        },
                        new
                        {
                            Id = new Guid("3b5b228b-0cc2-4f91-a9a6-066d09cb2430"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8674), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            DeadLine = new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Initial Db with test data",
                            Done = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            EmployeeId = new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"),
                            Established = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8678), new TimeSpan(0, 2, 0, 0, 0)),
                            Feedback = "",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ProjectId = new Guid("29e6baf3-6cf3-43d5-a0d3-442eb33936e7"),
                            Status = 0,
                            StatusId = 1,
                            Title = "Initial Migration"
                        },
                        new
                        {
                            Id = new Guid("4b2787ee-bf01-4a38-899d-efddc5fc1c44"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8734), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            DeadLine = new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Plan UI for application",
                            Done = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            EmployeeId = new Guid("f27effc7-4efe-4025-a408-d7948a001478"),
                            Established = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8738), new TimeSpan(0, 2, 0, 0, 0)),
                            Feedback = "",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ProjectId = new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5"),
                            Status = 0,
                            StatusId = 1,
                            Title = "UI Plan"
                        },
                        new
                        {
                            Id = new Guid("372fcc99-468d-4aba-a507-c9bffc7ecaf6"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8760), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            DeadLine = new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Create angular components",
                            Done = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            EmployeeId = new Guid("f27effc7-4efe-4025-a408-d7948a001478"),
                            Established = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8763), new TimeSpan(0, 2, 0, 0, 0)),
                            Feedback = "",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ProjectId = new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5"),
                            Status = 0,
                            StatusId = 1,
                            Title = "Create components"
                        },
                        new
                        {
                            Id = new Guid("5cdaf979-18aa-43e5-9783-43827634bde0"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8809), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            DeadLine = new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Connect Frontent with Backend via API",
                            Done = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            EmployeeId = new Guid("f27effc7-4efe-4025-a408-d7948a001478"),
                            Established = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8813), new TimeSpan(0, 2, 0, 0, 0)),
                            Feedback = "",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ProjectId = new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5"),
                            Status = 0,
                            StatusId = 1,
                            Title = "Conection with API"
                        },
                        new
                        {
                            Id = new Guid("eb8cce36-3fe4-4aab-821e-ee8d37b684f4"),
                            Created = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8834), new TimeSpan(0, 2, 0, 0, 0)),
                            CreatedBy = "Admin",
                            DeadLine = new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Add css",
                            Done = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            EmployeeId = new Guid("f27effc7-4efe-4025-a408-d7948a001478"),
                            Established = new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8838), new TimeSpan(0, 2, 0, 0, 0)),
                            Feedback = "",
                            Inactivated = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"),
                            Modified = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            ProjectId = new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5"),
                            Status = 0,
                            StatusId = 1,
                            Title = "Application style"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ProjectEmployeeManager", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeeId", "ProjectId", "ManagerId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectEmployeeManagers");

                    b.HasData(
                        new
                        {
                            EmployeeId = new Guid("5c562275-12ed-4851-8128-3252934811f2"),
                            ProjectId = new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce")
                        },
                        new
                        {
                            EmployeeId = new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"),
                            ProjectId = new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce")
                        },
                        new
                        {
                            EmployeeId = new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"),
                            ProjectId = new Guid("29e6baf3-6cf3-43d5-a0d3-442eb33936e7"),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce")
                        },
                        new
                        {
                            EmployeeId = new Guid("f27effc7-4efe-4025-a408-d7948a001478"),
                            ProjectId = new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5"),
                            ManagerId = new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce")
                        });
                });

            modelBuilder.Entity("Domain.Entities.ProjectAction", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("ProjectActions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Manager", "Manager")
                        .WithMany("ProjectActions")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Project", "Project")
                        .WithMany("ProjectActions")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Manager");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.Entities.ProjectEmployeeManager", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("Projects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Manager", "Manager")
                        .WithMany("Projects")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Project", "Project")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Manager");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Navigation("ProjectActions");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Domain.Entities.Manager", b =>
                {
                    b.Navigation("ProjectActions");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.Navigation("ProjectActions");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
