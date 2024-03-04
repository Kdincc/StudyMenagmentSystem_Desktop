using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task8.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeacherMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "GROUPS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GROUPS_TeacherId",
                table: "GROUPS",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_GROUPS_Teachers_TeacherId",
                table: "GROUPS",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GROUPS_Teachers_TeacherId",
                table: "GROUPS");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_GROUPS_TeacherId",
                table: "GROUPS");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "GROUPS");
        }
    }
}
