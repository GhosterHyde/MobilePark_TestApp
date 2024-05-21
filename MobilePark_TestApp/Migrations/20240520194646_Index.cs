using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobilePark_TestApp.Migrations
{
    /// <inheritdoc />
    public partial class Index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Keyword",
                table: "Results",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Results_Keyword_SearchIn_Language",
                table: "Results",
                columns: new[] { "Keyword", "SearchIn", "Language" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Results_Keyword_SearchIn_Language",
                table: "Results");

            migrationBuilder.AlterColumn<string>(
                name: "Keyword",
                table: "Results",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
