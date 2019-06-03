using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class ProductActiveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b13ba46-a491-4133-876a-8c7c541d5b70");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "19c53dd5-1abd-43af-8420-620756427dea", 0, "68d9d3b2-84e1-4d9b-83ce-e732b7d6f057", "admin@admin.com", true, "Admina", "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEBT1rrryBDbvJe4qsoo2UsCoK2t/h4UIIi3PhgGnfRA8x2yQ+ZjXzh9ueUOj0rwU7A==", null, false, "23ea2d53-3b7c-4086-bc43-fd66b7be78b0", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "UserId",
                value: "19c53dd5-1abd-43af-8420-620756427dea");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 1,
                column: "UserId",
                value: "19c53dd5-1abd-43af-8420-620756427dea");

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 2,
                column: "UserId",
                value: "19c53dd5-1abd-43af-8420-620756427dea");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "UserId",
                value: "19c53dd5-1abd-43af-8420-620756427dea");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "UserId",
                value: "19c53dd5-1abd-43af-8420-620756427dea");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19c53dd5-1abd-43af-8420-620756427dea");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Product");

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
