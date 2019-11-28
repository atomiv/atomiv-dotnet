using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Migrations.Migrations
{
    public partial class RemovedRecordNameSuffix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_customer_customer_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_order_status_status_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_order_detail_status_status_id",
                table: "order_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_order_order_id",
                table: "order_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_product_product_id",
                table: "order_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_status",
                table: "order_status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_detail_status",
                table: "order_detail_status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_detail",
                table: "order_detail");

            migrationBuilder.DropIndex(
                name: "IX_order_detail_status_id",
                table: "order_detail");

            migrationBuilder.DropIndex(
                name: "IX_order_detail_order_id",
                table: "order_detail");

            migrationBuilder.DropIndex(
                name: "IX_order_detail_product_id",
                table: "order_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_customer_id",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_status_id",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "status_id",
                table: "order_detail");

            migrationBuilder.DropColumn(
                name: "order_id",
                table: "order_detail");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "order_detail");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "order");

            migrationBuilder.DropColumn(
                name: "status_id",
                table: "order");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "order_status",
                newName: "OrderStatuses");

            migrationBuilder.RenameTable(
                name: "order_detail_status",
                newName: "OrderDetailStatuses");

            migrationBuilder.RenameTable(
                name: "order_detail",
                newName: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "customer",
                newName: "Customers");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Products",
                newName: "ProductCode");

            migrationBuilder.RenameColumn(
                name: "list_price",
                table: "Products",
                newName: "ListPrice");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "Products",
                newName: "IsListed");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "OrderStatuses",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OrderStatuses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "OrderDetailStatuses",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OrderDetailStatuses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OrderDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "unit_price",
                table: "OrderDetails",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.AddColumn<byte>(
                name: "OrderDetailStatusId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte>(
                name: "OrderStatusId",
                table: "Orders",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStatuses",
                table: "OrderStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetailStatuses",
                table: "OrderDetailStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderDetailStatusId",
                table: "OrderDetails",
                column: "OrderDetailStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderDetailStatuses_OrderDetailStatusId",
                table: "OrderDetails",
                column: "OrderDetailStatusId",
                principalTable: "OrderDetailStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderDetailStatuses_OrderDetailStatusId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStatuses",
                table: "OrderStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetailStatuses",
                table: "OrderDetailStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderDetailStatusId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDetailStatusId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "OrderStatuses",
                newName: "order_status");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "order");

            migrationBuilder.RenameTable(
                name: "OrderDetailStatuses",
                newName: "order_detail_status");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "order_detail");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "customer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "product",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "product",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ProductCode",
                table: "product",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "ListPrice",
                table: "product",
                newName: "list_price");

            migrationBuilder.RenameColumn(
                name: "IsListed",
                table: "product",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "order_status",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "order_status",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "order",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "order_detail_status",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "order_detail_status",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "order_detail",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "order_detail",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "order_detail",
                newName: "unit_price");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "customer",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "customer",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "customer",
                newName: "first_name");

            migrationBuilder.AddColumn<Guid>(
                name: "customer_id",
                table: "order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte>(
                name: "status_id",
                table: "order",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "status_id",
                table: "order_detail",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<Guid>(
                name: "order_id",
                table: "order_detail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "product_id",
                table: "order_detail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_status",
                table: "order_status",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_detail_status",
                table: "order_detail_status",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_detail",
                table: "order_detail",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer",
                table: "customer",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_order_customer_id",
                table: "order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_status_id",
                table: "order",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_status_id",
                table: "order_detail",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_order_id",
                table: "order_detail",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_product_id",
                table: "order_detail",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_customer_customer_id",
                table: "order",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_order_status_status_id",
                table: "order",
                column: "status_id",
                principalTable: "order_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_order_detail_status_status_id",
                table: "order_detail",
                column: "status_id",
                principalTable: "order_detail_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_order_order_id",
                table: "order_detail",
                column: "order_id",
                principalTable: "order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_product_product_id",
                table: "order_detail",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
