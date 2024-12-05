using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCare.App.Web.Data.Migrations
{
    public partial class LoanProductAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoanProductId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LoanProducts",
                columns: table => new
                {
                    LoanProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaximumAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DefaultInterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanProducts", x => x.LoanProductId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_LoanProductId",
                table: "Loans",
                column: "LoanProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_LoanProducts_LoanProductId",
                table: "Loans",
                column: "LoanProductId",
                principalTable: "LoanProducts",
                principalColumn: "LoanProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_LoanProducts_LoanProductId",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "LoanProducts");

            migrationBuilder.DropIndex(
                name: "IX_Loans_LoanProductId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LoanProductId",
                table: "Loans");
        }
    }
}
