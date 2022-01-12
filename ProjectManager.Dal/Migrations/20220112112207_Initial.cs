using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Dal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentType = table.Column<byte>(type: "tinyint", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskComments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreateTime", "ProjectName", "UpdateTime" },
                values: new object[] { new Guid("2f147c0c-bb45-4921-b0a0-8d5ee523bc6d"), new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Local), "Проект 3", new DateTime(2022, 1, 12, 12, 22, 7, 658, DateTimeKind.Local).AddTicks(325) });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreateTime", "ProjectName", "UpdateTime" },
                values: new object[] { new Guid("5379b990-ad12-4b4d-b7c0-4ad16971afb0"), new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Local), "Проект 1", new DateTime(2022, 1, 12, 14, 22, 7, 658, DateTimeKind.Local).AddTicks(309) });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreateTime", "ProjectName", "UpdateTime" },
                values: new object[] { new Guid("e9a6f07c-0cc6-42d7-9521-6e5b57e0c5be"), new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Local), "Проект 2", new DateTime(2022, 1, 12, 13, 22, 7, 658, DateTimeKind.Local).AddTicks(321) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CancelDate", "CreateDate", "ProjectId", "StartDate", "TaskName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("09fdf810-670e-41a5-b0ca-1da4c32d34f5"), new DateTime(2022, 1, 10, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 10, 1, 0, 0, 0, DateTimeKind.Local), new Guid("2f147c0c-bb45-4921-b0a0-8d5ee523bc6d"), new DateTime(2022, 1, 10, 2, 0, 0, 0, DateTimeKind.Local), "Задача 2", new DateTime(2022, 1, 10, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("45a8ea5c-cf9b-49dc-b548-b693ede2f2db"), new DateTime(2022, 1, 11, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 11, 1, 0, 0, 0, DateTimeKind.Local), new Guid("e9a6f07c-0cc6-42d7-9521-6e5b57e0c5be"), new DateTime(2022, 1, 11, 2, 0, 0, 0, DateTimeKind.Local), "Задача 5", new DateTime(2022, 1, 11, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("5dff7146-9455-4bea-86c0-273273783148"), new DateTime(2022, 1, 10, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 10, 1, 0, 0, 0, DateTimeKind.Local), new Guid("2f147c0c-bb45-4921-b0a0-8d5ee523bc6d"), new DateTime(2022, 1, 10, 2, 0, 0, 0, DateTimeKind.Local), "Задача 7", new DateTime(2022, 1, 10, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("6876d5ef-2ba5-4e06-abd2-a1b2c4a19b5e"), new DateTime(2022, 1, 12, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 12, 1, 0, 0, 0, DateTimeKind.Local), new Guid("5379b990-ad12-4b4d-b7c0-4ad16971afb0"), new DateTime(2022, 1, 12, 2, 0, 0, 0, DateTimeKind.Local), "Задача 8", new DateTime(2022, 1, 12, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("74750387-4dce-4df4-a65c-93a049440c9a"), new DateTime(2022, 1, 12, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 12, 1, 0, 0, 0, DateTimeKind.Local), new Guid("5379b990-ad12-4b4d-b7c0-4ad16971afb0"), new DateTime(2022, 1, 12, 2, 0, 0, 0, DateTimeKind.Local), "Задача 4", new DateTime(2022, 1, 12, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("7de5aa29-48b0-4127-bec3-5ccb7cefda57"), new DateTime(2022, 1, 12, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 12, 1, 0, 0, 0, DateTimeKind.Local), new Guid("5379b990-ad12-4b4d-b7c0-4ad16971afb0"), new DateTime(2022, 1, 12, 2, 0, 0, 0, DateTimeKind.Local), "Задача 1", new DateTime(2022, 1, 12, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("8f4ac320-04c2-42eb-88a2-b082792f7fa4"), new DateTime(2022, 1, 11, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 11, 1, 0, 0, 0, DateTimeKind.Local), new Guid("e9a6f07c-0cc6-42d7-9521-6e5b57e0c5be"), new DateTime(2022, 1, 11, 2, 0, 0, 0, DateTimeKind.Local), "Задача 3", new DateTime(2022, 1, 11, 3, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("c7a689f6-3b18-4809-891a-095fdc9e0425"), new DateTime(2022, 1, 11, 5, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 11, 1, 0, 0, 0, DateTimeKind.Local), new Guid("e9a6f07c-0cc6-42d7-9521-6e5b57e0c5be"), new DateTime(2022, 1, 11, 2, 0, 0, 0, DateTimeKind.Local), "Задача 6", new DateTime(2022, 1, 11, 3, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "TaskComments",
                columns: new[] { "Id", "CommentType", "Content", "TaskId" },
                values: new object[,]
                {
                    { new Guid("0336d6f1-41d0-4b39-976b-56f291a619bb"), (byte)1, new byte[] { 83, 116, 114, 105, 110, 103, 32, 98, 117, 105, 108, 100, 101, 114, 63 }, new Guid("45a8ea5c-cf9b-49dc-b548-b693ede2f2db") },
                    { new Guid("3d27139d-b49a-4b4c-8292-08c01622b94c"), (byte)1, new byte[] { 208, 157, 208, 181, 208, 190, 208, 177, 209, 133, 208, 190, 208, 180, 208, 184, 208, 188, 208, 190, 32, 209, 129, 208, 190, 208, 178, 208, 181, 209, 137, 208, 176, 208, 189, 208, 184, 208, 181 }, new Guid("6876d5ef-2ba5-4e06-abd2-a1b2c4a19b5e") },
                    { new Guid("5fcd8a87-2573-468a-8d68-424447a0da74"), (byte)1, new byte[] { 46, 78, 101, 116, 32, 208, 184, 208, 187, 208, 184, 32, 46, 78, 101, 116, 32, 67, 111, 114, 101, 63 }, new Guid("5dff7146-9455-4bea-86c0-273273783148") },
                    { new Guid("62aafd28-8678-4e2e-9ea6-148e0ff46e0f"), (byte)1, new byte[] { 208, 159, 209, 128, 208, 184, 208, 178, 208, 181, 209, 130, 44, 32, 208, 188, 208, 184, 209, 128, 33 }, new Guid("7de5aa29-48b0-4127-bec3-5ccb7cefda57") },
                    { new Guid("7adc77dc-3085-44ba-9cf6-de1b64021ee6"), (byte)1, new byte[] { 208, 162, 208, 181, 209, 129, 209, 130, 208, 190, 208, 178, 209, 139, 208, 185, 32, 208, 186, 208, 190, 208, 188, 208, 188, 208, 181, 208, 189, 209, 130, 208, 176, 209, 128, 208, 184, 208, 185 }, new Guid("8f4ac320-04c2-42eb-88a2-b082792f7fa4") },
                    { new Guid("7b04f6e8-cbd6-499a-a2c4-ef3038b8f43e"), (byte)1, new byte[] { 208, 167, 209, 130, 208, 190, 32, 208, 188, 208, 190, 208, 182, 208, 189, 208, 190, 32, 209, 129, 208, 180, 208, 181, 208, 187, 208, 176, 209, 130, 209, 140, 32, 209, 129, 32, 209, 141, 209, 130, 208, 184, 208, 188, 63 }, new Guid("09fdf810-670e-41a5-b0ca-1da4c32d34f5") },
                    { new Guid("7f5b5cc8-5e68-4478-9eeb-e3a2ee49808b"), (byte)1, new byte[] { 83, 116, 114, 105, 110, 103, 32, 98, 117, 105, 108, 100, 101, 114 }, new Guid("c7a689f6-3b18-4809-891a-095fdc9e0425") },
                    { new Guid("8b286f92-96a3-4279-97ec-2ffb7eac6a8b"), (byte)1, new byte[] { 68, 82, 79, 80, 32, 68, 65, 84, 65, 66, 65, 83, 69 }, new Guid("74750387-4dce-4df4-a65c-93a049440c9a") },
                    { new Guid("92b7f6aa-0887-48fb-ab4b-b795a4c61dbb"), (byte)1, new byte[] { 208, 152, 208, 189, 209, 130, 208, 181, 209, 128, 208, 181, 209, 129, 208, 189, 209, 139, 208, 181, 32, 208, 183, 208, 176, 208, 180, 208, 176, 209, 135, 208, 184 }, new Guid("7de5aa29-48b0-4127-bec3-5ccb7cefda57") },
                    { new Guid("aaf1488f-c71d-416c-a711-6d9db2551f10"), (byte)1, new byte[] { 208, 162, 209, 128, 208, 181, 208, 177, 209, 131, 208, 181, 209, 130, 209, 129, 209, 143, 32, 208, 190, 208, 191, 209, 130, 208, 184, 208, 188, 208, 184, 208, 183, 208, 176, 209, 134, 208, 184, 209, 143 }, new Guid("74750387-4dce-4df4-a65c-93a049440c9a") },
                    { new Guid("be9ac29a-4e87-49dc-8513-5a68c8498784"), (byte)1, new byte[] { 208, 151, 208, 176, 208, 180, 208, 176, 209, 135, 209, 131, 32, 208, 189, 208, 181, 32, 209, 128, 208, 181, 209, 136, 208, 184, 209, 130, 209, 140, 46 }, new Guid("8f4ac320-04c2-42eb-88a2-b082792f7fa4") },
                    { new Guid("dcdd83f3-d832-40c2-841d-6582ad30d06e"), (byte)1, new byte[] { 208, 157, 208, 181, 209, 133, 208, 178, 208, 176, 209, 130, 208, 176, 208, 181, 209, 130, 32, 208, 190, 208, 191, 208, 184, 209, 129, 208, 176, 208, 189, 208, 184, 209, 143, 32, 208, 183, 208, 176, 208, 180, 208, 176, 209, 135, 208, 184, 46 }, new Guid("09fdf810-670e-41a5-b0ca-1da4c32d34f5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_TaskId",
                table: "TaskComments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
