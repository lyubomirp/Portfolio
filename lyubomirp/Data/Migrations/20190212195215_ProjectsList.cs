using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace identity.Data.Migrations
{
    public partial class ProjectsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mainContent",
                table: "Summary");

            migrationBuilder.DropColumn(
                name: "programsAndIDEs",
                table: "Summary");

            migrationBuilder.DropColumn(
                name: "LeftOrRight",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "ProgramsList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    programsAndIDEs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramsList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramsList");

            migrationBuilder.AddColumn<string>(
                name: "mainContent",
                table: "Summary",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "programsAndIDEs",
                table: "Summary",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeftOrRight",
                table: "Projects",
                nullable: true);
        }
    }
}
