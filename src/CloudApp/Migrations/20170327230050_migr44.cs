using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CloudApp.Migrations
{
    public partial class migr44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Npiece",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Npiece",
                table: "R1Smaple");

            migrationBuilder.RenameColumn(
                name: "Npiece",
                table: "Treatment",
                newName: "Musteh");

            migrationBuilder.CreateTable(
                name: "Flag",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlagValue = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flag", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flag");

            migrationBuilder.RenameColumn(
                name: "Musteh",
                table: "Treatment",
                newName: "Npiece");

            migrationBuilder.AddColumn<string>(
                name: "Npiece",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Npiece",
                table: "R1Smaple",
                nullable: true);
        }
    }
}
