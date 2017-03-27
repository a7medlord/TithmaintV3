using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CloudApp.Migrations
{
    public partial class migr1 : Migration
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
                    Email = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_R1Smaple", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Agbuild = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    CaseBuild = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CustmerId = table.Column<long>(nullable: false),
                    DateSNum = table.Column<string>(nullable: true),
                    East = table.Column<string>(nullable: true),
                    EastTall = table.Column<string>(nullable: true),
                    Gada = table.Column<string>(nullable: true),
                    GenralLocations = table.Column<string>(nullable: true),
                    IsAduit = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsIntered = table.Column<bool>(nullable: false),
                    IsThmin = table.Column<bool>(nullable: false),
                    Local = table.Column<string>(nullable: true),
                    MantinCost = table.Column<string>(nullable: true),
                    MeterPriceForBulding = table.Column<double>(nullable: false),
                    MeterPriceForEarth = table.Column<double>(nullable: false),
                    MothmnOpnin = table.Column<string>(nullable: true),
                    Napartment = table.Column<string>(nullable: true),
                    North = table.Column<string>(nullable: true),
                    NorthTall = table.Column<string>(nullable: true),
                    NotesAndAbstracting = table.Column<string>(nullable: true),
                    Npiece = table.Column<string>(nullable: true),
                    OccBuild = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    Plane = table.Column<string>(nullable: true),
                    ResWland = table.Column<string>(nullable: true),
                    SCustmer = table.Column<string>(nullable: true),
                    SNum = table.Column<string>(nullable: true),
                    ServicesElectrocitcs = table.Column<bool>(nullable: false),
                    ServicesPhone = table.Column<bool>(nullable: false),
                    ServicesSanitation = table.Column<bool>(nullable: false),
                    ServicesSantiNetWork = table.Column<bool>(nullable: false),
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
                name: "IX_Custmer_SampleId",
                table: "Custmer",
                column: "SampleId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_QuotationId",
                table: "Instrument",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_CustmerId",
                table: "Quotation",
                column: "CustmerId");

            migrationBuilder.CreateIndex(
                name: "IX_R1Smaple_CustmerId",
                table: "R1Smaple",
                column: "CustmerId");

            migrationBuilder.CreateIndex(
                name: "IX_R2Smaple_CustmerId",
                table: "R2Smaple",
                column: "CustmerId");

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
                name: "Instrument");

            migrationBuilder.DropTable(
                name: "R1Smaple");

            migrationBuilder.DropTable(
                name: "R2Smaple");

            migrationBuilder.DropTable(
                name: "Treatment");

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
