using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WebApiRestLogging.Migrations
{
    public partial class DataLoader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groceries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groceries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Groceries",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "Department", "Description", "ModifiedBy", "Name", "Quantity", "UnitPrice" },
                values: new object[] { 1, "Aggregator", new DateTime(2020, 10, 25, 18, 36, 20, 354, DateTimeKind.Utc).AddTicks(5297), null, "Perishable", "Hunt's Tomato Paste, 6 oz", null, "Hunt's Tomato Paste", 3, 0.49m });

            migrationBuilder.InsertData(
                table: "Groceries",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "Department", "Description", "ModifiedBy", "Name", "Quantity", "UnitPrice" },
                values: new object[] { 2, "Forwarder", new DateTime(2020, 10, 25, 18, 36, 20, 354, DateTimeKind.Utc).AddTicks(6677), null, "Produce", "Ripe plantains", null, "Plantains", 8, 0.79m });

            migrationBuilder.InsertData(
                table: "Groceries",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "Department", "Description", "ModifiedBy", "Name", "Quantity", "UnitPrice" },
                values: new object[] { 3, "System", new DateTime(2020, 10, 25, 18, 36, 20, 354, DateTimeKind.Utc).AddTicks(6706), null, "Refreshments", "Heineken lager", null, "12 Pack Beer", 1, 14.49m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groceries");
        }
    }
}