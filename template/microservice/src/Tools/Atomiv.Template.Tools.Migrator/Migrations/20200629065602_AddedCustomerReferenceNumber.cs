using Microsoft.EntityFrameworkCore.Migrations;

namespace Atomiv.Template.Tools.Migrator.Migrations
{
    public partial class AddedCustomerReferenceNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItemStatuses",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "OrderItemStatuses",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: (byte)9);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNumber",
                table: "Customers",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "OrderItemStatuses",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "Code",
                value: "Pending");

            migrationBuilder.UpdateData(
                table: "OrderItemStatuses",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "Code",
                value: "Allocated");

            migrationBuilder.UpdateData(
                table: "OrderItemStatuses",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "Code",
                value: "Unavailable");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "Code",
                value: "Draft");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "Code",
                value: "Submitted");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: (byte)4,
                column: "Code",
                value: "Cancelled");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceNumber",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "OrderItemStatuses",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "Code",
                value: "Allocated");

            migrationBuilder.UpdateData(
                table: "OrderItemStatuses",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "Code",
                value: "Invoiced");

            migrationBuilder.UpdateData(
                table: "OrderItemStatuses",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "Code",
                value: "Shipped");

            migrationBuilder.InsertData(
                table: "OrderItemStatuses",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { (byte)4, "OnOrder" },
                    { (byte)5, "NoStock" }
                });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "Code",
                value: "New");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "Code",
                value: "Invoiced");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: (byte)4,
                column: "Code",
                value: "Closed");

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { (byte)7, "Submitted" },
                    { (byte)8, "Cancelled" },
                    { (byte)9, "Archived" }
                });
        }
    }
}
