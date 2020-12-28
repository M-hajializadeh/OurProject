using Microsoft.EntityFrameworkCore.Migrations;

namespace MA.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_MainGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsShow = table.Column<bool>(type: "bit", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_MainGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alley = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContinueAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Addresses_Tbl_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Tbl_Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_OptionalItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachFileURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_OptionalItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_OptionalItems_Tbl_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Tbl_Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    Off = table.Column<byte>(type: "tinyint", maxLength: 100, nullable: false),
                    IsShow = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    MainGroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Products_Tbl_MainGroups_MainGroupID",
                        column: x => x.MainGroupID,
                        principalTable: "Tbl_MainGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Commands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsShow = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Commands", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Commands_Tbl_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Items",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    Off = table.Column<long>(type: "bigint", maxLength: 100, nullable: false),
                    StatusOrder = table.Column<byte>(type: "tinyint", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Items_Tbl_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Tbl_Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Items_Tbl_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Tbl_Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Addresses_CustomerID",
                table: "Tbl_Addresses",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Commands_ProductId",
                table: "Tbl_Commands",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Commands_Title",
                table: "Tbl_Commands",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Customers_ForeName_SurName",
                table: "Tbl_Customers",
                columns: new[] { "ForeName", "SurName" });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Items_CustomerID",
                table: "Tbl_Items",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Items_ProductID",
                table: "Tbl_Items",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_MainGroups_GroupName",
                table: "Tbl_MainGroups",
                column: "GroupName");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_OptionalItems_CustomerID",
                table: "Tbl_OptionalItems",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Products_MainGroupID",
                table: "Tbl_Products",
                column: "MainGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Products_ProductName",
                table: "Tbl_Products",
                column: "ProductName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Addresses");

            migrationBuilder.DropTable(
                name: "Tbl_Commands");

            migrationBuilder.DropTable(
                name: "Tbl_Items");

            migrationBuilder.DropTable(
                name: "Tbl_OptionalItems");

            migrationBuilder.DropTable(
                name: "Tbl_Products");

            migrationBuilder.DropTable(
                name: "Tbl_Customers");

            migrationBuilder.DropTable(
                name: "Tbl_MainGroups");
        }
    }
}
