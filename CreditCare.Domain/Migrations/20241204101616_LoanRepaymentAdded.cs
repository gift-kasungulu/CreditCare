using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCare.App.Web.Data.Migrations
{
    public partial class LoanRepaymentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RepaymentAmount",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepaymentAmount",
                table: "Loans");
        }
    }
}
