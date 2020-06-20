using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Generator.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailStatusRecord",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailStatusRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatusRecord",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductCode = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ListPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    StatusId = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderRecord_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRecord_OrderStatusRecord_StatusId",
                        column: x => x.StatusId,
                        principalTable: "OrderStatusRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    StatusId = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetailRecord_OrderRecord_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailRecord_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailRecord_OrderDetailStatusRecord_StatusId",
                        column: x => x.StatusId,
                        principalTable: "OrderDetailStatusRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailRecord_OrderId",
                table: "OrderDetailRecord",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailRecord_ProductId",
                table: "OrderDetailRecord",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailRecord_StatusId",
                table: "OrderDetailRecord",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRecord_CustomerId",
                table: "OrderRecord",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRecord_StatusId",
                table: "OrderRecord",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetailRecord");

            migrationBuilder.DropTable(
                name: "OrderRecord");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "OrderDetailStatusRecord");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "OrderStatusRecord");
        }
    }
}
