using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dapper.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sch");

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country_Code = table.Column<int>(type: "int", maxLength: 32, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false),
                    CountryCode = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CountryCodes_Users_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "sch",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Merchant",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CountryCode = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchant", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Country_Merchants_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "sch",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Merchant_UserId",
                        column: x => x.UserId,
                        principalSchema: "sch",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false),
                    OrderJson = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_User_Orders_UserID",
                        column: x => x.UserID,
                        principalSchema: "sch",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MerchantId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Price = table.Column<double>(type: "float", maxLength: 32, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Merchant_Products_MerchantId",
                        column: x => x.MerchantId,
                        principalSchema: "sch",
                        principalTable: "Merchant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersItem", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Order_OrderItems_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "sch",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_OrderItems_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "sch",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Country",
                columns: new[] { "Id", "Country_Code", "Name" },
                values: new object[,]
                {
                    { 1, 65346, "USA" },
                    { 2, 54356, "Canada" },
                    { 3, 35425, "Pakistan" },
                    { 4, 65467, "Serbia" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "User",
                columns: new[] { "Id", "CountryCode", "CountryId", "CreatedAt", "DateOfBirth", "Email", "FullName", "Gender" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2021, 7, 11, 23, 14, 55, 41, DateTimeKind.Local).AddTicks(6350), new DateTime(2005, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jons@mail.com", "Tom Jons", "Male" },
                    { 2, null, 2, new DateTime(2021, 7, 11, 23, 14, 55, 46, DateTimeKind.Local).AddTicks(1920), new DateTime(1999, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ken@mail.com", "Sara Ken", "Female" },
                    { 3, null, 3, new DateTime(2021, 7, 11, 23, 14, 55, 46, DateTimeKind.Local).AddTicks(1980), new DateTime(1998, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Son@mail.com", "Justin Son", "Male" },
                    { 4, null, 4, new DateTime(2021, 7, 11, 23, 14, 55, 46, DateTimeKind.Local).AddTicks(1987), new DateTime(1995, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yon@mail.com", "Nasty Yon", "Female" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Merchant",
                columns: new[] { "Id", "CountryCode", "CountryId", "CreatedAt", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 0, 1, new DateTime(2021, 7, 11, 23, 14, 55, 48, DateTimeKind.Local).AddTicks(1270), "Tom", 1 },
                    { 2, 0, 2, new DateTime(2021, 7, 11, 23, 14, 55, 48, DateTimeKind.Local).AddTicks(3368), "Sara", 2 }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Order",
                columns: new[] { "Id", "CreatedAt", "OrderJson", "Status", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 11, 23, 14, 55, 48, DateTimeKind.Local).AddTicks(5884), "{\"OrderId\":1,\"User\":{\"FullName\":\"Tom Jons\",\"Email\":\"Jons@mail.com\"},\"Products\":[{\"Name\":\"Computer\",\"Price\":\"2000\",\"merchant\":{\"Name\":\"Tom\"}}]}", "in the process", 1 },
                    { 2, new DateTime(2021, 7, 11, 23, 14, 55, 184, DateTimeKind.Local).AddTicks(7014), "{\"OrderId\":1,\"User\":{\"FullName\":\"Tom Jons\",\"Email\":\"Jons@mail.com\"},\"Products\":[{\"Name\":\"DVD\",\"Price\":\"1000\",\"merchant\":{\"Name\":\"Tom\"}}]}", "in the process", 1 },
                    { 3, new DateTime(2021, 7, 11, 23, 14, 55, 184, DateTimeKind.Local).AddTicks(8150), "{\"OrderId\":1,\"User\":{\"FullName\":\"Sara Ken\",\"Email\":\"Ken@mail.com\"},\"Products\":[{\"Name\":\"Smart TV\",\"Price\":\"4000\",\"merchant\":{\"Name\":\"Sara\"}}]}", "Finished", 2 }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Product",
                columns: new[] { "Id", "CreatedAt", "MerchantId", "Name", "Price", "Status" },
                values: new object[] { 1, new DateTime(2021, 7, 11, 23, 14, 55, 185, DateTimeKind.Local).AddTicks(304), 1, "Computer", 2000.0, "In the process" });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Product",
                columns: new[] { "Id", "CreatedAt", "MerchantId", "Name", "Price", "Status" },
                values: new object[] { 2, new DateTime(2021, 7, 11, 23, 14, 55, 185, DateTimeKind.Local).AddTicks(979), 1, "DVD", 1000.0, "In the process" });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Product",
                columns: new[] { "Id", "CreatedAt", "MerchantId", "Name", "Price", "Status" },
                values: new object[] { 3, new DateTime(2021, 7, 11, 23, 14, 55, 185, DateTimeKind.Local).AddTicks(995), 2, "Smart TV", 4000.0, "Finished" });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[] { 1, 1, 1, 2 });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[] { 2, 2, 2, 1 });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[] { 3, 3, 3, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Merchant_CountryId",
                schema: "sch",
                table: "Merchant",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchant_UserId",
                schema: "sch",
                table: "Merchant",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                schema: "sch",
                table: "Order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "sch",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                schema: "sch",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MerchantId",
                schema: "sch",
                table: "Product",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CountryId",
                schema: "sch",
                table: "User",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Merchant",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "User",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "sch");
        }
    }
}
