using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rathee_Arsenal.Migrations
{
    public partial class AddUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserUid = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    BuyerName = table.Column<string>(maxLength: 25, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserUid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
