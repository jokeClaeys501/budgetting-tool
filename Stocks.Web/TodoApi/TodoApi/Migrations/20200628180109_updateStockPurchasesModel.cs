using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class updateStockPurchasesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "StockPurchases");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "StockPurchases",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "BuyOrSell",
                table: "StockPurchases",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LongOrShort",
                table: "StockPurchases",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PricePerShare",
                table: "StockPurchases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "StockPurchases",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyOrSell",
                table: "StockPurchases");

            migrationBuilder.DropColumn(
                name: "LongOrShort",
                table: "StockPurchases");

            migrationBuilder.DropColumn(
                name: "PricePerShare",
                table: "StockPurchases");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "StockPurchases");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "StockPurchases",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "StockPurchases",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
