using Microsoft.EntityFrameworkCore.Migrations;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class ProductRecord_Added_IsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailRecord_OrderDetailStatusRecord_StatusId",
                table: "OrderDetailRecord");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetailRecord_StatusId",
                table: "OrderDetailRecord");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "OrderDetailRecord",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "StatusId1",
                table: "OrderDetailRecord",
                nullable: true);

            migrationBuilder.InsertData(
                table: "OrderDetailStatusRecord",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { (byte)0, "None" },
                    { (byte)1, "Allocated" },
                    { (byte)2, "Invoiced" },
                    { (byte)3, "Shipped" },
                    { (byte)4, "OnOrder" },
                    { (byte)5, "NoStock" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatusRecord",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { (byte)0, "None" },
                    { (byte)1, "New" },
                    { (byte)2, "Invoiced" },
                    { (byte)3, "Shipped" },
                    { (byte)4, "Closed" },
                    { (byte)7, "Submitted" },
                    { (byte)8, "Cancelled" },
                    { (byte)9, "Archived" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailRecord_StatusId1",
                table: "OrderDetailRecord",
                column: "StatusId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailRecord_OrderDetailStatusRecord_StatusId1",
                table: "OrderDetailRecord",
                column: "StatusId1",
                principalTable: "OrderDetailStatusRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailRecord_OrderDetailStatusRecord_StatusId1",
                table: "OrderDetailRecord");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetailRecord_StatusId1",
                table: "OrderDetailRecord");

            migrationBuilder.DeleteData(
                table: "OrderDetailStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)0);

            migrationBuilder.DeleteData(
                table: "OrderDetailStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "OrderDetailStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "OrderDetailStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "OrderDetailStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "OrderDetailStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "OrderStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)0);

            migrationBuilder.DeleteData(
                table: "OrderStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "OrderStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "OrderStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "OrderStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "OrderStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "OrderStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "OrderStatusRecord",
                keyColumn: "Id",
                keyValue: (byte)9);

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StatusId1",
                table: "OrderDetailRecord");

            migrationBuilder.AlterColumn<byte>(
                name: "StatusId",
                table: "OrderDetailRecord",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailRecord_StatusId",
                table: "OrderDetailRecord",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailRecord_OrderDetailStatusRecord_StatusId",
                table: "OrderDetailRecord",
                column: "StatusId",
                principalTable: "OrderDetailStatusRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
