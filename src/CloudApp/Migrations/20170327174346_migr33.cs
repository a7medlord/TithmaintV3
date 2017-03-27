using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudApp.Migrations
{
    public partial class migr33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TotalPriceWorld",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Quotation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_ApplicationUserId",
                table: "Quotation",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotation_AspNetUsers_ApplicationUserId",
                table: "Quotation",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotation_AspNetUsers_ApplicationUserId",
                table: "Quotation");

            migrationBuilder.DropIndex(
                name: "IX_Quotation_ApplicationUserId",
                table: "Quotation");

            migrationBuilder.DropColumn(
                name: "TotalPriceWorld",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Quotation");
        }
    }
}
