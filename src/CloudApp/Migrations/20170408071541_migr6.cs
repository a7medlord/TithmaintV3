using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CloudApp.Migrations
{
    public partial class migr6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AproferPrice = table.Column<double>(nullable: false),
                    Custmer = table.Column<string>(nullable: true),
                    DateOfBegin = table.Column<DateTime>(nullable: false),
                    InterPrice = table.Column<double>(nullable: false),
                    MuthmnPrice = table.Column<double>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Sample = table.Column<string>(nullable: true),
                    Tbuild = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinModel");
        }
    }
}
