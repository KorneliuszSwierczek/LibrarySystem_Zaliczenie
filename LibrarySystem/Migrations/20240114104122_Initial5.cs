using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Categories", "Description", "PublicationYear", "Title" },
                values: new object[] { 1, "F. Scott Fitzgerald", "Fiction, Classic", "A novel about the American Dream", 1925, "The Great Gatsby" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Categories", "Description", "PublicationYear", "Title" },
                values: new object[] { 2, "Harper Lee", "Fiction, Classic", "A classic of modern American literature", 1960, "To Kill a Mockingbird" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Categories", "Description", "PublicationYear", "Title" },
                values: new object[] { 3, "J.R.R. Tolkien", "Fantasy, Adventure", "A fantasy classic", 1937, "The Hobbit" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
