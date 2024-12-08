using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCare.App.Web.Data.Migrations
{
    public partial class ChangingtheCollateralAndLoanIdconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaterals_CollateralStatus_CollateralStatusId",
                table: "Collaterals");

            migrationBuilder.DropForeignKey(
                name: "FK_Collaterals_Loans_LoanId",
                table: "Collaterals");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaterals_CollateralStatus_CollateralStatusId",
                table: "Collaterals",
                column: "CollateralStatusId",
                principalTable: "CollateralStatus",
                principalColumn: "CollateralStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Collaterals_Loans_LoanId",
                table: "Collaterals",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "LoanId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaterals_CollateralStatus_CollateralStatusId",
                table: "Collaterals");

            migrationBuilder.DropForeignKey(
                name: "FK_Collaterals_Loans_LoanId",
                table: "Collaterals");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaterals_CollateralStatus_CollateralStatusId",
                table: "Collaterals",
                column: "CollateralStatusId",
                principalTable: "CollateralStatus",
                principalColumn: "CollateralStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Collaterals_Loans_LoanId",
                table: "Collaterals",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "LoanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
