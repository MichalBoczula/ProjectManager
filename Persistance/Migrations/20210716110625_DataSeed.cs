using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "FirstName", "Inactivated", "InactivatedBy", "LastName", "Modified", "ModifiedBy", "StatusId" },
                values: new object[,]
                {
                    { new Guid("5c562275-12ed-4851-8128-3252934811f2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Adam", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Kowalski", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0 },
                    { new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Tomasz", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Nowak", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0 },
                    { new Guid("f27effc7-4efe-4025-a408-d7948a001478"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Adam", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Smith", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "FirstName", "Inactivated", "InactivatedBy", "LastName", "Modified", "ModifiedBy", "StatusId" },
                values: new object[] { new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Paul", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Allen", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "Status", "StatusId", "Title" },
                values: new object[,]
                {
                    { new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 70, DateTimeKind.Unspecified).AddTicks(7375), new TimeSpan(0, 2, 0, 0, 0)), "Admin", "Backend API project in CQRS architecture pattern.", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, 1, "Backend" },
                    { new Guid("29e6baf3-6cf3-43d5-a0d3-442eb33936e7"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8579), new TimeSpan(0, 2, 0, 0, 0)), "Admin", "DB infrastructure create in Code First approach.", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, 1, "Persistance Layer" },
                    { new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8713), new TimeSpan(0, 2, 0, 0, 0)), "Admin", "Create consumer for API in Angular framework.", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, 1, "Frontend" }
                });

            migrationBuilder.InsertData(
                table: "ProjectActions",
                columns: new[] { "Id", "Created", "CreatedBy", "DeadLine", "Description", "Done", "EmployeeId", "Established", "Feedback", "Inactivated", "InactivatedBy", "ManagerId", "Modified", "ModifiedBy", "ProjectId", "Status", "StatusId", "Title" },
                values: new object[,]
                {
                    { new Guid("f5ee2167-0f5e-4d5b-9d24-9e9779c02171"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(6513), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Make domain classes", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5c562275-12ed-4851-8128-3252934811f2"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(6569), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"), 0, 1, "Domain" },
                    { new Guid("3845dcae-8c38-4861-b549-85c93e280a57"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7525), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Write Queries and Commands", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5c562275-12ed-4851-8128-3252934811f2"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7538), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"), 0, 1, "Application" },
                    { new Guid("d3bfa87b-85bc-4958-acdd-92da101a4b4c"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7561), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Write and run unit tests", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5c562275-12ed-4851-8128-3252934811f2"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7565), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"), 0, 1, "UnitTests" },
                    { new Guid("2a6ecb3d-caf8-4313-8dcd-3669970e879a"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create API Controllers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("5c562275-12ed-4851-8128-3252934811f2"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7591), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"), 0, 1, "API" },
                    { new Guid("1aa39b1e-78d4-4baf-8166-fd7a26ef2fef"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7613), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create and run Integration Tests", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(7616), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"), 0, 1, "Integration Tests" },
                    { new Guid("64fc7ece-f023-4cde-a216-c434e7a1085a"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8613), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create Db schema", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8617), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("29e6baf3-6cf3-43d5-a0d3-442eb33936e7"), 0, 1, "Schema" },
                    { new Guid("2add4365-4ab9-4670-8616-1573a45d73ef"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8639), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create data seed", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8642), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("29e6baf3-6cf3-43d5-a0d3-442eb33936e7"), 0, 1, "Data seed" },
                    { new Guid("3b5b228b-0cc2-4f91-a9a6-066d09cb2430"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8674), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Initial Db with test data", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8678), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("29e6baf3-6cf3-43d5-a0d3-442eb33936e7"), 0, 1, "Initial Migration" },
                    { new Guid("4b2787ee-bf01-4a38-899d-efddc5fc1c44"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8734), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Plan UI for application", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f27effc7-4efe-4025-a408-d7948a001478"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8738), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5"), 0, 1, "UI Plan" },
                    { new Guid("372fcc99-468d-4aba-a507-c9bffc7ecaf6"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8760), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create angular components", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f27effc7-4efe-4025-a408-d7948a001478"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8763), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5"), 0, 1, "Create components" },
                    { new Guid("5cdaf979-18aa-43e5-9783-43827634bde0"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8809), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Connect Frontent with Backend via API", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f27effc7-4efe-4025-a408-d7948a001478"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8813), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5"), 0, 1, "Conection with API" },
                    { new Guid("eb8cce36-3fe4-4aab-821e-ee8d37b684f4"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8834), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Add css", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f27effc7-4efe-4025-a408-d7948a001478"), new DateTimeOffset(new DateTime(2021, 7, 16, 13, 6, 25, 73, DateTimeKind.Unspecified).AddTicks(8838), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5"), 0, 1, "Application style" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployeeManagers",
                columns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("5c562275-12ed-4851-8128-3252934811f2"), new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2") },
                    { new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"), new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2") },
                    { new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"), new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new Guid("29e6baf3-6cf3-43d5-a0d3-442eb33936e7") },
                    { new Guid("f27effc7-4efe-4025-a408-d7948a001478"), new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("1aa39b1e-78d4-4baf-8166-fd7a26ef2fef"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("2a6ecb3d-caf8-4313-8dcd-3669970e879a"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("2add4365-4ab9-4670-8616-1573a45d73ef"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("372fcc99-468d-4aba-a507-c9bffc7ecaf6"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("3845dcae-8c38-4861-b549-85c93e280a57"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("3b5b228b-0cc2-4f91-a9a6-066d09cb2430"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("4b2787ee-bf01-4a38-899d-efddc5fc1c44"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("5cdaf979-18aa-43e5-9783-43827634bde0"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("64fc7ece-f023-4cde-a216-c434e7a1085a"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("d3bfa87b-85bc-4958-acdd-92da101a4b4c"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("eb8cce36-3fe4-4aab-821e-ee8d37b684f4"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("f5ee2167-0f5e-4d5b-9d24-9e9779c02171"));

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"), new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new Guid("29e6baf3-6cf3-43d5-a0d3-442eb33936e7") });

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"), new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2") });

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("5c562275-12ed-4851-8128-3252934811f2"), new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2") });

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("f27effc7-4efe-4025-a408-d7948a001478"), new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"), new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5") });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("55aead3e-7045-4211-a6e7-bba59bd798ff"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("5c562275-12ed-4851-8128-3252934811f2"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("f27effc7-4efe-4025-a408-d7948a001478"));

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("20716f59-3893-4865-9731-d5c1dd86b4ce"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("29e6baf3-6cf3-43d5-a0d3-442eb33936e7"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("41c82b2c-14da-470e-b5a2-8d10079623e5"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("d0580137-4d86-4d72-9c67-6074cc8e59f2"));
        }
    }
}
