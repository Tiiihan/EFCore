using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_Notes.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CategoryID",
                table: "Notes",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Category_CategoryID",
                table: "Notes",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Category_CategoryID",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CategoryID",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Notes");
        }
    }
}
