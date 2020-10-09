using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseManager.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DisplaySize = table.Column<int>(nullable: false),
                    DisplayType = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    Battery = table.Column<bool>(nullable: false),
                    TouchScreen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
