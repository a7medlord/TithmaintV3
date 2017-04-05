using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CloudApp.Migrations
{
    public partial class cs1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    EmployName = table.Column<string>(nullable: true),
                    IdenetityPic = table.Column<string>(nullable: true),
                    IdentityId = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    MemberId = table.Column<string>(nullable: true),
                    MemberPhotoId = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    ProfilePic = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    SigImage = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flag",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlagValue = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Custmer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustmerType = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FromClint = table.Column<string>(nullable: true),
                    ImgId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    SampleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custmer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Custmer_Samples_SampleId",
                        column: x => x.SampleId,
                        principalTable: "Samples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quotation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    Complate = table.Column<string>(nullable: true),
                    CustmerId = table.Column<long>(nullable: false),
                    FBatch = table.Column<string>(nullable: true),
                    QDate = table.Column<DateTime>(nullable: false),
                    SCustmer = table.Column<string>(nullable: true),
                    Sign = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotation_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotation_Custmer_CustmerId",
                        column: x => x.CustmerId,
                        principalTable: "Custmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "R1Smaple",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adutit = table.Column<string>(nullable: true),
                    AhlakPrecentage = table.Column<string>(nullable: true),
                    Ahwash = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Approver = table.Column<string>(nullable: true),
                    AqarAge = table.Column<string>(nullable: true),
                    AqarIsMosas = table.Column<bool>(nullable: false),
                    AqarScope = table.Column<string>(nullable: true),
                    AqarTgeem = table.Column<string>(nullable: true),
                    AqarTgeemOffices = table.Column<string>(nullable: true),
                    AqarTgeemShowrooms = table.Column<string>(nullable: true),
                    AqarType = table.Column<string>(nullable: true),
                    AqaraAttachment = table.Column<string>(nullable: true),
                    ArchConstract = table.Column<string>(nullable: true),
                    ArchDesgin = table.Column<string>(nullable: true),
                    AreaApendxup = table.Column<string>(nullable: true),
                    AreaApnedxEarth = table.Column<string>(nullable: true),
                    AreaCars = table.Column<string>(nullable: true),
                    AreaDorEarth = table.Column<string>(nullable: true),
                    AreaEarth = table.Column<string>(nullable: true),
                    AreaFirstDoor = table.Column<string>(nullable: true),
                    AreaOthers = table.Column<string>(nullable: true),
                    AreaQabo = table.Column<string>(nullable: true),
                    AreaSwar = table.Column<string>(nullable: true),
                    AreaSwimingpool = table.Column<string>(nullable: true),
                    Areagarden = table.Column<string>(nullable: true),
                    AreareptDoor = table.Column<string>(nullable: true),
                    AsqfType = table.Column<string>(nullable: true),
                    AttchType = table.Column<string>(nullable: true),
                    AzlType = table.Column<string>(nullable: true),
                    BlockNumber = table.Column<string>(nullable: true),
                    BulState = table.Column<string>(nullable: true),
                    BuldinIsNull = table.Column<string>(nullable: true),
                    BuldingNumber = table.Column<string>(nullable: true),
                    BuldingType = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ContractCountShowRoom = table.Column<string>(nullable: true),
                    ContractCountapartment = table.Column<string>(nullable: true),
                    ContractCountoffice = table.Column<string>(nullable: true),
                    CountAprtment = table.Column<string>(nullable: true),
                    CountAprtmentfor = table.Column<string>(nullable: true),
                    CountForOffice = table.Column<string>(nullable: true),
                    CountShowromms = table.Column<string>(nullable: true),
                    Countoffice = table.Column<string>(nullable: true),
                    CountshowRoom = table.Column<string>(nullable: true),
                    CustmerId = table.Column<long>(nullable: false),
                    DetlisApartment = table.Column<string>(nullable: true),
                    DetlisOffice = table.Column<string>(nullable: true),
                    DetlisShowRooms = table.Column<string>(nullable: true),
                    East = table.Column<string>(nullable: true),
                    EastTall = table.Column<string>(nullable: true),
                    EffictiveEjarApartment = table.Column<string>(nullable: true),
                    EffictiveEjarOffice = table.Column<string>(nullable: true),
                    EffictiveEjarShowRooms = table.Column<string>(nullable: true),
                    ElcrictyCount = table.Column<string>(nullable: true),
                    ElcrictyNumber = table.Column<string>(nullable: true),
                    Gada = table.Column<string>(nullable: true),
                    IncomePrecentage = table.Column<string>(nullable: true),
                    Inner = table.Column<string>(nullable: true),
                    InnerDoor = table.Column<string>(nullable: true),
                    Intered = table.Column<string>(nullable: true),
                    InterfcaesEast = table.Column<string>(nullable: true),
                    InterfcaesNorth = table.Column<string>(nullable: true),
                    InterfcaesSouth = table.Column<string>(nullable: true),
                    InterfcaesWest = table.Column<string>(nullable: true),
                    IsAduit = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsArbicTut = table.Column<bool>(nullable: false),
                    IsCetral = table.Column<bool>(nullable: false),
                    IsDesrt = table.Column<bool>(nullable: false),
                    IsDonForSndElectric = table.Column<bool>(nullable: false),
                    IsDoublGlass = table.Column<bool>(nullable: false),
                    IsDoublWall = table.Column<bool>(nullable: false),
                    IsElectricCount = table.Column<bool>(nullable: false),
                    IsElectricCountMostgl = table.Column<bool>(nullable: false),
                    IsElectricServicesInGada = table.Column<bool>(nullable: false),
                    IsForinTut = table.Column<bool>(nullable: false),
                    IsGates = table.Column<bool>(nullable: false),
                    IsHidingLight = table.Column<bool>(nullable: false),
                    IsIntered = table.Column<bool>(nullable: false),
                    IsJebsForSaqf = table.Column<bool>(nullable: false),
                    IsKrajEletcru = table.Column<bool>(nullable: false),
                    IsLifts = table.Column<bool>(nullable: false),
                    IsNormalKraj = table.Column<bool>(nullable: false),
                    IsSeprat = table.Column<bool>(nullable: false),
                    IsThmin = table.Column<bool>(nullable: false),
                    IsWaterConut = table.Column<bool>(nullable: false),
                    IsWaterServicesInGada = table.Column<bool>(nullable: false),
                    IsWatrerCountMostgl = table.Column<bool>(nullable: false),
                    IsWindo = table.Column<bool>(nullable: false),
                    Ishoter = table.Column<bool>(nullable: false),
                    IslAder = table.Column<bool>(nullable: false),
                    JarIsBulding = table.Column<string>(nullable: true),
                    KotatNumber = table.Column<string>(nullable: true),
                    LastTaqeem = table.Column<double>(nullable: false),
                    Latute = table.Column<string>(nullable: true),
                    Longtute = table.Column<string>(nullable: true),
                    Mansob = table.Column<string>(nullable: true),
                    MantinancePrice = table.Column<string>(nullable: true),
                    MarkterRoad = table.Column<string>(nullable: true),
                    MeterPriceApendexErth = table.Column<string>(nullable: true),
                    MeterPriceAsawr = table.Column<string>(nullable: true),
                    MeterPriceCars = table.Column<string>(nullable: true),
                    MeterPriceDorEarth = table.Column<string>(nullable: true),
                    MeterPriceEarh = table.Column<string>(nullable: true),
                    MeterPriceFirstDoor = table.Column<string>(nullable: true),
                    MeterPriceQabo = table.Column<string>(nullable: true),
                    MeterPriceReptDoor = table.Column<string>(nullable: true),
                    MeterPriceapendxup = table.Column<string>(nullable: true),
                    MeterPricegarden = table.Column<string>(nullable: true),
                    MeterPriceothers = table.Column<string>(nullable: true),
                    MeterPriceswiminpoo = table.Column<string>(nullable: true),
                    MothmenOpnion = table.Column<string>(nullable: true),
                    Muthmen = table.Column<string>(nullable: true),
                    North = table.Column<string>(nullable: true),
                    NorthTall = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    PiceNumber = table.Column<string>(nullable: true),
                    ProfitPrecntage = table.Column<string>(nullable: true),
                    RendingCompnyShowRoom = table.Column<string>(nullable: true),
                    RendingCompnyapartment = table.Column<string>(nullable: true),
                    RendingCompnyoffice = table.Column<string>(nullable: true),
                    RendingTypeShowRoom = table.Column<string>(nullable: true),
                    RendingTypeapartment = table.Column<string>(nullable: true),
                    RendingTypeoffice = table.Column<string>(nullable: true),
                    Rescptions = table.Column<string>(nullable: true),
                    RoadLight = table.Column<string>(nullable: true),
                    RoadSeflt = table.Column<string>(nullable: true),
                    Rooms = table.Column<string>(nullable: true),
                    South = table.Column<string>(nullable: true),
                    SouthTall = table.Column<string>(nullable: true),
                    TotalApendxEarth = table.Column<string>(nullable: true),
                    TotalAswar = table.Column<string>(nullable: true),
                    TotalCars = table.Column<string>(nullable: true),
                    TotalDorerath = table.Column<string>(nullable: true),
                    TotalEarh = table.Column<string>(nullable: true),
                    TotalFirstDoor = table.Column<string>(nullable: true),
                    TotalOfRending = table.Column<string>(nullable: true),
                    TotalQabo = table.Column<string>(nullable: true),
                    TotalReptDoor = table.Column<string>(nullable: true),
                    Totalapendxup = table.Column<string>(nullable: true),
                    Totalgarden = table.Column<string>(nullable: true),
                    Totalothers = table.Column<string>(nullable: true),
                    Totalswimingpool = table.Column<string>(nullable: true),
                    TshteebType = table.Column<string>(nullable: true),
                    WaterNumber = table.Column<string>(nullable: true),
                    WatrerCount = table.Column<string>(nullable: true),
                    West = table.Column<string>(nullable: true),
                    WestTall = table.Column<string>(nullable: true),
                    XtrenalDoor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R1Smaple", x => x.Id);
                    table.ForeignKey(
                        name: "FK_R1Smaple_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_R1Smaple_Custmer_CustmerId",
                        column: x => x.CustmerId,
                        principalTable: "Custmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "R2Smaple",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adutit = table.Column<string>(nullable: true),
                    AhlakPrecentage = table.Column<string>(nullable: true),
                    Ahwash = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Approver = table.Column<string>(nullable: true),
                    AqarAge = table.Column<string>(nullable: true),
                    AqarPerfect = table.Column<string>(nullable: true),
                    AqarUse = table.Column<string>(nullable: true),
                    Aqarforcity = table.Column<string>(nullable: true),
                    Aqarforplane = table.Column<string>(nullable: true),
                    Aqarisrent = table.Column<bool>(nullable: false),
                    Aqarissoonrent = table.Column<bool>(nullable: false),
                    ArchKrsany = table.Column<bool>(nullable: false),
                    ArchMatrialBulding = table.Column<bool>(nullable: false),
                    ArchWallBlanc = table.Column<bool>(nullable: false),
                    ArchWood = table.Column<bool>(nullable: false),
                    AreaApendxup = table.Column<string>(nullable: true),
                    AreaApnedxEarth = table.Column<string>(nullable: true),
                    AreaCars = table.Column<string>(nullable: true),
                    AreaDorEarth = table.Column<string>(nullable: true),
                    AreaEarth = table.Column<string>(nullable: true),
                    AreaFirstDoor = table.Column<string>(nullable: true),
                    AreaOthers = table.Column<string>(nullable: true),
                    AreaQabo = table.Column<string>(nullable: true),
                    AreaSwar = table.Column<string>(nullable: true),
                    AreaSwimingpool = table.Column<string>(nullable: true),
                    Areagarden = table.Column<string>(nullable: true),
                    AreareptDoor = table.Column<string>(nullable: true),
                    AsqfKrsany = table.Column<bool>(nullable: false),
                    AsqfMatrialCamer = table.Column<bool>(nullable: false),
                    AsqfOthers = table.Column<bool>(nullable: false),
                    AsqfWoodCamer = table.Column<bool>(nullable: false),
                    BlockNumber = table.Column<string>(nullable: true),
                    BuildType = table.Column<string>(nullable: true),
                    BuldinIsNull = table.Column<string>(nullable: true),
                    BuldingType = table.Column<string>(nullable: true),
                    BuldingTypeBad = table.Column<bool>(nullable: false),
                    BuldingTypeExlant = table.Column<bool>(nullable: false),
                    BuldingTypeGood = table.Column<bool>(nullable: false),
                    CaseNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ClassComirctal = table.Column<bool>(nullable: false),
                    ClassHome = table.Column<bool>(nullable: false),
                    ClassHomeAndComrictal = table.Column<bool>(nullable: false),
                    ClassOthers = table.Column<bool>(nullable: false),
                    CountAprtment = table.Column<string>(nullable: true),
                    CountTretment = table.Column<string>(nullable: true),
                    CustmerId = table.Column<long>(nullable: false),
                    DelverDate = table.Column<DateTime>(nullable: false),
                    DesinBad = table.Column<bool>(nullable: false),
                    DesinExlant = table.Column<bool>(nullable: false),
                    DesinGood = table.Column<bool>(nullable: false),
                    Doorin = table.Column<string>(nullable: true),
                    Doorout = table.Column<string>(nullable: true),
                    East = table.Column<string>(nullable: true),
                    EastTall = table.Column<string>(nullable: true),
                    ElcrictyCount = table.Column<string>(nullable: true),
                    ElcrictyNumber = table.Column<string>(nullable: true),
                    FushBuild = table.Column<string>(nullable: true),
                    FushBuildDate = table.Column<string>(nullable: true),
                    Gada = table.Column<string>(nullable: true),
                    GenralExteranlScope = table.Column<bool>(nullable: false),
                    GenralFirstLevel = table.Column<bool>(nullable: false),
                    GenralInnerScope = table.Column<bool>(nullable: false),
                    GenralTowLevel = table.Column<bool>(nullable: false),
                    Inner = table.Column<string>(nullable: true),
                    InnerDoor = table.Column<string>(nullable: true),
                    Intered = table.Column<string>(nullable: true),
                    InterfcaesEast = table.Column<string>(nullable: true),
                    InterfcaesNorth = table.Column<string>(nullable: true),
                    InterfcaesSouth = table.Column<string>(nullable: true),
                    InterfcaesWest = table.Column<string>(nullable: true),
                    IsAduit = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsArbicTut = table.Column<bool>(nullable: false),
                    IsCetral = table.Column<bool>(nullable: false),
                    IsDesrt = table.Column<bool>(nullable: false),
                    IsDonForSndElectric = table.Column<bool>(nullable: false),
                    IsDoublGlass = table.Column<bool>(nullable: false),
                    IsDoublWall = table.Column<bool>(nullable: false),
                    IsForinTut = table.Column<bool>(nullable: false),
                    IsGates = table.Column<bool>(nullable: false),
                    IsHidingLight = table.Column<bool>(nullable: false),
                    IsIntered = table.Column<bool>(nullable: false),
                    IsJebsForSaqf = table.Column<bool>(nullable: false),
                    IsKrajEletcru = table.Column<bool>(nullable: false),
                    IsLifts = table.Column<bool>(nullable: false),
                    IsNormalKraj = table.Column<bool>(nullable: false),
                    IsSeprat = table.Column<bool>(nullable: false),
                    IsThmin = table.Column<bool>(nullable: false),
                    IsWindo = table.Column<bool>(nullable: false),
                    Ishoter = table.Column<bool>(nullable: false),
                    IslAder = table.Column<bool>(nullable: false),
                    JarIsBulding = table.Column<bool>(nullable: false),
                    KotatNumber = table.Column<string>(nullable: true),
                    LandShape = table.Column<string>(nullable: true),
                    LastTaqeem = table.Column<double>(nullable: false),
                    Latute = table.Column<string>(nullable: true),
                    Longtute = table.Column<string>(nullable: true),
                    MansobHeigh = table.Column<bool>(nullable: false),
                    MansobLevl = table.Column<bool>(nullable: false),
                    MansobLow = table.Column<bool>(nullable: false),
                    Mantinance = table.Column<bool>(nullable: false),
                    MantinancePrice = table.Column<string>(nullable: true),
                    MantinanceReson = table.Column<string>(nullable: true),
                    MeterPriceApendexErth = table.Column<string>(nullable: true),
                    MeterPriceAsawr = table.Column<string>(nullable: true),
                    MeterPriceCars = table.Column<string>(nullable: true),
                    MeterPriceDorEarth = table.Column<string>(nullable: true),
                    MeterPriceEarh = table.Column<string>(nullable: true),
                    MeterPriceFirstDoor = table.Column<string>(nullable: true),
                    MeterPriceQabo = table.Column<string>(nullable: true),
                    MeterPriceReptDoor = table.Column<string>(nullable: true),
                    MeterPriceapendxup = table.Column<string>(nullable: true),
                    MeterPricegarden = table.Column<string>(nullable: true),
                    MeterPriceothers = table.Column<string>(nullable: true),
                    MeterPriceswiminpoo = table.Column<string>(nullable: true),
                    Meterpricehouse = table.Column<string>(nullable: true),
                    Meterpricetreentment = table.Column<string>(nullable: true),
                    MothmenOpnion = table.Column<string>(nullable: true),
                    Mothmennote = table.Column<string>(nullable: true),
                    Muthmen = table.Column<string>(nullable: true),
                    NearRoad = table.Column<string>(nullable: true),
                    North = table.Column<string>(nullable: true),
                    NorthTall = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    PiceNumber = table.Column<string>(nullable: true),
                    ProfitPrecntage = table.Column<string>(nullable: true),
                    RentAprtment = table.Column<string>(nullable: true),
                    RentTretment = table.Column<string>(nullable: true),
                    Rescptions = table.Column<string>(nullable: true),
                    Rooms = table.Column<string>(nullable: true),
                    SaprateType = table.Column<string>(nullable: true),
                    ServicesElectrocitcs = table.Column<bool>(nullable: false),
                    ServicesLamp = table.Column<bool>(nullable: false),
                    ServicesPhone = table.Column<bool>(nullable: false),
                    ServicesRoad = table.Column<bool>(nullable: false),
                    ServicesSanitation = table.Column<bool>(nullable: false),
                    ServicesWater = table.Column<bool>(nullable: false),
                    South = table.Column<string>(nullable: true),
                    SouthTall = table.Column<string>(nullable: true),
                    SroundBank = table.Column<bool>(nullable: false),
                    SroundCentralSoaq = table.Column<bool>(nullable: false),
                    SroundComirchalCenter = table.Column<bool>(nullable: false),
                    SroundDispensares = table.Column<bool>(nullable: false),
                    SroundFeul = table.Column<bool>(nullable: false),
                    SroundGarden = table.Column<bool>(nullable: false),
                    SroundGenralSoaq = table.Column<bool>(nullable: false),
                    SroundGovermentDepartMent = table.Column<bool>(nullable: false),
                    SroundHospital = table.Column<bool>(nullable: false),
                    SroundHotel = table.Column<bool>(nullable: false),
                    SroundMosq = table.Column<bool>(nullable: false),
                    SroundPoilceCenter = table.Column<bool>(nullable: false),
                    SroundRestrant = table.Column<bool>(nullable: false),
                    SroundSchools = table.Column<bool>(nullable: false),
                    SroundSeoul = table.Column<bool>(nullable: false),
                    SroundSoaq = table.Column<bool>(nullable: false),
                    SroundTree = table.Column<bool>(nullable: false),
                    SroundciviliDenfencs = table.Column<bool>(nullable: false),
                    SroundmedSecurityFacilty = table.Column<bool>(nullable: false),
                    SroundmedicalCenter = table.Column<bool>(nullable: false),
                    Sroundmedicalfacilty = table.Column<bool>(nullable: false),
                    Sroundpartment = table.Column<bool>(nullable: false),
                    Sroundrasf = table.Column<bool>(nullable: false),
                    Streetslite = table.Column<bool>(nullable: false),
                    Streetsno = table.Column<bool>(nullable: false),
                    Streetsnolite = table.Column<bool>(nullable: false),
                    Streetsok = table.Column<bool>(nullable: false),
                    SukDate = table.Column<DateTime>(nullable: false),
                    SukNumber = table.Column<string>(nullable: true),
                    Talabnum = table.Column<string>(nullable: true),
                    Tashtibtype = table.Column<string>(nullable: true),
                    Toor = table.Column<string>(nullable: true),
                    TotalApendxEarth = table.Column<string>(nullable: true),
                    TotalAswar = table.Column<string>(nullable: true),
                    TotalCars = table.Column<string>(nullable: true),
                    TotalDorerath = table.Column<string>(nullable: true),
                    TotalEarh = table.Column<string>(nullable: true),
                    TotalFirstDoor = table.Column<string>(nullable: true),
                    TotalQabo = table.Column<string>(nullable: true),
                    TotalReptDoor = table.Column<string>(nullable: true),
                    Totalapendxup = table.Column<string>(nullable: true),
                    Totalgarden = table.Column<string>(nullable: true),
                    Totalothers = table.Column<string>(nullable: true),
                    Totalswimingpool = table.Column<string>(nullable: true),
                    WaterNumber = table.Column<string>(nullable: true),
                    WatrerCount = table.Column<string>(nullable: true),
                    West = table.Column<string>(nullable: true),
                    WestTall = table.Column<string>(nullable: true),
                    XtrenalDoor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R2Smaple", x => x.Id);
                    table.ForeignKey(
                        name: "FK_R2Smaple_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_R2Smaple_Custmer_CustmerId",
                        column: x => x.CustmerId,
                        principalTable: "Custmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adutit = table.Column<string>(nullable: true),
                    Agbuild = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Approver = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    CaseBuild = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CustmerId = table.Column<long>(nullable: false),
                    DateSNum = table.Column<string>(nullable: true),
                    East = table.Column<string>(nullable: true),
                    EastTall = table.Column<string>(nullable: true),
                    Gada = table.Column<string>(nullable: true),
                    GenLoc = table.Column<string>(nullable: true),
                    Intered = table.Column<string>(nullable: true),
                    IsAduit = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsIntered = table.Column<bool>(nullable: false),
                    IsThmin = table.Column<bool>(nullable: false),
                    Latute = table.Column<string>(nullable: true),
                    Local = table.Column<string>(nullable: true),
                    Longtute = table.Column<string>(nullable: true),
                    MantinCost = table.Column<string>(nullable: true),
                    MeterPriceForBulding = table.Column<double>(nullable: false),
                    MeterPriceForEarth = table.Column<double>(nullable: false),
                    MothmnOpnin = table.Column<string>(nullable: true),
                    Musteh = table.Column<string>(nullable: true),
                    Muthmen = table.Column<string>(nullable: true),
                    Napartment = table.Column<string>(nullable: true),
                    North = table.Column<string>(nullable: true),
                    NorthTall = table.Column<string>(nullable: true),
                    NotesAndAbstracting = table.Column<string>(nullable: true),
                    OccBuild = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    Plane = table.Column<string>(nullable: true),
                    ResWland = table.Column<string>(nullable: true),
                    SNum = table.Column<string>(nullable: true),
                    ServicesElectrocitcs = table.Column<bool>(nullable: false),
                    ServicesLamp = table.Column<bool>(nullable: false),
                    ServicesPhone = table.Column<bool>(nullable: false),
                    ServicesRoad = table.Column<bool>(nullable: false),
                    ServicesSanitation = table.Column<bool>(nullable: false),
                    ServicesWater = table.Column<bool>(nullable: false),
                    South = table.Column<string>(nullable: true),
                    SouthTall = table.Column<string>(nullable: true),
                    SroundBank = table.Column<bool>(nullable: false),
                    SroundCentralSoaq = table.Column<bool>(nullable: false),
                    SroundComirchalCenter = table.Column<bool>(nullable: false),
                    SroundDispensares = table.Column<bool>(nullable: false),
                    SroundFeul = table.Column<bool>(nullable: false),
                    SroundGarden = table.Column<bool>(nullable: false),
                    SroundGenralSoaq = table.Column<bool>(nullable: false),
                    SroundGovermentDepartMent = table.Column<bool>(nullable: false),
                    SroundHospital = table.Column<bool>(nullable: false),
                    SroundHotel = table.Column<bool>(nullable: false),
                    SroundMosq = table.Column<bool>(nullable: false),
                    SroundPoilceCenter = table.Column<bool>(nullable: false),
                    SroundRestrant = table.Column<bool>(nullable: false),
                    SroundSchools = table.Column<bool>(nullable: false),
                    SroundSoaq = table.Column<bool>(nullable: false),
                    SroundciviliDenfencs = table.Column<bool>(nullable: false),
                    SroundmedSecurityFacilty = table.Column<bool>(nullable: false),
                    SroundmedicalCenter = table.Column<bool>(nullable: false),
                    Sroundmedicalfacilty = table.Column<bool>(nullable: false),
                    Sroundpartment = table.Column<bool>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    StyleBuild = table.Column<string>(nullable: true),
                    Tbuild = table.Column<string>(nullable: true),
                    TotalBulding = table.Column<string>(nullable: true),
                    TotalForEarcth = table.Column<string>(nullable: true),
                    TotalPriceNumber = table.Column<double>(nullable: false),
                    West = table.Column<string>(nullable: true),
                    WestTall = table.Column<string>(nullable: true),
                    Wland = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatment_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treatment_Custmer_CustmerId",
                        column: x => x.CustmerId,
                        principalTable: "Custmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instrument",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    BDiscrib = table.Column<string>(nullable: true),
                    Locat = table.Column<string>(nullable: true),
                    QuotationId = table.Column<long>(nullable: false),
                    SNum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instrument_Quotation_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentForR1Samples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttachmentId = table.Column<string>(nullable: true),
                    R1SmapleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentForR1Samples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentForR1Samples_R1Smaple_R1SmapleId",
                        column: x => x.R1SmapleId,
                        principalTable: "R1Smaple",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "AttachmentForTreaments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttachmentId = table.Column<string>(nullable: true),
                    TreatmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentForTreaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentForTreaments_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentForR1Samples_R1SmapleId",
                table: "AttachmentForR1Samples",
                column: "R1SmapleId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentForR2Samples_R2SmapleId",
                table: "AttachmentForR2Samples",
                column: "R2SmapleId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentForTreaments_TreatmentId",
                table: "AttachmentForTreaments",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Custmer_SampleId",
                table: "Custmer",
                column: "SampleId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_QuotationId",
                table: "Instrument",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_ApplicationUserId",
                table: "Quotation",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_CustmerId",
                table: "Quotation",
                column: "CustmerId");

            migrationBuilder.CreateIndex(
                name: "IX_R1Smaple_ApplicationUserId",
                table: "R1Smaple",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_R1Smaple_CustmerId",
                table: "R1Smaple",
                column: "CustmerId");

            migrationBuilder.CreateIndex(
                name: "IX_R2Smaple_ApplicationUserId",
                table: "R2Smaple",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_R2Smaple_CustmerId",
                table: "R2Smaple",
                column: "CustmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_ApplicationUserId",
                table: "Treatment",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_CustmerId",
                table: "Treatment",
                column: "CustmerId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentForR1Samples");

            migrationBuilder.DropTable(
                name: "AttachmentForR2Samples");

            migrationBuilder.DropTable(
                name: "AttachmentForTreaments");

            migrationBuilder.DropTable(
                name: "Flag");

            migrationBuilder.DropTable(
                name: "Instrument");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "R1Smaple");

            migrationBuilder.DropTable(
                name: "R2Smaple");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "Quotation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Custmer");

            migrationBuilder.DropTable(
                name: "Samples");
        }
    }
}
