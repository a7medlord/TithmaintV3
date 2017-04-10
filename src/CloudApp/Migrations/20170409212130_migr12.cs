using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudApp.Migrations
{
    public partial class migr12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Percentage",
                table: "AspNetUsers",
                newName: "SupervisionPercentage");

            migrationBuilder.AddColumn<double>(
                name: "AduitPercentage",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AproverPercentage",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InterPercentage",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MuthminPercentage",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AduitPercentage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AproverPercentage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InterPercentage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MuthminPercentage",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SupervisionPercentage",
                table: "AspNetUsers",
                newName: "Percentage");
        }
    }
}
