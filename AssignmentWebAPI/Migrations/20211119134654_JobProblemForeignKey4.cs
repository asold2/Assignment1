using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentWebAPI.Migrations
{
    public partial class JobProblemForeignKey4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Jobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Jobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Jobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
