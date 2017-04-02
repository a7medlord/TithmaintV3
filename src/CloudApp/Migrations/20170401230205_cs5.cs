using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudApp.Migrations
{
    public partial class cs5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wland",
                table: "R2Smaple",
                newName: "XtrenalDoor");

            migrationBuilder.RenameColumn(
                name: "Tbuild",
                table: "R2Smaple",
                newName: "WestTall");

            migrationBuilder.RenameColumn(
                name: "StyleBuild",
                table: "R2Smaple",
                newName: "West");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "R2Smaple",
                newName: "WatrerCount");

            migrationBuilder.RenameColumn(
                name: "SNum",
                table: "R2Smaple",
                newName: "WaterNumber");

            migrationBuilder.RenameColumn(
                name: "SCustmer",
                table: "R2Smaple",
                newName: "Totalswimingpool");

            migrationBuilder.RenameColumn(
                name: "ResWland",
                table: "R2Smaple",
                newName: "Totalothers");

            migrationBuilder.RenameColumn(
                name: "PurpApp",
                table: "R2Smaple",
                newName: "Totalgarden");

            migrationBuilder.RenameColumn(
                name: "Plane",
                table: "R2Smaple",
                newName: "Totalapendxup");

            migrationBuilder.RenameColumn(
                name: "OccBuild",
                table: "R2Smaple",
                newName: "TotalReptDoor");

            migrationBuilder.RenameColumn(
                name: "Napartment",
                table: "R2Smaple",
                newName: "TotalQabo");

            migrationBuilder.RenameColumn(
                name: "Local",
                table: "R2Smaple",
                newName: "TotalFirstDoor");

            migrationBuilder.RenameColumn(
                name: "ElictFire",
                table: "R2Smaple",
                newName: "Streetsok");

            migrationBuilder.RenameColumn(
                name: "DateSNum",
                table: "R2Smaple",
                newName: "TotalEarh");

            migrationBuilder.RenameColumn(
                name: "CaseBuild",
                table: "R2Smaple",
                newName: "TotalDorerath");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "R2Smaple",
                newName: "TotalCars");

            migrationBuilder.RenameColumn(
                name: "Agbuild",
                table: "R2Smaple",
                newName: "TotalAswar");

            migrationBuilder.RenameColumn(
                name: "Acce",
                table: "R2Smaple",
                newName: "Streetsnolite");

            migrationBuilder.AddColumn<string>(
                name: "Adutit",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AhlakPrecentage",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ahwash",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Approver",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AqarAge",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AqarPerfect",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AqarUse",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aqarclass",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aqarforcity",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aqarforplane",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Aqarisrent",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Aqarissoonrent",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ArchDesgin",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaApendxup",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaApnedxEarth",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaCars",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaDorEarth",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaEarth",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaFirstDoor",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaOthers",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaQabo",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaSwar",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaSwimingpool",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Areagarden",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreareptDoor",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlockNumber",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildType",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BulState",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuldinIsNull",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuldingType",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaseNumber",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Civelprat",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountAprtment",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountTretment",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DelverDate",
                table: "R2Smaple",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Doorin",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doorout",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "East",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EastTall",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ElcrictyCount",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ElcrictyNumber",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FushBuild",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FushBuildDate",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genloc",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Inner",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InnerDoor",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Intered",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterfcaesEast",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterfcaesNorth",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterfcaesSouth",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterfcaesWest",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArbicTut",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCetral",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDesrt",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDonForSndElectric",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDoublGlass",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDoublWall",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsForinTut",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGates",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidingLight",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsJebsForSaqf",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsKrajEletcru",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLifts",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNormalKraj",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSeprat",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWindo",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ishoter",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IslAder",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "JarIsBulding",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KotatNumber",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LandShape",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LastTaqeem",
                table: "R2Smaple",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Latute",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longtute",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mansob",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Mantinance",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MantinancePrice",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MantinanceReson",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeterPriceApendexErth",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeterPriceAsawr",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeterPriceCars",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeterPriceDorEarth",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeterPriceEarh",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeterPriceFirstDoor",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeterPriceQabo",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeterPriceReptDoor",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeterPriceapendxup",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeterPricegarden",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeterPriceothers",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeterPriceswiminpoo",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meterpricehouse",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meterpricetreentment",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothmenOpnion",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mothmennote",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Muthmen",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NearRoad",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "North",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NorthTall",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PiceNumber",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfitPrecntage",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RentAprtment",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RentTretment",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rescptions",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rooftype",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rooms",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaprateType",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesElectrocitcs",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesLamp",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesPhone",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesRoad",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesSanitation",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServicesWater",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "South",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SouthTall",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SroundBank",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundCentralSoaq",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundComirchalCenter",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundDispensares",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundFeul",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundGarden",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundGenralSoaq",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundGovermentDepartMent",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundHospital",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundHotel",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundMosq",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundPoilceCenter",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundRestrant",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundSchools",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundSeoul",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundSoaq",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundTree",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundciviliDenfencs",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundmedSecurityFacilty",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SroundmedicalCenter",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sroundmedicalfacilty",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sroundpartment",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sroundrasf",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Streetslite",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Streetsno",
                table: "R2Smaple",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SukDate",
                table: "R2Smaple",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SukNumber",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Talabnum",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Toor",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalApendxEarth",
                table: "R2Smaple",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "LastTaqeem",
                table: "R1Smaple",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "R2SmapleId",
                table: "AttachmentForR1Samples",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_R2Smaple_ApplicationUserId",
                table: "R2Smaple",
                column: "ApplicationUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_R2Smaple_AspNetUsers_ApplicationUserId",
                table: "R2Smaple",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentForR1Samples_R2Smaple_R2SmapleId",
                table: "AttachmentForR1Samples");

            migrationBuilder.DropForeignKey(
                name: "FK_R2Smaple_AspNetUsers_ApplicationUserId",
                table: "R2Smaple");

            migrationBuilder.DropIndex(
                name: "IX_R2Smaple_ApplicationUserId",
                table: "R2Smaple");

            migrationBuilder.DropIndex(
                name: "IX_AttachmentForR1Samples_R2SmapleId",
                table: "AttachmentForR1Samples");

            migrationBuilder.DropColumn(
                name: "Adutit",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AhlakPrecentage",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Ahwash",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Approver",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AqarAge",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AqarPerfect",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AqarUse",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Aqarclass",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Aqarforcity",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Aqarforplane",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Aqarisrent",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Aqarissoonrent",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ArchDesgin",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AreaApendxup",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AreaApnedxEarth",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AreaCars",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AreaDorEarth",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AreaEarth",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AreaFirstDoor",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AreaOthers",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AreaQabo",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AreaSwar",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AreaSwimingpool",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Areagarden",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "AreareptDoor",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "BlockNumber",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "BuildType",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "BulState",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "BuldinIsNull",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "BuldingType",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "CaseNumber",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Civelprat",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "CountAprtment",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "CountTretment",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "DelverDate",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Doorin",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Doorout",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "East",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "EastTall",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ElcrictyCount",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ElcrictyNumber",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "FushBuild",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "FushBuildDate",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Genloc",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Inner",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "InnerDoor",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Intered",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "InterfcaesEast",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "InterfcaesNorth",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "InterfcaesSouth",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "InterfcaesWest",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsArbicTut",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsCetral",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsDesrt",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsDonForSndElectric",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsDoublGlass",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsDoublWall",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsForinTut",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsGates",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsHidingLight",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsJebsForSaqf",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsKrajEletcru",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsLifts",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsNormalKraj",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsSeprat",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IsWindo",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Ishoter",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "IslAder",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "JarIsBulding",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "KotatNumber",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "LandShape",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "LastTaqeem",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Latute",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Longtute",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Mansob",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Mantinance",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MantinancePrice",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MantinanceReson",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MeterPriceApendexErth",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MeterPriceAsawr",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MeterPriceCars",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MeterPriceDorEarth",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MeterPriceEarh",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MeterPriceFirstDoor",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MeterPriceQabo",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MeterPriceReptDoor",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MeterPriceapendxup",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MeterPricegarden",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MeterPriceothers",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MeterPriceswiminpoo",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Meterpricehouse",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Meterpricetreentment",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "MothmenOpnion",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Mothmennote",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Muthmen",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "NearRoad",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "North",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "NorthTall",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "PiceNumber",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ProfitPrecntage",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "RentAprtment",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "RentTretment",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Rescptions",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Rooftype",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Rooms",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SaprateType",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ServicesElectrocitcs",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ServicesLamp",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ServicesPhone",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ServicesRoad",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ServicesSanitation",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "ServicesWater",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "South",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SouthTall",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundBank",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundCentralSoaq",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundComirchalCenter",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundDispensares",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundFeul",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundGarden",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundGenralSoaq",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundGovermentDepartMent",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundHospital",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundHotel",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundMosq",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundPoilceCenter",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundRestrant",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundSchools",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundSeoul",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundSoaq",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundTree",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundciviliDenfencs",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundmedSecurityFacilty",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SroundmedicalCenter",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Sroundmedicalfacilty",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Sroundpartment",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Sroundrasf",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Streetslite",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Streetsno",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SukDate",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "SukNumber",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Talabnum",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "Toor",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "TotalApendxEarth",
                table: "R2Smaple");

            migrationBuilder.DropColumn(
                name: "R2SmapleId",
                table: "AttachmentForR1Samples");

            migrationBuilder.RenameColumn(
                name: "XtrenalDoor",
                table: "R2Smaple",
                newName: "Wland");

            migrationBuilder.RenameColumn(
                name: "WestTall",
                table: "R2Smaple",
                newName: "Tbuild");

            migrationBuilder.RenameColumn(
                name: "West",
                table: "R2Smaple",
                newName: "StyleBuild");

            migrationBuilder.RenameColumn(
                name: "WatrerCount",
                table: "R2Smaple",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "WaterNumber",
                table: "R2Smaple",
                newName: "SNum");

            migrationBuilder.RenameColumn(
                name: "Totalswimingpool",
                table: "R2Smaple",
                newName: "SCustmer");

            migrationBuilder.RenameColumn(
                name: "Totalothers",
                table: "R2Smaple",
                newName: "ResWland");

            migrationBuilder.RenameColumn(
                name: "Totalgarden",
                table: "R2Smaple",
                newName: "PurpApp");

            migrationBuilder.RenameColumn(
                name: "Totalapendxup",
                table: "R2Smaple",
                newName: "Plane");

            migrationBuilder.RenameColumn(
                name: "TotalReptDoor",
                table: "R2Smaple",
                newName: "OccBuild");

            migrationBuilder.RenameColumn(
                name: "TotalQabo",
                table: "R2Smaple",
                newName: "Napartment");

            migrationBuilder.RenameColumn(
                name: "TotalFirstDoor",
                table: "R2Smaple",
                newName: "Local");

            migrationBuilder.RenameColumn(
                name: "TotalEarh",
                table: "R2Smaple",
                newName: "DateSNum");

            migrationBuilder.RenameColumn(
                name: "TotalDorerath",
                table: "R2Smaple",
                newName: "CaseBuild");

            migrationBuilder.RenameColumn(
                name: "TotalCars",
                table: "R2Smaple",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "TotalAswar",
                table: "R2Smaple",
                newName: "Agbuild");

            migrationBuilder.RenameColumn(
                name: "Streetsok",
                table: "R2Smaple",
                newName: "ElictFire");

            migrationBuilder.RenameColumn(
                name: "Streetsnolite",
                table: "R2Smaple",
                newName: "Acce");

            migrationBuilder.AlterColumn<string>(
                name: "LastTaqeem",
                table: "R1Smaple",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
