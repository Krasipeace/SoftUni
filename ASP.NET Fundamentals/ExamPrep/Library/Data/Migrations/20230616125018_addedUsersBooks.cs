using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class addedUsersBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserBook_AspNetUsers_CollectorId",
                table: "IdentityUserBook");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserBook_Books_BookId",
                table: "IdentityUserBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserBook",
                table: "IdentityUserBook");

            migrationBuilder.RenameTable(
                name: "IdentityUserBook",
                newName: "UsersBooks");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserBook_BookId",
                table: "UsersBooks",
                newName: "IX_UsersBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersBooks",
                table: "UsersBooks",
                columns: new[] { "CollectorId", "BookId" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Biography" },
                    { 3, "Children" },
                    { 4, "Crime" },
                    { 5, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ImageUrl", "Rating", "Title" },
                values: new object[] { 5, "Dolor Sit", 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "https://img.freepik.com/free-psd/book-cover-mock-up-arrangement_23-2148622888.jpg?w=826&t=st=1666106877~exp=1666107477~hmac=5dea3e5634804683bccfebeffdbde98371db37bc2d1a208f074292c862775e1b", 9.5m, "Lorem Ipsum" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBooks_AspNetUsers_CollectorId",
                table: "UsersBooks",
                column: "CollectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBooks_Books_BookId",
                table: "UsersBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersBooks_AspNetUsers_CollectorId",
                table: "UsersBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersBooks_Books_BookId",
                table: "UsersBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersBooks",
                table: "UsersBooks");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "UsersBooks",
                newName: "IdentityUserBook");

            migrationBuilder.RenameIndex(
                name: "IX_UsersBooks_BookId",
                table: "IdentityUserBook",
                newName: "IX_IdentityUserBook_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserBook",
                table: "IdentityUserBook",
                columns: new[] { "CollectorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserBook_AspNetUsers_CollectorId",
                table: "IdentityUserBook",
                column: "CollectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserBook_Books_BookId",
                table: "IdentityUserBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
