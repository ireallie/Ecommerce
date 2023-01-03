using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.DataAccess.Migrations
{
    public partial class Updated_SKU_And_Quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityInStock",
                table: "ProductItems");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Products",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "ProductItems",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductItems",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 1,
                column: "Quantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 2,
                column: "Quantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 3,
                column: "Quantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 4,
                column: "Quantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 5,
                column: "Quantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 6,
                column: "Quantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 1, 1, 23, 3, 29, 74, DateTimeKind.Unspecified).AddTicks(3530), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductItems");

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "ProductItems",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityInStock",
                table: "ProductItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 1,
                column: "QuantityInStock",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 2,
                column: "QuantityInStock",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 3,
                column: "QuantityInStock",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 4,
                column: "QuantityInStock",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 5,
                column: "QuantityInStock",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 6,
                column: "QuantityInStock",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2023, 1, 1, 21, 6, 38, 944, DateTimeKind.Unspecified).AddTicks(5985), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
