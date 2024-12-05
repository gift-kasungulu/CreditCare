using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCare.App.Web.Data.Migrations
{
    public partial class LoanClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeriodType",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RepaymentCycles",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodType",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "RepaymentCycles",
                table: "Loans");
        }
    }
}
