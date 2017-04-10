using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CloudApp.Migrations
{
    public partial class date2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceMapModelView",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Area = table.Column<string>(nullable: true),
                    Classfications = table.Column<string>(nullable: true),
                    Latutue = table.Column<string>(nullable: true),
                    Longtut = table.Column<string>(nullable: true),
                    PriceOfMeter = table.Column<string>(nullable: true),
                    SoqfPrice = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    TypeOfAqar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMapModelView", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceMapModelView");
        }
    }
}
