﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class CustomTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key for the category")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Categories for the library");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key for the book")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Title of the book"),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Author of the book"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false, comment: "Description of the book"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image URL of the book"),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Rating of the book"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category Id of the book")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Books for the library");

            migrationBuilder.CreateTable(
                name: "IdentityUserBook",
                columns: table => new
                {
                    CollectorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Id of the collector"),
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "Id of the book")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserBook", x => new { x.CollectorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_IdentityUserBook_AspNetUsers_CollectorId",
                        column: x => x.CollectorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserBook_BookId",
                table: "IdentityUserBook",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserBook");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
