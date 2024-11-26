using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WealthSphere.Repository.Migrations
{
    public partial class FeedbackCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisuallyAppealing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EasyToAccess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnyChangesRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MostLikedFeature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");
        }
    }
}
