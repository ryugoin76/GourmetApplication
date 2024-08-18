using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gourmet",
                columns: table => new
                {
                    GourmetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoumetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrefectureCode = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gourmet", x => x.GourmetId);
                });

            migrationBuilder.CreateTable(
                name: "Prefecture",
                columns: table => new
                {
                    PrefectureCode = table.Column<int>(type: "int", nullable: false),
                    PrefectureName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefecture", x => x.PrefectureCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gourmet");

            migrationBuilder.DropTable(
                name: "Prefecture");
        }
    }
}
