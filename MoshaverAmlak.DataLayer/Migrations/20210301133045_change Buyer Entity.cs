using Microsoft.EntityFrameworkCore.Migrations;

namespace MoshaverAmlak.DataLayer.Migrations
{
    public partial class changeBuyerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfInvestiment",
                table: "Buyer");

            migrationBuilder.AddColumn<string>(
                name: "InvestimentFrom",
                table: "Buyer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvestimentTo",
                table: "Buyer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvestimentFrom",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "InvestimentTo",
                table: "Buyer");

            migrationBuilder.AddColumn<string>(
                name: "AmountOfInvestiment",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
