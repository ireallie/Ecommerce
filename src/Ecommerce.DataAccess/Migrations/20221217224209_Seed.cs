using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.DataAccess.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreatedDate", "DeletedDate", "Description", "IsActive", "Label", "Name", "OldPrice", "RegularPrice", "UpdatedDate" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 12, 17, 22, 42, 8, 614, DateTimeKind.Unspecified).AddTicks(3048), new TimeSpan(0, 0, 0, 0, 0)), null, "T-shirt the hate,100 cotton, machine embroidery, oversized fit.\r\n                                so much hate for me everywhere today, can't figure out what i did to cause it... i am trying to ovrercome, to overcome it all.", true, "preorder", "t-shirt the hate", null, 3000m, null });

            migrationBuilder.InsertData(
                table: "Variations",
                columns: new[] { "VariationId", "Name" },
                values: new object[] { 1, "Color" });

            migrationBuilder.InsertData(
                table: "Variations",
                columns: new[] { "VariationId", "Name" },
                values: new object[] { 2, "Size" });

            migrationBuilder.InsertData(
                table: "ProductItems",
                columns: new[] { "ProductItemId", "ProductId", "QuantityInStock", "SKU" },
                values: new object[,]
                {
                    { 1, 1, 50, "HATE-000-S-M" },
                    { 2, 1, 50, "HATE-000-M-L" },
                    { 3, 1, 50, "HATE-000-XL+" },
                    { 4, 1, 50, "HATE-FFF-S-M" },
                    { 5, 1, 50, "HATE-FFF-M-L" },
                    { 6, 1, 50, "HATE-FFF-XL+" }
                });

            migrationBuilder.InsertData(
                table: "VariationOptions",
                columns: new[] { "VariationOptionId", "Value", "VariationId" },
                values: new object[,]
                {
                    { 1, "White", 1 },
                    { 2, "Black", 1 },
                    { 3, "S-M", 2 },
                    { 4, "M-L", 2 },
                    { 5, "XL+", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductItemsVariationOptions",
                columns: new[] { "ProductItemId", "VariationOptionId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 1, 3 },
                    { 4, 3 },
                    { 2, 4 },
                    { 5, 4 },
                    { 3, 5 },
                    { 6, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductItemsVariationOptions",
                keyColumns: new[] { "ProductItemId", "VariationOptionId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductItemsVariationOptions",
                keyColumns: new[] { "ProductItemId", "VariationOptionId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProductItemsVariationOptions",
                keyColumns: new[] { "ProductItemId", "VariationOptionId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductItemsVariationOptions",
                keyColumns: new[] { "ProductItemId", "VariationOptionId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProductItemsVariationOptions",
                keyColumns: new[] { "ProductItemId", "VariationOptionId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProductItemsVariationOptions",
                keyColumns: new[] { "ProductItemId", "VariationOptionId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ProductItemsVariationOptions",
                keyColumns: new[] { "ProductItemId", "VariationOptionId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProductItemsVariationOptions",
                keyColumns: new[] { "ProductItemId", "VariationOptionId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "ProductItemsVariationOptions",
                keyColumns: new[] { "ProductItemId", "VariationOptionId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProductItemsVariationOptions",
                keyColumns: new[] { "ProductItemId", "VariationOptionId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "ProductItemsVariationOptions",
                keyColumns: new[] { "ProductItemId", "VariationOptionId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ProductItemsVariationOptions",
                keyColumns: new[] { "ProductItemId", "VariationOptionId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "ProductItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VariationOptions",
                keyColumn: "VariationOptionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VariationOptions",
                keyColumn: "VariationOptionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VariationOptions",
                keyColumn: "VariationOptionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VariationOptions",
                keyColumn: "VariationOptionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VariationOptions",
                keyColumn: "VariationOptionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Variations",
                keyColumn: "VariationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Variations",
                keyColumn: "VariationId",
                keyValue: 2);
        }
    }
}
