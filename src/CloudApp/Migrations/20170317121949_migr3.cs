using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudApp.Migrations
{
    public partial class migr3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAduit",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsIntered",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsThmin",
                table: "Treatment",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAduit",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "IsIntered",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "IsThmin",
                table: "Treatment");
        }
    }
}
