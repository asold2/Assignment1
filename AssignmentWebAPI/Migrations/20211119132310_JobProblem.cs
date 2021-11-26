using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentWebAPI.Migrations
{
    public partial class JobProblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobTitleId",
                table: "Persons",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Salary = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_JobTitleId",
                table: "Persons",
                column: "JobTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Jobs_JobTitleId",
                table: "Persons",
                column: "JobTitleId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Jobs_JobTitleId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Persons_JobTitleId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "JobTitleId",
                table: "Persons");
        }
    }
}
