using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project01_EFCore_Intro.Migrations
{
    /// <inheritdoc />
    public partial class AddTagAndNoteTagData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "İş" },
                    { 2, "Aile" },
                    { 3, "Arkadaş" },
                    { 4, "Diğer" }
                });

            migrationBuilder.InsertData(
                table: "NoteTags",
                columns: new[] { "NoteId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NoteTags",
                keyColumns: new[] { "NoteId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "NoteTags",
                keyColumns: new[] { "NoteId", "TagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "NoteTags",
                keyColumns: new[] { "NoteId", "TagId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "NoteTags",
                keyColumns: new[] { "NoteId", "TagId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "NoteTags",
                keyColumns: new[] { "NoteId", "TagId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "NoteTags",
                keyColumns: new[] { "NoteId", "TagId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "NoteTags",
                keyColumns: new[] { "NoteId", "TagId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "NoteTags",
                keyColumns: new[] { "NoteId", "TagId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "NoteTags",
                keyColumns: new[] { "NoteId", "TagId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
