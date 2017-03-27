using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudApp.Migrations
{
    public partial class migr10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "East",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EastTall",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenralLocations",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MantinCost",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MeterPriceForBulding",
                table: "Treatment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MeterPriceForEarth",
                table: "Treatment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MothmnOpnin",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "North",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NorthTall",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotesAndAbstracting",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesElectrocitcs",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesPhone",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesSanitation",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesSantiNetWork",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesWater",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "South",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SouthTall",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SroundBank",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundCentralSoaq",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundComirchalCenter",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundDispensares",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundFeul",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundGarden",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundGenralSoaq",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundGovermentDepartMent",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundHospital",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundHotel",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundMosq",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundPoilceCenter",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundRestrant",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundSchools",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundSoaq",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundciviliDenfencs",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundmedSecurityFacilty",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundmedicalCenter",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sroundmedicalfacilty",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sroundpartment",
                table: "Treatment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TotalBulding",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalForEarcth",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalPriceNumber",
                table: "Treatment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "West",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WestTall",
                table: "Treatment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SigImage",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "East",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "EastTall",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "GenralLocations",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "MantinCost",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "MeterPriceForBulding",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "MeterPriceForEarth",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "MothmnOpnin",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "North",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "NorthTall",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "NotesAndAbstracting",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "ServicesElectrocitcs",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "ServicesPhone",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "ServicesSanitation",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "ServicesSantiNetWork",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "ServicesWater",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "South",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SouthTall",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundBank",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundCentralSoaq",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundComirchalCenter",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundDispensares",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundFeul",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundGarden",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundGenralSoaq",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundGovermentDepartMent",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundHospital",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundHotel",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundMosq",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundPoilceCenter",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundRestrant",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundSchools",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundSoaq",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundciviliDenfencs",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundmedSecurityFacilty",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SroundmedicalCenter",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "Sroundmedicalfacilty",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "Sroundpartment",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "TotalBulding",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "TotalForEarcth",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "TotalPriceNumber",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "West",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "WestTall",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SigImage",
                table: "AspNetUsers");
        }
    }
}
