using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsParserConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XPathNews = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XPathTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XPathBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XPathDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeCultureInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsParserConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NewsParserConfigs",
                columns: new[] { "Id", "CreatedDate", "DateTimeCultureInfo", "DateTimeFormat", "SiteLink", "UpdatedDate", "XPathBody", "XPathDateTime", "XPathNews", "XPathTitle" },
                values: new object[] { 1, new DateTime(2022, 5, 22, 18, 14, 50, 524, DateTimeKind.Local).AddTicks(329), "ru-RU", "dd MMM yyyy H:mm", "https://lenta.inform.kz/", null, "//div[contains(@class, 'article_container')]//div//div[contains(@class, 'article_body')]", "//div[contains(@class, 'article_container')]//div//div[contains(@class, 'block-date_social_icon')]//div[contains(@class, 'date_article')]", "//a[contains(@class, 'lenta_news_title')]", "//div[contains(@class, 'article_container')]//article//h1" });

            migrationBuilder.InsertData(
                table: "NewsParserConfigs",
                columns: new[] { "Id", "CreatedDate", "DateTimeCultureInfo", "DateTimeFormat", "SiteLink", "UpdatedDate", "XPathBody", "XPathDateTime", "XPathNews", "XPathTitle" },
                values: new object[] { 2, new DateTime(2022, 5, 22, 18, 14, 50, 524, DateTimeKind.Local).AddTicks(689), null, "HH:mm, dd.MM.yyyy", "https://24.kz/ru/", null, "//div[@class='itemBody']", "//ul//li[@class='itemDate']//time", "//a[@class='nspImageWrapper tleft fnull']", "//article[@class='view-article itemView']//div[@class='itemheader']//header//h1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "FirstName", "LastName", "Login", "PasswordHash", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2022, 5, 22, 18, 14, 50, 522, DateTimeKind.Local).AddTicks(9990), "Test", "Testov", "Test", "AQAAAAEAACcQAAAAEEquPo9ZbpqzCp+SFLr0l7WlBiox+n+5/mUyUWnEXbPSfQyten77cA1spUUl3c7C1Q==", null });

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "NewsParserConfigs");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
