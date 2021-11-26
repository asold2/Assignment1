using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentWebAPI.Migrations
{
    public partial class JobProblemForeignKey5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Persons",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle_JobTitle",
                table: "Persons",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobTitle_Salary",
                table: "Persons",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobTitle_JobTitle",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "JobTitle_Salary",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Persons",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    AdultId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Salary = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.AdultId);
                    table.ForeignKey(
                        name: "FK_Jobs_Persons_AdultId",
                        column: x => x.AdultId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
