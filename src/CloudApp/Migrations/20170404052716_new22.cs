using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CloudApp.Migrations
{
    public partial class new22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentForR1Samples_R2Smaple_R2SmapleId",
                table: "AttachmentForR1Samples");

            migrationBuilder.DropIndex(
                name: "IX_AttachmentForR1Samples_R2SmapleId",
                table: "AttachmentForR1Samples");

            migrationBuilder.DropColumn(
                name: "Aqarclass",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ArchDesgin",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "BulState",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Civelprat",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Genloc",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Mansob",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Rooftype",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "R2SmapleId",
                table: "AttachmentForR1Samples");

            migrationBuilder.AddColumn<bool>(
                name: "ArchKrsany",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ArchMatrialBulding",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ArchWallBlanc",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ArchWood",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AsqfKrsany",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AsqfMatrialCamer",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AsqfOthers",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AsqfWoodCamer",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BuldingTypeBad",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BuldingTypeExlant",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BuldingTypeGood",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClassComirctal",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClassHome",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClassHomeAndComrictal",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClassOthers",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DesinBad",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DesinExlant",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DesinGood",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GenralExteranlScope",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GenralFirstLevel",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GenralInnerScope",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GenralTowLevel",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MansobHeigh",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MansobLevl",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MansobLow",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AttachmentForR2Samples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttachmentId = table.Column<string>(nullable: true),
                    R2SmapleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentForR2Samples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentForR2Samples_R2Smaple_R2SmapleId",
                        column: x => x.R2SmapleId,
                        principalTable: "R2Smaple",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentForR2Samples_R2SmapleId",
                table: "AttachmentForR2Samples",
                column: "R2SmapleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentForR2Samples");

            migrationBuilder.DropColumn(
                name: "ArchKrsany",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ArchMatrialBulding",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ArchWallBlanc",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ArchWood",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AsqfKrsany",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AsqfMatrialCamer",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AsqfOthers",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AsqfWoodCamer",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "BuldingTypeBad",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "BuldingTypeExlant",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "BuldingTypeGood",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ClassComirctal",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ClassHome",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ClassHomeAndComrictal",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ClassOthers",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "DesinBad",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "DesinExlant",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "DesinGood",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "GenralExteranlScope",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "GenralFirstLevel",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "GenralInnerScope",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "GenralTowLevel",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MansobHeigh",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MansobLevl",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MansobLow",
                table: "R2Smaple");

            migrationBuilder.AddColumn<string>(
                name: "Aqarclass",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArchDesgin",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BulState",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Civelprat",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genloc",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mansob",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rooftype",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "R2SmapleId",
                table: "AttachmentForR1Samples",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentForR1Samples_R2SmapleId",
                table: "AttachmentForR1Samples",
                column: "R2SmapleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentForR1Samples_R2Smaple_R2SmapleId",
                table: "AttachmentForR1Samples",
                column: "R2SmapleId",
                principalTable: "R2Smaple",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
