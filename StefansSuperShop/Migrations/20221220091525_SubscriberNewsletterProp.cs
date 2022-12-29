using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StefansSuperShop.Migrations
{
    public partial class SubscriberNewsletterProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribers_Newsletters_NewsLetterId",
                table: "Subscribers");

            migrationBuilder.DropIndex(
                name: "IX_Subscribers_NewsLetterId",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "NewsLetterId",
                table: "Subscribers");

            migrationBuilder.CreateTable(
                name: "NewsletterSubscriber",
                columns: table => new
                {
                    ReceivedNewslettersNewsLetterId = table.Column<int>(type: "int", nullable: false),
                    SubscribersWhoReceivedNewsletterSubscriberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsletterSubscriber", x => new { x.ReceivedNewslettersNewsLetterId, x.SubscribersWhoReceivedNewsletterSubscriberId });
                    table.ForeignKey(
                        name: "FK_NewsletterSubscriber_Newsletters_ReceivedNewslettersNewsLetterId",
                        column: x => x.ReceivedNewslettersNewsLetterId,
                        principalTable: "Newsletters",
                        principalColumn: "NewsletterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsletterSubscriber_Subscribers_SubscribersWhoReceivedNewsletterSubscriberId",
                        column: x => x.SubscribersWhoReceivedNewsletterSubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "SubscriberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsletterSubscriber_SubscribersWhoReceivedNewsletterSubscriberId",
                table: "NewsletterSubscriber",
                column: "SubscribersWhoReceivedNewsletterSubscriberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsletterSubscriber");

            migrationBuilder.AddColumn<int>(
                name: "NewsLetterId",
                table: "Subscribers",
                type: "int",
                nullable: true);

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
    }
}
