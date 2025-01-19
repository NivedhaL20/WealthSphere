using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WealthSphere.Repository.Migrations
{
    public partial class GoalSettingCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoalSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HowMuchIncomeForMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HowMuchSpendForMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HowMuchSaveForMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HowMuchDebtsForMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HowMuchEmergencyFundForMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalSetting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoalSetting");
        }
    }
}
