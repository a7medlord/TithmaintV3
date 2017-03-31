using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudApp.Migrations
{
    public partial class migr122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustmerType",
                table: "Custmer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromClint",
                table: "Custmer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgId",
                table: "Custmer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustmerType",
                table: "Custmer");

            migrationBuilder.DropColumn(
                name: "FromClint",
                table: "Custmer");

            migrationBuilder.DropColumn(
                name: "ImgId",
                table: "Custmer");
        }
    }
}
