using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sch");

            migrationBuilder.CreateTable(
                name: "Directories",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentDirectoryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directories", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Directory_File_DirectoryId",
                        column: x => x.DirectoryId,
                        principalSchema: "sch",
                        principalTable: "Directories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DirectoryPermissions",
                schema: "sch",
                columns: table => new
                {
                    DirectoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CanRead = table.Column<bool>(type: "bit", nullable: false),
                    CanWrite = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryPermissions", x => new { x.UserId, x.DirectoryId });
                    table.ForeignKey(
                        name: "FK_DirectoryPermissions_Directory_DirectoryId",
                        column: x => x.DirectoryId,
                        principalSchema: "sch",
                        principalTable: "Directories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DirectoryPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AudioFiles",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Bitrate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelCount = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFiles", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_AudioFiles_Files_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilePermissions",
                schema: "sch",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CanRead = table.Column<bool>(type: "bit", nullable: false),
                    CanWrite = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilePermissions", x => new { x.UserId, x.FileId });
                    table.ForeignKey(
                        name: "FK_FilePermissions_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "sch",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilePermissions_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFiles",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Heigth = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFiles", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_ImageFiles_Files_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TextFiles",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextFiles", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_TextFiles_Files_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoFiles",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoFiles", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_VideoFiles_Files_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Directories",
                columns: new[] { "Id", "ParentDirectoryId", "Title" },
                values: new object[,]
                {
                    { 1, null, "C:" },
                    { 2, null, "F:" },
                    { 3, 1, "Users" },
                    { 4, 2, "MyFiles" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "UserName" },
                values: new object[,]
                {
                    { 1, "Vlad@ukrnet.com", "1324sdtr4", "Vlad" },
                    { 2, "Polya@gmail.com", "654634hfga", "Polya" },
                    { 3, "Danya@gmail.com", "s54436366", "Danya" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "DirectoryPermissions",
                columns: new[] { "DirectoryId", "UserId", "CanRead", "CanWrite", "Id" },
                values: new object[,]
                {
                    { 4, 3, true, true, 0 },
                    { 2, 3, true, true, 0 },
                    { 1, 3, true, false, 0 },
                    { 4, 2, true, true, 0 },
                    { 3, 2, false, false, 0 },
                    { 2, 2, true, false, 0 },
                    { 1, 2, true, false, 0 },
                    { 4, 1, true, true, 0 },
                    { 3, 1, true, true, 0 },
                    { 2, 1, true, true, 0 },
                    { 1, 1, true, true, 0 },
                    { 3, 3, true, false, 0 }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Files",
                columns: new[] { "Id", "DirectoryId", "Extension", "Size", "Title" },
                values: new object[,]
                {
                    { 8, 4, ".wmv", "5 Gb", "Hero" },
                    { 11, 4, ".docx", "2 Mb", "Wishes" },
                    { 6, 4, ".jpg", "2 Mb", "Apple" },
                    { 3, 4, ".mp3", "7 Mb", "Country" },
                    { 1, 4, ".mp3", "5 Mb", "Rock" },
                    { 9, 3, ".mp4", "1 Gb", "777" },
                    { 10, 3, ".txt", "3 Mb", "Dictionary" },
                    { 5, 3, ".jpg", "2 Mb", "War" },
                    { 2, 3, ".ogg", "10 Mb", "Pop" },
                    { 7, 2, ".mp4", "2 Gb", "Romantic" },
                    { 12, 4, ".docx", "800 Mb", "Zero" },
                    { 4, 1, ".jpg", "1 Mb", "Art" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "AudioFiles",
                columns: new[] { "Id", "Bitrate", "ChannelCount", "Duration", "SampleRate" },
                values: new object[,]
                {
                    { 1, "320kbps", 2, new TimeSpan(0, 5, 30, 30, 0), "192 кГц" },
                    { 3, "480kbps", 3, new TimeSpan(0, 4, 25, 25, 0), "192 кГц" },
                    { 2, "160kbps", 4, new TimeSpan(0, 3, 20, 20, 0), "96 кГц" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "FilePermissions",
                columns: new[] { "FileId", "UserId", "CanRead", "CanWrite", "Id" },
                values: new object[,]
                {
                    { 4, 1, false, false, 0 },
                    { 1, 1, true, true, 0 },
                    { 1, 2, true, true, 0 },
                    { 1, 3, true, true, 0 },
                    { 3, 1, true, true, 0 },
                    { 3, 2, true, false, 0 },
                    { 3, 3, false, false, 0 },
                    { 6, 1, false, false, 0 },
                    { 6, 2, false, false, 0 },
                    { 6, 3, true, false, 0 },
                    { 11, 1, true, true, 0 },
                    { 11, 2, true, true, 0 },
                    { 11, 3, true, true, 0 },
                    { 12, 1, false, false, 0 },
                    { 12, 2, false, false, 0 },
                    { 12, 3, false, false, 0 },
                    { 8, 3, true, false, 0 },
                    { 9, 2, false, false, 0 },
                    { 9, 3, false, false, 0 },
                    { 2, 1, true, false, 0 },
                    { 4, 2, false, false, 0 },
                    { 4, 3, false, false, 0 },
                    { 7, 1, true, true, 0 },
                    { 7, 2, true, true, 0 },
                    { 7, 3, true, true, 0 },
                    { 8, 2, true, false, 0 },
                    { 9, 1, false, false, 0 },
                    { 2, 2, true, false, 0 },
                    { 8, 1, true, false, 0 },
                    { 5, 1, true, true, 0 },
                    { 5, 2, true, true, 0 },
                    { 5, 3, true, true, 0 },
                    { 10, 1, true, true, 0 },
                    { 10, 2, true, false, 0 },
                    { 10, 3, true, false, 0 },
                    { 2, 3, true, false, 0 }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "ImageFiles",
                columns: new[] { "Id", "Heigth", "Width" },
                values: new object[,]
                {
                    { 6, 1680, 1280 },
                    { 5, 1280, 720 },
                    { 4, 720, 480 }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "TextFiles",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { 11, "List of wishes" },
                    { 10, "Dictionary text" },
                    { 12, "Zero text" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "VideoFiles",
                columns: new[] { "Id", "Duration", "Height", "Width" },
                values: new object[,]
                {
                    { 9, new TimeSpan(0, 6, 50, 50, 0), 1680, 1280 },
                    { 7, new TimeSpan(0, 1, 15, 21, 0), 720, 480 },
                    { 8, new TimeSpan(0, 2, 25, 20, 0), 1080, 1920 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectoryPermissions_DirectoryId",
                schema: "sch",
                table: "DirectoryPermissions",
                column: "DirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FilePermissions_FileId",
                schema: "sch",
                table: "FilePermissions",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_DirectoryId",
                schema: "sch",
                table: "Files",
                column: "DirectoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioFiles",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "DirectoryPermissions",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "FilePermissions",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "ImageFiles",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "TextFiles",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "VideoFiles",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Directories",
                schema: "sch");
        }
    }
}
