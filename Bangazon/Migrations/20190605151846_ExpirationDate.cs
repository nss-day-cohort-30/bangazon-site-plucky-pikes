using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class ExpirationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "7b13ba46-a491-4133-876a-8c7c541d5b70");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "PaymentType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
            //    values: new object[] { "37c2ed75-b0eb-4fc8-b757-23c94d5238eb", 0, "9f6114fe-41e3-40f5-9b56-09e9422370ca", "admin@admin.com", true, "Admina", "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEE0bvic0CzQM7eeFldhx414OU8W6arJIay7Y0N+3/r7Dp1tWi6i/4rdFsHxKckuW2w==", null, false, "fcd150cd-7105-444f-a3a5-15fb1025431c", "123 Infinity Way", false, "admin@admin.com" });

            //migrationBuilder.UpdateData(
            //    table: "Order",
            //    keyColumn: "OrderId",
            //    keyValue: 1,
            //    column: "UserId",
            //    value: "37c2ed75-b0eb-4fc8-b757-23c94d5238eb");

            //migrationBuilder.UpdateData(
            //    table: "PaymentType",
            //    keyColumn: "PaymentTypeId",
            //    keyValue: 1,
            //    column: "UserId",
            //    value: "37c2ed75-b0eb-4fc8-b757-23c94d5238eb");

            //migrationBuilder.UpdateData(
            //    table: "PaymentType",
            //    keyColumn: "PaymentTypeId",
            //    keyValue: 2,
            //    column: "UserId",
            //    value: "37c2ed75-b0eb-4fc8-b757-23c94d5238eb");

            //migrationBuilder.UpdateData(
            //    table: "Product",
            //    keyColumn: "ProductId",
            //    keyValue: 1,
            //    column: "UserId",
            //    value: "37c2ed75-b0eb-4fc8-b757-23c94d5238eb");

            //migrationBuilder.UpdateData(
            //    table: "Product",
            //    keyColumn: "ProductId",
            //    keyValue: 2,
            //    column: "UserId",
            //    value: "37c2ed75-b0eb-4fc8-b757-23c94d5238eb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "37c2ed75-b0eb-4fc8-b757-23c94d5238eb");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "PaymentType");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7b13ba46-a491-4133-876a-8c7c541d5b70", 0, "b0831cf9-5409-4161-970c-56e8e2b24404", "admin@admin.com", true, "Admina", "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEN5V9+EAoVbjWNzI3nqQipSkMrndrI5ZNcyQA2Nr+DlF5JItyojg62vZLAeY50KyRQ==", null, false, "9f348531-8372-4c02-b24c-5f83ab0a2da1", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "UserId",
                value: "7b13ba46-a491-4133-876a-8c7c541d5b70");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 1,
                column: "UserId",
                value: "7b13ba46-a491-4133-876a-8c7c541d5b70");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 2,
                column: "UserId",
                value: "7b13ba46-a491-4133-876a-8c7c541d5b70");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "UserId",
                value: "7b13ba46-a491-4133-876a-8c7c541d5b70");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "UserId",
                value: "7b13ba46-a491-4133-876a-8c7c541d5b70");
        }
    }
}
