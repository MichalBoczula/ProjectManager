using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class AddedEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("1e03852f-e94d-4687-8c0e-ae95607ef4a6"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("21106bb2-53ff-4f84-abac-b87e0d8f0da7"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("2e680500-9fb3-4877-9a2e-b726d58241f4"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("2eff24d2-0345-4517-b506-d293d1127fe2"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("4089a299-a777-4eb6-82ac-a95b399c539a"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("4b2f2b73-16ab-433e-a4cd-e529fc052a0a"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("81e9d377-7a3c-4979-94f8-fb814fda43e0"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("981d4c09-0eb6-4faf-9e61-4895c3419472"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("e8cd99fa-259d-469c-a59e-8fbbeb5770ce"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("e9382375-c064-4c5f-9d53-822d9a8e59e9"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("ec3fa388-63fd-4fa8-822d-7fc76e7bf9ac"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("f473e0e6-b21f-4e8d-961e-78e360c15009"));

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("29ff9906-d68b-4366-b40a-5672471916a6"), new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new Guid("dc4870ae-30ed-4de8-8f12-4175516e6d84") });

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("b5e4bb9a-99f3-4d2a-b7e8-b480edc21aac"), new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new Guid("09288712-3ae5-430c-8142-5f32c48df7a6") });

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("b5e4bb9a-99f3-4d2a-b7e8-b480edc21aac"), new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new Guid("63e28160-9811-435f-b3bd-34649e181c3f") });

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("d02cce8c-b217-45c9-9811-addfe93a0d37"), new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new Guid("09288712-3ae5-430c-8142-5f32c48df7a6") });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("29ff9906-d68b-4366-b40a-5672471916a6"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b5e4bb9a-99f3-4d2a-b7e8-b480edc21aac"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("d02cce8c-b217-45c9-9811-addfe93a0d37"));

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("09288712-3ae5-430c-8142-5f32c48df7a6"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("63e28160-9811-435f-b3bd-34649e181c3f"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("dc4870ae-30ed-4de8-8f12-4175516e6d84"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "FirstName", "Inactivated", "InactivatedBy", "LastName", "Modified", "ModifiedBy", "StatusId" },
                values: new object[,]
                {
                    { new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AdamKowalski@email.com", "Adam", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Kowalski", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0 },
                    { new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TomaszNowak@email.com", "Tomasz", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Nowak", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0 },
                    { new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "JohnSmith@email.com", "John", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Smith", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "FirstName", "Inactivated", "InactivatedBy", "LastName", "Modified", "ModifiedBy", "StatusId" },
                values: new object[] { new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "PaulAllen@email.com", "Paul", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Allen", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "Status", "StatusId", "Title" },
                values: new object[,]
                {
                    { new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 292, DateTimeKind.Unspecified).AddTicks(7145), new TimeSpan(0, 2, 0, 0, 0)), "Admin", "Backend API project in CQRS architecture pattern.", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, 1, "Backend" },
                    { new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(706), new TimeSpan(0, 2, 0, 0, 0)), "Admin", "DB infrastructure create in Code First approach.", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, 1, "Persistance Layer" },
                    { new Guid("d5212365-524a-430d-ac75-14a0983edf62"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(849), new TimeSpan(0, 2, 0, 0, 0)), "Admin", "Create consumer for API in Angular framework.", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, 1, "Frontend" }
                });

            migrationBuilder.InsertData(
                table: "ProjectActions",
                columns: new[] { "Id", "Created", "CreatedBy", "DeadLine", "Description", "Done", "EmployeeId", "Established", "Feedback", "Inactivated", "InactivatedBy", "ManagerId", "Modified", "ModifiedBy", "ProjectId", "Status", "StatusId", "Title" },
                values: new object[,]
                {
                    { new Guid("55079b39-ebbf-4e66-bbe8-89b308b46d47"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(8546), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Make domain classes", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(8598), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 0, 1, "Domain" },
                    { new Guid("21b21a7e-402f-4fa0-850f-0a22f48193dd"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9634), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Write Queries and Commands", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9647), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 0, 1, "Application" },
                    { new Guid("5e915da5-4443-4aef-8005-4ef673dc4cb3"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9672), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Write and run unit tests", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9676), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 0, 1, "UnitTests" },
                    { new Guid("4c5df007-6f46-43cc-83ad-26d72fb1567d"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9698), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create API Controllers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9702), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 0, 1, "API" },
                    { new Guid("1d7d4c4d-669f-4778-9fad-a9d18c3dfb24"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9724), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create and run Integration Tests", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 295, DateTimeKind.Unspecified).AddTicks(9728), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("64652d35-1df7-4331-80ef-aef7d620e046"), 0, 1, "Integration Tests" },
                    { new Guid("b64135b4-7a9f-4272-b129-b22288340840"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(757), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create Db schema", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(761), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"), 0, 1, "Schema" },
                    { new Guid("91aa95f4-e609-4c8e-a62c-787a5936172b"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(783), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create data seed", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(787), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"), 0, 1, "Data seed" },
                    { new Guid("ba502bb1-ee5b-41a4-b928-80fa83662fe7"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(808), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Initial Db with test data", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(812), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"), 0, 1, "Initial Migration" },
                    { new Guid("feea797f-23a9-49b8-814e-2fea80703363"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(871), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Plan UI for application", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(875), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 0, 1, "UI Plan" },
                    { new Guid("82e5121c-f30b-4b50-b2c3-b89983dd86c1"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(899), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create angular components", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(903), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 0, 1, "Create components" },
                    { new Guid("81927181-10cb-438b-a19a-05a3628d621c"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(974), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Connect Frontent with Backend via API", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(979), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 0, 1, "Conection with API" },
                    { new Guid("8d499699-f3fe-43d9-b0f6-4649fa939ff1"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(1001), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Add css", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 45, 53, 296, DateTimeKind.Unspecified).AddTicks(1004), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("d5212365-524a-430d-ac75-14a0983edf62"), 0, 1, "Application style" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployeeManagers",
                columns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new Guid("64652d35-1df7-4331-80ef-aef7d620e046") },
                    { new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new Guid("64652d35-1df7-4331-80ef-aef7d620e046") },
                    { new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new Guid("7febeceb-6e20-4151-871b-d5324c0f735b") },
                    { new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new Guid("d5212365-524a-430d-ac75-14a0983edf62") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("1d7d4c4d-669f-4778-9fad-a9d18c3dfb24"));

            migrationBuilder.DeleteData(
                table: "ProjectActions",
                keyColumn: "Id",
                keyValue: new Guid("21b21a7e-402f-4fa0-850f-0a22f48193dd"));

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

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"), new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new Guid("7febeceb-6e20-4151-871b-d5324c0f735b") });

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"), new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new Guid("64652d35-1df7-4331-80ef-aef7d620e046") });

            migrationBuilder.DeleteData(
                table: "ProjectEmployeeManagers",
                keyColumns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                keyValues: new object[] { new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"), new Guid("b517ef40-f882-48cf-8649-cbca908e0787"), new Guid("d5212365-524a-430d-ac75-14a0983edf62") });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"));

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("b517ef40-f882-48cf-8649-cbca908e0787"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("64652d35-1df7-4331-80ef-aef7d620e046"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("d5212365-524a-430d-ac75-14a0983edf62"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "FirstName", "Inactivated", "InactivatedBy", "LastName", "Modified", "ModifiedBy", "StatusId" },
                values: new object[,]
                {
                    { new Guid("d02cce8c-b217-45c9-9811-addfe93a0d37"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Adam", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Kowalski", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0 },
                    { new Guid("b5e4bb9a-99f3-4d2a-b7e8-b480edc21aac"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Tomasz", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Nowak", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0 },
                    { new Guid("29ff9906-d68b-4366-b40a-5672471916a6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Adam", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Smith", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "FirstName", "Inactivated", "InactivatedBy", "LastName", "Modified", "ModifiedBy", "StatusId" },
                values: new object[] { new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Paul", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Allen", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "Status", "StatusId", "Title" },
                values: new object[,]
                {
                    { new Guid("09288712-3ae5-430c-8142-5f32c48df7a6"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 236, DateTimeKind.Unspecified).AddTicks(707), new TimeSpan(0, 2, 0, 0, 0)), "Admin", "Backend API project in CQRS architecture pattern.", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, 1, "Backend" },
                    { new Guid("63e28160-9811-435f-b3bd-34649e181c3f"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5726), new TimeSpan(0, 2, 0, 0, 0)), "Admin", "DB infrastructure create in Code First approach.", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, 1, "Persistance Layer" },
                    { new Guid("dc4870ae-30ed-4de8-8f12-4175516e6d84"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5857), new TimeSpan(0, 2, 0, 0, 0)), "Admin", "Create consumer for API in Angular framework.", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0, 1, "Frontend" }
                });

            migrationBuilder.InsertData(
                table: "ProjectActions",
                columns: new[] { "Id", "Created", "CreatedBy", "DeadLine", "Description", "Done", "EmployeeId", "Established", "Feedback", "Inactivated", "InactivatedBy", "ManagerId", "Modified", "ModifiedBy", "ProjectId", "Status", "StatusId", "Title" },
                values: new object[,]
                {
                    { new Guid("81e9d377-7a3c-4979-94f8-fb814fda43e0"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(3707), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Make domain classes", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d02cce8c-b217-45c9-9811-addfe93a0d37"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(3759), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("09288712-3ae5-430c-8142-5f32c48df7a6"), 0, 1, "Domain" },
                    { new Guid("ec3fa388-63fd-4fa8-822d-7fc76e7bf9ac"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(4697), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Write Queries and Commands", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d02cce8c-b217-45c9-9811-addfe93a0d37"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(4708), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("09288712-3ae5-430c-8142-5f32c48df7a6"), 0, 1, "Application" },
                    { new Guid("f473e0e6-b21f-4e8d-961e-78e360c15009"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(4731), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Write and run unit tests", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d02cce8c-b217-45c9-9811-addfe93a0d37"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(4735), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("09288712-3ae5-430c-8142-5f32c48df7a6"), 0, 1, "UnitTests" },
                    { new Guid("4089a299-a777-4eb6-82ac-a95b399c539a"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(4755), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create API Controllers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d02cce8c-b217-45c9-9811-addfe93a0d37"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(4758), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("09288712-3ae5-430c-8142-5f32c48df7a6"), 0, 1, "API" },
                    { new Guid("1e03852f-e94d-4687-8c0e-ae95607ef4a6"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(4779), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create and run Integration Tests", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b5e4bb9a-99f3-4d2a-b7e8-b480edc21aac"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(4782), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("09288712-3ae5-430c-8142-5f32c48df7a6"), 0, 1, "Integration Tests" },
                    { new Guid("2e680500-9fb3-4877-9a2e-b726d58241f4"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5760), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create Db schema", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b5e4bb9a-99f3-4d2a-b7e8-b480edc21aac"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5763), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("63e28160-9811-435f-b3bd-34649e181c3f"), 0, 1, "Schema" },
                    { new Guid("e8cd99fa-259d-469c-a59e-8fbbeb5770ce"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5783), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create data seed", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b5e4bb9a-99f3-4d2a-b7e8-b480edc21aac"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5787), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("63e28160-9811-435f-b3bd-34649e181c3f"), 0, 1, "Data seed" },
                    { new Guid("21106bb2-53ff-4f84-abac-b87e0d8f0da7"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5820), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Initial Db with test data", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b5e4bb9a-99f3-4d2a-b7e8-b480edc21aac"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5824), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("63e28160-9811-435f-b3bd-34649e181c3f"), 0, 1, "Initial Migration" },
                    { new Guid("981d4c09-0eb6-4faf-9e61-4895c3419472"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5878), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Plan UI for application", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("29ff9906-d68b-4366-b40a-5672471916a6"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5881), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("dc4870ae-30ed-4de8-8f12-4175516e6d84"), 0, 1, "UI Plan" },
                    { new Guid("e9382375-c064-4c5f-9d53-822d9a8e59e9"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5904), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Create angular components", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("29ff9906-d68b-4366-b40a-5672471916a6"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5907), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("dc4870ae-30ed-4de8-8f12-4175516e6d84"), 0, 1, "Create components" },
                    { new Guid("4b2f2b73-16ab-433e-a4cd-e529fc052a0a"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5951), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Connect Frontent with Backend via API", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("29ff9906-d68b-4366-b40a-5672471916a6"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5955), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("dc4870ae-30ed-4de8-8f12-4175516e6d84"), 0, 1, "Conection with API" },
                    { new Guid("2eff24d2-0345-4517-b506-d293d1127fe2"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5975), new TimeSpan(0, 2, 0, 0, 0)), "Admin", new DateTimeOffset(new DateTime(1, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Add css", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("29ff9906-d68b-4366-b40a-5672471916a6"), new DateTimeOffset(new DateTime(2021, 7, 18, 18, 31, 36, 239, DateTimeKind.Unspecified).AddTicks(5979), new TimeSpan(0, 2, 0, 0, 0)), "", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("dc4870ae-30ed-4de8-8f12-4175516e6d84"), 0, 1, "Application style" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployeeManagers",
                columns: new[] { "EmployeeId", "ManagerId", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("d02cce8c-b217-45c9-9811-addfe93a0d37"), new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new Guid("09288712-3ae5-430c-8142-5f32c48df7a6") },
                    { new Guid("b5e4bb9a-99f3-4d2a-b7e8-b480edc21aac"), new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new Guid("09288712-3ae5-430c-8142-5f32c48df7a6") },
                    { new Guid("b5e4bb9a-99f3-4d2a-b7e8-b480edc21aac"), new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new Guid("63e28160-9811-435f-b3bd-34649e181c3f") },
                    { new Guid("29ff9906-d68b-4366-b40a-5672471916a6"), new Guid("c4ed8a87-2104-448e-bcbb-3faf7f20fc52"), new Guid("dc4870ae-30ed-4de8-8f12-4175516e6d84") }
                });
        }
    }
}
