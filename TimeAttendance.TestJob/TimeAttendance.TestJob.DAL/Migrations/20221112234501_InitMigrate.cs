using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimeAttendance.TestJob.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmallTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TasksComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentType = table.Column<byte>(type: "tinyint", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksComments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreateDate", "ProjectName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("02e97f33-9a1d-479a-82fd-279e0f9ed417"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1848), "project-3", new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1847) },
                    { new Guid("856713bf-a538-4613-81b3-72b0de4052d0"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1839), "project-1", new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1824) },
                    { new Guid("a9aa8f74-9c63-4d5b-a54a-a2e8f57b64d3"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1846), "project-2", new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1845) }
                });

            migrationBuilder.InsertData(
                table: "SmallTasks",
                columns: new[] { "Id", "CancelDate", "CreateDate", "DeleteDate", "ProjectId", "StartDate", "TaskName" },
                values: new object[,]
                {
                    { new Guid("4dfd1d8d-3806-4b1a-b0f3-8b8a032d79b1"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1857), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1857), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("856713bf-a538-4613-81b3-72b0de4052d0"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1856), "task-2" },
                    { new Guid("9a336963-926a-4302-8e77-89f849dfdfdb"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1853), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1853), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("856713bf-a538-4613-81b3-72b0de4052d0"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1852), "task-1" },
                    { new Guid("c9855d12-4624-4969-b72c-57a2da129043"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1943), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1944), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("02e97f33-9a1d-479a-82fd-279e0f9ed417"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1943), "task-777" },
                    { new Guid("d48ffc99-2e39-4c81-832d-638418e07bf3"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1937), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1938), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a9aa8f74-9c63-4d5b-a54a-a2e8f57b64d3"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1937), "task-14234" },
                    { new Guid("de3fe344-dac7-4aec-a143-fc693ea02930"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1860), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1860), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("856713bf-a538-4613-81b3-72b0de4052d0"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1859), "task-3" },
                    { new Guid("ee18698e-c04a-4ddd-a6ab-87d44aaffa46"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1874), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1875), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a9aa8f74-9c63-4d5b-a54a-a2e8f57b64d3"), new DateTime(2022, 11, 13, 2, 45, 1, 391, DateTimeKind.Local).AddTicks(1874), "task-14234" }
                });

            migrationBuilder.InsertData(
                table: "TasksComments",
                columns: new[] { "Id", "CommentType", "Content", "TaskId" },
                values: new object[,]
                {
                    { new Guid("3cd88b1f-27ae-4e1c-953d-34610a5ab8a6"), (byte)0, new byte[] { 104, 101, 108, 108, 111, 32, 116, 97, 115, 107, 51, 50, 49 }, new Guid("9a336963-926a-4302-8e77-89f849dfdfdb") },
                    { new Guid("5db8db0e-40a3-4254-af7c-833ce8ce71d5"), (byte)1, new byte[] { 104, 101, 108, 108, 111, 32, 112, 114, 111, 106, 101, 99, 116 }, new Guid("4dfd1d8d-3806-4b1a-b0f3-8b8a032d79b1") },
                    { new Guid("c64fbc14-80fc-48d8-b161-e2dfc8dc7330"), (byte)22, new byte[] { 104, 101, 108, 108, 111, 32, 116, 97, 115, 107, 51, 50, 51, 49, 50, 51, 49 }, new Guid("d48ffc99-2e39-4c81-832d-638418e07bf3") },
                    { new Guid("d65e4d48-95ab-4613-99fe-32edfe561226"), (byte)0, new byte[] { 104, 101, 108, 108, 111, 32, 119, 111, 114, 108, 100 }, new Guid("9a336963-926a-4302-8e77-89f849dfdfdb") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "SmallTasks");

            migrationBuilder.DropTable(
                name: "TasksComments");
        }
    }
}
