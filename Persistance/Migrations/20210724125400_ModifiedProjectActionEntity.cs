using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class ModifiedProjectActionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("1d7d4c4d-669f-4778-9fad-a9d18c3dfb24"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("4c5df007-6f46-43cc-83ad-26d72fb1567d"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("55079b39-ebbf-4e66-bbe8-89b308b46d47"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("5e915da5-4443-4aef-8005-4ef673dc4cb3"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("81927181-10cb-438b-a19a-05a3628d621c"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("82e5121c-f30b-4b50-b2c3-b89983dd86c1"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("8d499699-f3fe-43d9-b0f6-4649fa939ff1"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("91aa95f4-e609-4c8e-a62c-787a5936172b"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("b64135b4-7a9f-4272-b129-b22288340840"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("ba502bb1-ee5b-41a4-b928-80fa83662fe7"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("feea797f-23a9-49b8-814e-2fea80703363"));

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new Guid("64652d35-1df7-4331-80ef-aef7d620e046") });

            migrationBuilder.DropColumn(
                name: "Established",
                table: "ProjectActions");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"),
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "JohnSmith@email.com", "John", "Smith" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"),
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "TomaszNowak@email.com", "Tomasz", "Nowak" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"),
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "AdamKowalski@email.com", "Adam", "Kowalski" });

            migrationBuilder.UpdateData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("21b21a7e-402f-4fa0-850f-0a22f48193dd"),
                columns: new[] { "Created", "Description", "EmployeeId", "ProjectId", "Title" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(5868), new TimeSpan(0, 2, 0, 0, 0)), "Make domain classes", new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), new Guid("d5212365-524a-430d-ac75-14a0983edf62"), "Domain" });

            migrationBuilder.InsertData(
                table: "ProjectActions",
                columns: new[] { "Id", "Created", "CreatedBy", "DeadLine", "Description", "Done", "EmployeeId", "Feedback", "Inactivated", "InactivatedBy", "ManagerId", "Modified", "ModifiedBy", "ProjectId", "Status", "StatusId", "Title" },
                values: new object[,]
                {
                    { new Guid("2bc44ff9-69d0-45fc-ad24-1b8673105c8e"), new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(8192), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Add css", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"), 0, 1, "Application style" },
                    { new Guid("57862264-6fd8-40af-8a82-27097afc1721"), new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(8097), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create angular components", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"), 0, 1, "Create components" },
                    { new Guid("e462b281-6f24-4846-8f01-8311824acaa6"), new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(8069), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Plan UI for application", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"), 0, 1, "UI Plan" },
                    { new Guid("6340150a-5a55-4eaa-b3cc-6c98e69da8d1"), new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(8143), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Connect Frontent with Backend via API", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"), 0, 1, "Conection with API" },
                    { new Guid("74a3edf9-ef35-4b57-9f2f-690e0366d1b3"), new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(7990), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create data seed", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 0, 1, "Data seed" },
                    { new Guid("c3187017-7ad9-43f9-80f4-33b850cb65a8"), new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(7966), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create Db schema", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 0, 1, "Schema" },
                    { new Guid("d5ff1ff8-3aef-49bc-ba6f-71e1ffa522fc"), new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(6904), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create and run Integration Tests", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 0, 1, "Integration Tests" },
                    { new Guid("e754f353-71b9-46eb-a200-31c1c40a9a06"), new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(6880), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create API Controllers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 0, 1, "API" },
                    { new Guid("29ad2d1f-a00d-4d50-b2c7-f017d9c4dea7"), new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(6856), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Write and run unit tests", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 0, 1, "UnitTests" },
                    { new Guid("3c847971-a0d6-4302-938c-63cc66885e01"), new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(8012), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Initial Db with test data", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 0, 1, "Initial Migration" },
                    { new Guid("4e400504-b528-4bf9-b35c-96e11b95bbc4"), new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(6778), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Write Queries and Commands", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 0, 1, "Application" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployeeManagers",
                columns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                values: new object[] { new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new Guid("d5212365-524a-430d-ac75-14a0983edf62") });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("64652d35-1df7-4331-80ef-aef7d620e046"),
                columns: new[] { "Created", "Description", "Title" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(7931), new TimeSpan(0, 2, 0, 0, 0)), "DB infrastructure create in Code First approach.", "Persistance Layer" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"),
                columns: new[] { "Created", "Description", "Title" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 703, DateTimeKind.Unspecified).AddTicks(8048), new TimeSpan(0, 2, 0, 0, 0)), "Create consumer for API in Angular framework.", "Frontend" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("d5212365-524a-430d-ac75-14a0983edf62"),
                columns: new[] { "Created", "Description", "Title" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 7, 24, 14, 53, 59, 700, DateTimeKind.Unspecified).AddTicks(3429), new TimeSpan(0, 2, 0, 0, 0)), "Backend API project in CQRS architecture pattern.", "Backend" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("29ad2d1f-a00d-4d50-b2c7-f017d9c4dea7"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("2bc44ff9-69d0-45fc-ad24-1b8673105c8e"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("3c847971-a0d6-4302-938c-63cc66885e01"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("4e400504-b528-4bf9-b35c-96e11b95bbc4"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("57862264-6fd8-40af-8a82-27097afc1721"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("6340150a-5a55-4eaa-b3cc-6c98e69da8d1"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("74a3edf9-ef35-4b57-9f2f-690e0366d1b3"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("c3187017-7ad9-43f9-80f4-33b850cb65a8"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("d5ff1ff8-3aef-49bc-ba6f-71e1ffa522fc"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("e462b281-6f24-4846-8f01-8311824acaa6"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("e754f353-71b9-46eb-a200-31c1c40a9a06"));

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new Guid("d5212365-524a-430d-ac75-14a0983edf62") });

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Established",
                table: "ProjectActions",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"),
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "TomaszNowak@email.com", "Tomasz", "Nowak" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"),
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "AdamKowalski@email.com", "Adam", "Kowalski" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"),
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "JohnSmith@email.com", "John", "Smith" });

            migrationBuilder.UpdateData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("21b21a7e-402f-4fa0-850f-0a22f48193dd"),
                columns: new[] { "Created", "Description", "EmployeeId", "Established", "ProjectId", "Title" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9634), new TimeSpan(0, 2, 0, 0, 0)), "Write Queries and Commands", new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9647), new TimeSpan(0, 2, 0, 0, 0)), new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), "Application" });

            migrationBuilder.InsertData(
                table: "ProjectActions",
                columns: new[] { "Id", "Created", "CreatedBy", "DeadLine", "Description", "Done", "EmployeeId", "Established", "Feedback", "Inactivated", "InactivatedBy", "ManagerId", "Modified", "ModifiedBy", "ProjectId", "Status", "StatusId", "Title" },
                values: new object[,]
                {
                    { new Guid("8d499699-f3fe-43d9-b0f6-4649fa939ff1"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(1001), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Add css", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(1004), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 0, 1, "Application style" },
                    { new Guid("82e5121c-f30b-4b50-b2c3-b89983dd86c1"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(899), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create angular components", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(903), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 0, 1, "Create components" },
                    { new Guid("feea797f-23a9-49b8-814e-2fea80703363"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(871), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Plan UI for application", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(875), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 0, 1, "UI Plan" },
                    { new Guid("81927181-10cb-438b-a19a-05a3628d621c"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(974), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Connect Frontent with Backend via API", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(979), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 0, 1, "Conection with API" },
                    { new Guid("91aa95f4-e609-4c8e-a62c-787a5936172b"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(783), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create data seed", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(787), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"), 0, 1, "Data seed" },
                    { new Guid("b64135b4-7a9f-4272-b129-b22288340840"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(757), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create Db schema", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(761), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"), 0, 1, "Schema" },
                    { new Guid("1d7d4c4d-669f-4778-9fad-a9d18c3dfb24"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9724), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create and run Integration Tests", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9728), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 0, 1, "Integration Tests" },
                    { new Guid("4c5df007-6f46-43cc-83ad-26d72fb1567d"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9698), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create API Controllers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9702), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 0, 1, "API" },
                    { new Guid("5e915da5-4443-4aef-8005-4ef673dc4cb3"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9672), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Write and run unit tests", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9676), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 0, 1, "UnitTests" },
                    { new Guid("ba502bb1-ee5b-41a4-b928-80fa83662fe7"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(808), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Initial Db with test data", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(812), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"), 0, 1, "Initial Migration" },
                    { new Guid("55079b39-ebbf-4e66-bbe8-89b308b46d47"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(8546), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Make domain classes", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(8598), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 0, 1, "Domain" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployeeManagers",
                columns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                values: new object[] { new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new Guid("64652d35-1df7-4331-80ef-aef7d620e046") });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("64652d35-1df7-4331-80ef-aef7d620e046"),
                columns: new[] { "Created", "Description", "Title" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 292, DateTimeKind.Unspecified).AddTicks(7145), new TimeSpan(0, 2, 0, 0, 0)), "Backend API project in CQRS architecture pattern.", "Backend" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"),
                columns: new[] { "Created", "Description", "Title" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(706), new TimeSpan(0, 2, 0, 0, 0)), "DB infrastructure create in Code First approach.", "Persistance Layer" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("d5212365-524a-430d-ac75-14a0983edf62"),
                columns: new[] { "Created", "Description", "Title" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(849), new TimeSpan(0, 2, 0, 0, 0)), "Create consumer for API in Angular framework.", "Frontend" });
        }
    }
}
