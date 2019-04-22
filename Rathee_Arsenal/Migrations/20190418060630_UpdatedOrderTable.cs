using Microsoft.EntityFrameworkCore.Migrations;

namespace Rathee_Arsenal.Migrations
{
    public partial class UpdatedOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Orders",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Orders");
        }
    }
}
