using Microsoft.EntityFrameworkCore.Migrations;

namespace Notes.Persistence.Migrations
{
    public partial class Remove_Note_Autor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Notes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Notes",
                type: "TEXT",
                nullable: true);
        }
    }
}
