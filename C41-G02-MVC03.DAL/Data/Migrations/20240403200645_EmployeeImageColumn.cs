using Microsoft.EntityFrameworkCore.Migrations;

namespace C41_G02_MVC03.DAL.Data.Migrations
{
    public partial class EmployeeImageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "VideoName",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PdfName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
