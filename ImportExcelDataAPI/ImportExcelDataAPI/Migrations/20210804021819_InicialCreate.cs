using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportExcelDataAPI.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imports",
                columns: table => new
                {
                    ImportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedON = table.Column<DateTime>(type: "datetime", nullable: false),
                    FileLocal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imports", x => x.ImportID);
                });

            migrationBuilder.CreateTable(
                name: "ImportItems",
                columns: table => new
                {
                    ImportItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UnitaryValue = table.Column<decimal>(type: "money", nullable: false),
                    ImportID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportItems", x => x.ImportItemID);
                    table.ForeignKey(
                        name: "FK_ImportItems_Imports_ImportID",
                        column: x => x.ImportID,
                        principalTable: "Imports",
                        principalColumn: "ImportID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportItems_ImportID",
                table: "ImportItems",
                column: "ImportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportItems");

            migrationBuilder.DropTable(
                name: "Imports");
        }
    }
}
