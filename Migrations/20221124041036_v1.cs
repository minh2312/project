using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eProjectClient.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    userId = table.Column<Guid>(nullable: false),
                    fullName = table.Column<string>(maxLength: 50, nullable: true),
                    userName = table.Column<string>(maxLength: 50, nullable: true),
                    address = table.Column<string>(nullable: true),
                    state = table.Column<int>(nullable: false),
                    decentralization = table.Column<bool>(nullable: false),
                    phone = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    birtday = table.Column<DateTime>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "brand",
                columns: table => new
                {
                    id_brand = table.Column<Guid>(nullable: false),
                    brand_name = table.Column<string>(maxLength: 50, nullable: true),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brand", x => x.id_brand);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    category_id = table.Column<Guid>(nullable: false),
                    category_name = table.Column<string>(maxLength: 50, nullable: true),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "certify",
                columns: table => new
                {
                    id_certify = table.Column<Guid>(nullable: false),
                    certify_type = table.Column<string>(maxLength: 50, nullable: true),
                    image_certify = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certify", x => x.id_certify);
                });

            migrationBuilder.CreateTable(
                name: "goldk",
                columns: table => new
                {
                    goldtype_id = table.Column<Guid>(nullable: false),
                    gold_crt = table.Column<string>(nullable: true),
                    gold_rate = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goldk", x => x.goldtype_id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id_order = table.Column<Guid>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    phone = table.Column<int>(nullable: false),
                    total = table.Column<float>(nullable: false),
                    note = table.Column<string>(nullable: true),
                    booking_date = table.Column<DateTime>(nullable: true),
                    cancellation_date = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    account_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id_order);
                    table.ForeignKey(
                        name: "FK_Order_account_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_product",
                columns: table => new
                {
                    productId = table.Column<Guid>(nullable: false),
                    style_code = table.Column<string>(nullable: true),
                    pairs = table.Column<int>(nullable: false),
                    product_name = table.Column<string>(maxLength: 150, nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    image_product = table.Column<string>(nullable: true),
                    sale = table.Column<float>(nullable: false),
                    time = table.Column<DateTime>(nullable: false),
                    pro_quality = table.Column<int>(nullable: false),
                    gold_wt = table.Column<float>(nullable: false),
                    stone_wt = table.Column<float>(nullable: false),
                    net_gold = table.Column<float>(nullable: false),
                    total_gross_wt = table.Column<float>(nullable: false),
                    gold_rate = table.Column<float>(nullable: false),
                    gold_amt = table.Column<float>(nullable: false),
                    gold_making = table.Column<float>(nullable: true),
                    stone_making = table.Column<float>(nullable: true),
                    other_making = table.Column<float>(nullable: false),
                    total_making = table.Column<float>(nullable: false),
                    detail = table.Column<string>(nullable: true),
                    mrp = table.Column<string>(nullable: true),
                    category_id = table.Column<Guid>(nullable: false),
                    brand_id = table.Column<Guid>(nullable: false),
                    certify_id = table.Column<Guid>(nullable: false),
                    goldtype_id = table.Column<Guid>(nullable: false),
                    Goldk = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_product", x => x.productId);
                    table.ForeignKey(
                        name: "FK_item_product_brand_brand_id",
                        column: x => x.brand_id,
                        principalTable: "brand",
                        principalColumn: "id_brand",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_product_Category_category_id",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_product_certify_certify_id",
                        column: x => x.certify_id,
                        principalTable: "certify",
                        principalColumn: "id_certify",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    product_name = table.Column<string>(maxLength: 50, nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    total = table.Column<float>(nullable: false),
                    image = table.Column<string>(nullable: true),
                    booking_date = table.Column<DateTime>(nullable: true),
                    cancellation_date = table.Column<DateTime>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    order_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_order_id",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "id_order",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_item_product_brand_id",
                table: "item_product",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_product_category_id",
                table: "item_product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_product_certify_id",
                table: "item_product",
                column: "certify_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_account_id",
                table: "Order",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_order_id",
                table: "OrderDetail",
                column: "order_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "goldk");

            migrationBuilder.DropTable(
                name: "item_product");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "certify");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "account");
        }
    }
}
