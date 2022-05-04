using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_Website.Migrations
{
    public partial class addAuthorandBookColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookTitle",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookTitle",
                table: "Items");
        }
    }
}
