using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_Website.Migrations
{
    public partial class UpdatedHeaders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Borrower",
                table: "Items",
                newName: "AssociatedCourse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssociatedCourse",
                table: "Items",
                newName: "Borrower");
        }
    }
}
