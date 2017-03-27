using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CloudApp.Migrations
{
    public partial class migr11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "R2Smaple",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Acce = table.Column<bool>(nullable: false),
                    Agbuild = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    CaseBuild = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CustmerId = table.Column<long>(nullable: false),
                    DateSNum = table.Column<string>(nullable: true),
                    ElictFire = table.Column<bool>(nullable: false),
                    Gada = table.Column<string>(nullable: true),
                    IsAduit = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsIntered = table.Column<bool>(nullable: false),
                    IsThmin = table.Column<bool>(nullable: false),
                    Local = table.Column<string>(nullable: true),
                    Napartment = table.Column<string>(nullable: true),
                    Npiece = table.Column<string>(nullable: true),
                    OccBuild = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    Plane = table.Column<string>(nullable: true),
                    PurpApp = table.Column<string>(nullable: true),
                    ResWland = table.Column<string>(nullable: true),
                    SCustmer = table.Column<string>(nullable: true),
                    SNum = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    StyleBuild = table.Column<string>(nullable: true),
                    Tbuild = table.Column<string>(nullable: true),
                    Wland = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R2Smaple", x => x.Id);
                    table.ForeignKey(
                        name: "FK_R2Smaple_Custmer_CustmerId",
                        column: x => x.CustmerId,
                        principalTable: "Custmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_R2Smaple_CustmerId",
                table: "R2Smaple",
                column: "CustmerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "R2Smaple");
        }
    }
}
