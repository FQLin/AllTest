using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Demo1",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 32, nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Demo1", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Demo1");
        }
    }
}
