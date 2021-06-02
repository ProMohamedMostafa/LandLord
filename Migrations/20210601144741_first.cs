using Microsoft.EntityFrameworkCore.Migrations;

namespace GenieLandLoardSolution.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbLandLoard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLandLoard", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__tbLandLo__737584F6DD37B7C2",
                table: "tbLandLoard",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__tbLandLo__FD349E5384C96225",
                table: "tbLandLoard",
                column: "Domain",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbLandLoard");
        }
    }
}
