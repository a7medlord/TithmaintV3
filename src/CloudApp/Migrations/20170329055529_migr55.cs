using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudApp.Migrations
{
    public partial class migr55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPriceWorld",
                table: "Treatment",
                newName: "Muthmen");

            migrationBuilder.RenameColumn(
                name: "ServicesSantiNetWork",
                table: "Treatment",
                newName: "ServicesRoad");

            migrationBuilder.AddColumn<string>(
                name: "Adutit",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Approver",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenLoc",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Intered",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesLamp",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_ApplicationUserId",
                table: "Treatment",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatment_AspNetUsers_ApplicationUserId",
                table: "Treatment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatment_AspNetUsers_ApplicationUserId",
                table: "Treatment");

            migrationBuilder.DropIndex(
                name: "IX_Treatment_ApplicationUserId",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "Adutit",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "Approver",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "GenLoc",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "Intered",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "ServicesLamp",
                table: "Treatment");

            migrationBuilder.RenameColumn(
                name: "ServicesRoad",
                table: "Treatment",
                newName: "ServicesSantiNetWork");

            migrationBuilder.RenameColumn(
                name: "Muthmen",
                table: "Treatment",
                newName: "TotalPriceWorld");
        }
    }
}
