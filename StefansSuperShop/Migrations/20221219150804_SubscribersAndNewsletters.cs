using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StefansSuperShop.Migrations
{
    public partial class SubscribersAndNewsletters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewsLetterId",
                table: "Subscribers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Newsletters",
                columns: table => new
                {
                    NewsletterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewsletterSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletters", x => x.NewsletterID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_NewsLetterId",
                table: "Subscribers",
                column: "NewsLetterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribers_Newsletters_NewsLetterId",
                table: "Subscribers",
                column: "NewsLetterId",
                principalTable: "Newsletters",
                principalColumn: "NewsletterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Newsletters_NewsLetterId",
                table: "Subscribers");

            migrationBuilder.DropTable(
                name: "Newsletters");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_NewsLetterId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "NewsLetterId",
                table: "Subscribers");
        }
    }
}
