using Microsoft.EntityFrameworkCore.Migrations;

namespace Code_First.Migrations
{
    public partial class StudentHasScholarshipColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Students",
                newName: "LastName");

            migrationBuilder.AddColumn<bool>(
                name: "HasScholarship",
                table: "Students",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasScholarship",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "Lastname");
        }
    }
}
