using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class expirationDate : Migration
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
            //    values: new object[] { "4e71c918-d433-4e30-a300-bd4f9e585a02", 0, "95d4a476-ca12-43d5-a726-57fcc4616b96", "admin@admin.com", true, "Admina", "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEO/UCXY5KDLV1ynIA+NCRQGZRTS6MSvVSML2BGk5OI8f4PYAZrr5hBvZY3tvVzdp3w==", null, false, "eb6b7b72-8411-468a-bb87-0a5ff4039874", "123 Infinity Way", false, "admin@admin.com" });

            //migrationBuilder.UpdateData(
            //    table: "Order",
            //    keyColumn: "OrderId",
            //    keyValue: 1,
            //    column: "UserId",
            //    value: "4e71c918-d433-4e30-a300-bd4f9e585a02");

            //migrationBuilder.UpdateData(
            //    table: "PaymentType",
            //    keyColumn: "PaymentTypeId",
            //    keyValue: 1,
            //    column: "UserId",
            //    value: "4e71c918-d433-4e30-a300-bd4f9e585a02");

            //migrationBuilder.UpdateData(
            //    table: "PaymentType",
            //    keyColumn: "PaymentTypeId",
            //    keyValue: 2,
            //    column: "UserId",
            //    value: "4e71c918-d433-4e30-a300-bd4f9e585a02");

            //migrationBuilder.UpdateData(
            //    table: "Product",
            //    keyColumn: "ProductId",
            //    keyValue: 1,
            //    column: "UserId",
            //    value: "4e71c918-d433-4e30-a300-bd4f9e585a02");

            //migrationBuilder.UpdateData(
            //    table: "Product",
            //    keyColumn: "ProductId",
            //    keyValue: 2,
            //    column: "UserId",
            //    value: "4e71c918-d433-4e30-a300-bd4f9e585a02");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e71c918-d433-4e30-a300-bd4f9e585a02");

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
