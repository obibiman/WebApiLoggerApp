using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorDbFileUpload.Migrations
{
    public partial class imagefilename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImgClasses",
                columns: table => new
                {
                    ImgId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imgname = table.Column<string>(maxLength: 100, nullable: false),
                    Img = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgClasses", x => x.ImgId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImgClasses");
        }
    }
}
