using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudApp.Migrations
{
    public partial class migr11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBegin",
                table: "R2Smaple",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<double>(
                name: "MuthminPrice",
                table: "R2Smaple",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBegin",
                table: "R1Smaple",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<double>(
                name: "MuthminPrice",
                table: "R1Smaple",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBegin",
                table: "FinModel",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MuthminPrice",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MuthminPrice",
                table: "R1Smaple");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBegin",
                table: "R2Smaple",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBegin",
                table: "R1Smaple",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBegin",
                table: "FinModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
