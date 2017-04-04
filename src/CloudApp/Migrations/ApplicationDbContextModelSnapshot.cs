using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CloudApp.Data;

namespace CloudApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CloudApp.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("EmployName");

                    b.Property<string>("IdenetityPic");

                    b.Property<string>("IdentityId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MemberId");

                    b.Property<string>("MemberPhotoId");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePic");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("SigImage");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.AttachmentForR1Sample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttachmentId");

                    b.Property<long>("R1SmapleId");

                    b.HasKey("Id");

                    b.HasIndex("R1SmapleId");

                    b.ToTable("AttachmentForR1Samples");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.AttachmentForR2Sample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttachmentId");

                    b.Property<long>("R2SmapleId");

                    b.HasKey("Id");

                    b.HasIndex("R2SmapleId");

                    b.ToTable("AttachmentForR2Samples");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.AttachmentForTreament", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttachmentId");

                    b.Property<long>("TreatmentId");

                    b.HasKey("Id");

                    b.HasIndex("TreatmentId");

                    b.ToTable("AttachmentForTreaments");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Custmer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustmerType");

                    b.Property<string>("Email");

                    b.Property<string>("FromClint");

                    b.Property<string>("ImgId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<long>("SampleId");

                    b.HasKey("Id");

                    b.HasIndex("SampleId");

                    b.ToTable("Custmer");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Flag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("FlagValue");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Flag");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Instrument", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<string>("Area");

                    b.Property<string>("BDiscrib");

                    b.Property<string>("Locat");

                    b.Property<long>("QuotationId");

                    b.Property<string>("SNum");

                    b.HasKey("Id");

                    b.HasIndex("QuotationId");

                    b.ToTable("Instrument");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Quotation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Bank");

                    b.Property<string>("Complate");

                    b.Property<long>("CustmerId");

                    b.Property<string>("FBatch");

                    b.Property<DateTime>("QDate");

                    b.Property<string>("SCustmer");

                    b.Property<string>("Sign");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CustmerId");

                    b.ToTable("Quotation");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.R1Smaple", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adutit");

                    b.Property<string>("AhlakPrecentage");

                    b.Property<string>("Ahwash");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Approver");

                    b.Property<string>("AqarAge");

                    b.Property<bool>("AqarIsMosas");

                    b.Property<string>("AqarScope");

                    b.Property<string>("AqarTgeem");

                    b.Property<string>("AqarTgeemOffices");

                    b.Property<string>("AqarTgeemShowrooms");

                    b.Property<string>("AqarType");

                    b.Property<string>("AqaraAttachment");

                    b.Property<string>("ArchConstract");

                    b.Property<string>("ArchDesgin");

                    b.Property<string>("AreaApendxup");

                    b.Property<string>("AreaApnedxEarth");

                    b.Property<string>("AreaCars");

                    b.Property<string>("AreaDorEarth");

                    b.Property<string>("AreaEarth");

                    b.Property<string>("AreaFirstDoor");

                    b.Property<string>("AreaOthers");

                    b.Property<string>("AreaQabo");

                    b.Property<string>("AreaSwar");

                    b.Property<string>("AreaSwimingpool");

                    b.Property<string>("Areagarden");

                    b.Property<string>("AreareptDoor");

                    b.Property<string>("AsqfType");

                    b.Property<string>("AttchType");

                    b.Property<string>("AzlType");

                    b.Property<string>("BlockNumber");

                    b.Property<string>("BulState");

                    b.Property<string>("BuldinIsNull");

                    b.Property<string>("BuldingNumber");

                    b.Property<string>("BuldingType");

                    b.Property<string>("City");

                    b.Property<string>("ContractCountShowRoom");

                    b.Property<string>("ContractCountapartment");

                    b.Property<string>("ContractCountoffice");

                    b.Property<string>("CountAprtment");

                    b.Property<string>("CountAprtmentfor");

                    b.Property<string>("CountForOffice");

                    b.Property<string>("CountShowromms");

                    b.Property<string>("Countoffice");

                    b.Property<string>("CountshowRoom");

                    b.Property<long>("CustmerId");

                    b.Property<string>("DetlisApartment");

                    b.Property<string>("DetlisOffice");

                    b.Property<string>("DetlisShowRooms");

                    b.Property<string>("East");

                    b.Property<string>("EastTall");

                    b.Property<string>("EffictiveEjarApartment");

                    b.Property<string>("EffictiveEjarOffice");

                    b.Property<string>("EffictiveEjarShowRooms");

                    b.Property<string>("ElcrictyCount");

                    b.Property<string>("ElcrictyNumber");

                    b.Property<string>("Gada");

                    b.Property<string>("IncomePrecentage");

                    b.Property<string>("Inner");

                    b.Property<string>("InnerDoor");

                    b.Property<string>("Intered");

                    b.Property<string>("InterfcaesEast");

                    b.Property<string>("InterfcaesNorth");

                    b.Property<string>("InterfcaesSouth");

                    b.Property<string>("InterfcaesWest");

                    b.Property<bool>("IsAduit");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsArbicTut");

                    b.Property<bool>("IsCetral");

                    b.Property<bool>("IsDesrt");

                    b.Property<bool>("IsDonForSndElectric");

                    b.Property<bool>("IsDoublGlass");

                    b.Property<bool>("IsDoublWall");

                    b.Property<bool>("IsElectricCount");

                    b.Property<bool>("IsElectricCountMostgl");

                    b.Property<bool>("IsElectricServicesInGada");

                    b.Property<bool>("IsForinTut");

                    b.Property<bool>("IsGates");

                    b.Property<bool>("IsHidingLight");

                    b.Property<bool>("IsIntered");

                    b.Property<bool>("IsJebsForSaqf");

                    b.Property<bool>("IsKrajEletcru");

                    b.Property<bool>("IsLifts");

                    b.Property<bool>("IsNormalKraj");

                    b.Property<bool>("IsSeprat");

                    b.Property<bool>("IsThmin");

                    b.Property<bool>("IsWaterConut");

                    b.Property<bool>("IsWaterServicesInGada");

                    b.Property<bool>("IsWatrerCountMostgl");

                    b.Property<bool>("IsWindo");

                    b.Property<bool>("Ishoter");

                    b.Property<bool>("IslAder");

                    b.Property<string>("JarIsBulding");

                    b.Property<string>("KotatNumber");

                    b.Property<double>("LastTaqeem");

                    b.Property<string>("Latute");

                    b.Property<string>("Longtute");

                    b.Property<string>("Mansob");

                    b.Property<string>("MantinancePrice");

                    b.Property<string>("MarkterRoad");

                    b.Property<string>("MeterPriceApendexErth");

                    b.Property<string>("MeterPriceAsawr");

                    b.Property<string>("MeterPriceCars");

                    b.Property<string>("MeterPriceDorEarth");

                    b.Property<string>("MeterPriceEarh");

                    b.Property<string>("MeterPriceFirstDoor");

                    b.Property<string>("MeterPriceQabo");

                    b.Property<string>("MeterPriceReptDoor");

                    b.Property<string>("MeterPriceapendxup");

                    b.Property<string>("MeterPricegarden");

                    b.Property<string>("MeterPriceothers");

                    b.Property<string>("MeterPriceswiminpoo");

                    b.Property<string>("MothmenOpnion");

                    b.Property<string>("Muthmen");

                    b.Property<string>("North");

                    b.Property<string>("NorthTall");

                    b.Property<string>("Owner");

                    b.Property<string>("PiceNumber");

                    b.Property<string>("ProfitPrecntage");

                    b.Property<string>("RendingCompnyShowRoom");

                    b.Property<string>("RendingCompnyapartment");

                    b.Property<string>("RendingCompnyoffice");

                    b.Property<string>("RendingTypeShowRoom");

                    b.Property<string>("RendingTypeapartment");

                    b.Property<string>("RendingTypeoffice");

                    b.Property<string>("Rescptions");

                    b.Property<string>("RoadLight");

                    b.Property<string>("RoadSeflt");

                    b.Property<string>("Rooms");

                    b.Property<string>("South");

                    b.Property<string>("SouthTall");

                    b.Property<string>("TotalApendxEarth");

                    b.Property<string>("TotalAswar");

                    b.Property<string>("TotalCars");

                    b.Property<string>("TotalDorerath");

                    b.Property<string>("TotalEarh");

                    b.Property<string>("TotalFirstDoor");

                    b.Property<string>("TotalOfRending");

                    b.Property<string>("TotalQabo");

                    b.Property<string>("TotalReptDoor");

                    b.Property<string>("Totalapendxup");

                    b.Property<string>("Totalgarden");

                    b.Property<string>("Totalothers");

                    b.Property<string>("Totalswimingpool");

                    b.Property<string>("TshteebType");

                    b.Property<string>("WaterNumber");

                    b.Property<string>("WatrerCount");

                    b.Property<string>("West");

                    b.Property<string>("WestTall");

                    b.Property<string>("XtrenalDoor");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CustmerId");

                    b.ToTable("R1Smaple");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.R2Smaple", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adutit");

                    b.Property<string>("AhlakPrecentage");

                    b.Property<string>("Ahwash");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Approver");

                    b.Property<string>("AqarAge");

                    b.Property<string>("AqarPerfect");

                    b.Property<string>("AqarUse");

                    b.Property<string>("Aqarforcity");

                    b.Property<string>("Aqarforplane");

                    b.Property<bool>("Aqarisrent");

                    b.Property<bool>("Aqarissoonrent");

                    b.Property<bool>("ArchKrsany");

                    b.Property<bool>("ArchMatrialBulding");

                    b.Property<bool>("ArchWallBlanc");

                    b.Property<bool>("ArchWood");

                    b.Property<string>("AreaApendxup");

                    b.Property<string>("AreaApnedxEarth");

                    b.Property<string>("AreaCars");

                    b.Property<string>("AreaDorEarth");

                    b.Property<string>("AreaEarth");

                    b.Property<string>("AreaFirstDoor");

                    b.Property<string>("AreaOthers");

                    b.Property<string>("AreaQabo");

                    b.Property<string>("AreaSwar");

                    b.Property<string>("AreaSwimingpool");

                    b.Property<string>("Areagarden");

                    b.Property<string>("AreareptDoor");

                    b.Property<bool>("AsqfKrsany");

                    b.Property<bool>("AsqfMatrialCamer");

                    b.Property<bool>("AsqfOthers");

                    b.Property<bool>("AsqfWoodCamer");

                    b.Property<string>("BlockNumber");

                    b.Property<string>("BuildType");

                    b.Property<string>("BuldinIsNull");

                    b.Property<string>("BuldingType");

                    b.Property<bool>("BuldingTypeBad");

                    b.Property<bool>("BuldingTypeExlant");

                    b.Property<bool>("BuldingTypeGood");

                    b.Property<string>("CaseNumber");

                    b.Property<string>("City");

                    b.Property<bool>("ClassComirctal");

                    b.Property<bool>("ClassHome");

                    b.Property<bool>("ClassHomeAndComrictal");

                    b.Property<bool>("ClassOthers");

                    b.Property<string>("CountAprtment");

                    b.Property<string>("CountTretment");

                    b.Property<long>("CustmerId");

                    b.Property<DateTime>("DelverDate");

                    b.Property<bool>("DesinBad");

                    b.Property<bool>("DesinExlant");

                    b.Property<bool>("DesinGood");

                    b.Property<string>("Doorin");

                    b.Property<string>("Doorout");

                    b.Property<string>("East");

                    b.Property<string>("EastTall");

                    b.Property<string>("ElcrictyCount");

                    b.Property<string>("ElcrictyNumber");

                    b.Property<string>("FushBuild");

                    b.Property<string>("FushBuildDate");

                    b.Property<string>("Gada");

                    b.Property<bool>("GenralExteranlScope");

                    b.Property<bool>("GenralFirstLevel");

                    b.Property<bool>("GenralInnerScope");

                    b.Property<bool>("GenralTowLevel");

                    b.Property<string>("Inner");

                    b.Property<string>("InnerDoor");

                    b.Property<string>("Intered");

                    b.Property<string>("InterfcaesEast");

                    b.Property<string>("InterfcaesNorth");

                    b.Property<string>("InterfcaesSouth");

                    b.Property<string>("InterfcaesWest");

                    b.Property<bool>("IsAduit");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsArbicTut");

                    b.Property<bool>("IsCetral");

                    b.Property<bool>("IsDesrt");

                    b.Property<bool>("IsDonForSndElectric");

                    b.Property<bool>("IsDoublGlass");

                    b.Property<bool>("IsDoublWall");

                    b.Property<bool>("IsForinTut");

                    b.Property<bool>("IsGates");

                    b.Property<bool>("IsHidingLight");

                    b.Property<bool>("IsIntered");

                    b.Property<bool>("IsJebsForSaqf");

                    b.Property<bool>("IsKrajEletcru");

                    b.Property<bool>("IsLifts");

                    b.Property<bool>("IsNormalKraj");

                    b.Property<bool>("IsSeprat");

                    b.Property<bool>("IsThmin");

                    b.Property<bool>("IsWindo");

                    b.Property<bool>("Ishoter");

                    b.Property<bool>("IslAder");

                    b.Property<bool>("JarIsBulding");

                    b.Property<string>("KotatNumber");

                    b.Property<string>("LandShape");

                    b.Property<double>("LastTaqeem");

                    b.Property<string>("Latute");

                    b.Property<string>("Longtute");

                    b.Property<bool>("MansobHeigh");

                    b.Property<bool>("MansobLevl");

                    b.Property<bool>("MansobLow");

                    b.Property<bool>("Mantinance");

                    b.Property<string>("MantinancePrice");

                    b.Property<string>("MantinanceReson");

                    b.Property<string>("MeterPriceApendexErth");

                    b.Property<string>("MeterPriceAsawr");

                    b.Property<string>("MeterPriceCars");

                    b.Property<string>("MeterPriceDorEarth");

                    b.Property<string>("MeterPriceEarh");

                    b.Property<string>("MeterPriceFirstDoor");

                    b.Property<string>("MeterPriceQabo");

                    b.Property<string>("MeterPriceReptDoor");

                    b.Property<string>("MeterPriceapendxup");

                    b.Property<string>("MeterPricegarden");

                    b.Property<string>("MeterPriceothers");

                    b.Property<string>("MeterPriceswiminpoo");

                    b.Property<string>("Meterpricehouse");

                    b.Property<string>("Meterpricetreentment");

                    b.Property<string>("MothmenOpnion");

                    b.Property<string>("Mothmennote");

                    b.Property<string>("Muthmen");

                    b.Property<string>("NearRoad");

                    b.Property<string>("North");

                    b.Property<string>("NorthTall");

                    b.Property<string>("Owner");

                    b.Property<string>("PiceNumber");

                    b.Property<string>("ProfitPrecntage");

                    b.Property<string>("RentAprtment");

                    b.Property<string>("RentTretment");

                    b.Property<string>("Rescptions");

                    b.Property<string>("Rooms");

                    b.Property<string>("SaprateType");

                    b.Property<bool>("ServicesElectrocitcs");

                    b.Property<bool>("ServicesLamp");

                    b.Property<bool>("ServicesPhone");

                    b.Property<bool>("ServicesRoad");

                    b.Property<bool>("ServicesSanitation");

                    b.Property<bool>("ServicesWater");

                    b.Property<string>("South");

                    b.Property<string>("SouthTall");

                    b.Property<bool>("SroundBank");

                    b.Property<bool>("SroundCentralSoaq");

                    b.Property<bool>("SroundComirchalCenter");

                    b.Property<bool>("SroundDispensares");

                    b.Property<bool>("SroundFeul");

                    b.Property<bool>("SroundGarden");

                    b.Property<bool>("SroundGenralSoaq");

                    b.Property<bool>("SroundGovermentDepartMent");

                    b.Property<bool>("SroundHospital");

                    b.Property<bool>("SroundHotel");

                    b.Property<bool>("SroundMosq");

                    b.Property<bool>("SroundPoilceCenter");

                    b.Property<bool>("SroundRestrant");

                    b.Property<bool>("SroundSchools");

                    b.Property<bool>("SroundSeoul");

                    b.Property<bool>("SroundSoaq");

                    b.Property<bool>("SroundTree");

                    b.Property<bool>("SroundciviliDenfencs");

                    b.Property<bool>("SroundmedSecurityFacilty");

                    b.Property<bool>("SroundmedicalCenter");

                    b.Property<bool>("Sroundmedicalfacilty");

                    b.Property<bool>("Sroundpartment");

                    b.Property<bool>("Sroundrasf");

                    b.Property<bool>("Streetslite");

                    b.Property<bool>("Streetsno");

                    b.Property<bool>("Streetsnolite");

                    b.Property<bool>("Streetsok");

                    b.Property<DateTime>("SukDate");

                    b.Property<string>("SukNumber");

                    b.Property<string>("Talabnum");

                    b.Property<string>("Toor");

                    b.Property<string>("TotalApendxEarth");

                    b.Property<string>("TotalAswar");

                    b.Property<string>("TotalCars");

                    b.Property<string>("TotalDorerath");

                    b.Property<string>("TotalEarh");

                    b.Property<string>("TotalFirstDoor");

                    b.Property<string>("TotalQabo");

                    b.Property<string>("TotalReptDoor");

                    b.Property<string>("Totalapendxup");

                    b.Property<string>("Totalgarden");

                    b.Property<string>("Totalothers");

                    b.Property<string>("Totalswimingpool");

                    b.Property<string>("WaterNumber");

                    b.Property<string>("WatrerCount");

                    b.Property<string>("West");

                    b.Property<string>("WestTall");

                    b.Property<string>("XtrenalDoor");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CustmerId");

                    b.ToTable("R2Smaple");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Sample", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Samples");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Treatment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adutit");

                    b.Property<string>("Agbuild");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Approver");

                    b.Property<string>("Area");

                    b.Property<string>("CaseBuild");

                    b.Property<string>("City");

                    b.Property<long>("CustmerId");

                    b.Property<string>("DateSNum");

                    b.Property<string>("East");

                    b.Property<string>("EastTall");

                    b.Property<string>("Gada");

                    b.Property<string>("GenLoc");

                    b.Property<string>("Intered");

                    b.Property<bool>("IsAduit");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsIntered");

                    b.Property<bool>("IsThmin");

                    b.Property<string>("Latute");

                    b.Property<string>("Local");

                    b.Property<string>("Longtute");

                    b.Property<string>("MantinCost");

                    b.Property<double>("MeterPriceForBulding");

                    b.Property<double>("MeterPriceForEarth");

                    b.Property<string>("MothmnOpnin");

                    b.Property<string>("Musteh");

                    b.Property<string>("Muthmen");

                    b.Property<string>("Napartment");

                    b.Property<string>("North");

                    b.Property<string>("NorthTall");

                    b.Property<string>("NotesAndAbstracting");

                    b.Property<string>("OccBuild");

                    b.Property<string>("Owner");

                    b.Property<string>("Plane");

                    b.Property<string>("ResWland");

                    b.Property<string>("SNum");

                    b.Property<bool>("ServicesElectrocitcs");

                    b.Property<bool>("ServicesLamp");

                    b.Property<bool>("ServicesPhone");

                    b.Property<bool>("ServicesRoad");

                    b.Property<bool>("ServicesSanitation");

                    b.Property<bool>("ServicesWater");

                    b.Property<string>("South");

                    b.Property<string>("SouthTall");

                    b.Property<bool>("SroundBank");

                    b.Property<bool>("SroundCentralSoaq");

                    b.Property<bool>("SroundComirchalCenter");

                    b.Property<bool>("SroundDispensares");

                    b.Property<bool>("SroundFeul");

                    b.Property<bool>("SroundGarden");

                    b.Property<bool>("SroundGenralSoaq");

                    b.Property<bool>("SroundGovermentDepartMent");

                    b.Property<bool>("SroundHospital");

                    b.Property<bool>("SroundHotel");

                    b.Property<bool>("SroundMosq");

                    b.Property<bool>("SroundPoilceCenter");

                    b.Property<bool>("SroundRestrant");

                    b.Property<bool>("SroundSchools");

                    b.Property<bool>("SroundSoaq");

                    b.Property<bool>("SroundciviliDenfencs");

                    b.Property<bool>("SroundmedSecurityFacilty");

                    b.Property<bool>("SroundmedicalCenter");

                    b.Property<bool>("Sroundmedicalfacilty");

                    b.Property<bool>("Sroundpartment");

                    b.Property<string>("Street");

                    b.Property<string>("StyleBuild");

                    b.Property<string>("Tbuild");

                    b.Property<string>("TotalBulding");

                    b.Property<string>("TotalForEarcth");

                    b.Property<double>("TotalPriceNumber");

                    b.Property<string>("West");

                    b.Property<string>("WestTall");

                    b.Property<string>("Wland");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CustmerId");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.AttachmentForR1Sample", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.R1Smaple", "R1Smaple")
                        .WithMany("AttachmentForR1Samples")
                        .HasForeignKey("R1SmapleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.AttachmentForR2Sample", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.R2Smaple", "R2Smaple")
                        .WithMany("AttachmentForR2Samples")
                        .HasForeignKey("R2SmapleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.AttachmentForTreament", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Treatment", "Treatment")
                        .WithMany("AttachmentForTreaments")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Custmer", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Sample", "Sample")
                        .WithMany("Custmers")
                        .HasForeignKey("SampleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Instrument", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Quotation", "Quotation")
                        .WithMany("Instruments")
                        .HasForeignKey("QuotationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Quotation", b =>
                {
                    b.HasOne("CloudApp.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Quotations")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CloudApp.Models.BusinessModel.Custmer", "Custmer")
                        .WithMany("Quotations")
                        .HasForeignKey("CustmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.R1Smaple", b =>
                {
                    b.HasOne("CloudApp.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("R1Smaples")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CloudApp.Models.BusinessModel.Custmer", "Custmer")
                        .WithMany()
                        .HasForeignKey("CustmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.R2Smaple", b =>
                {
                    b.HasOne("CloudApp.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CloudApp.Models.BusinessModel.Custmer", "Custmer")
                        .WithMany()
                        .HasForeignKey("CustmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Treatment", b =>
                {
                    b.HasOne("CloudApp.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Treatments")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CloudApp.Models.BusinessModel.Custmer", "Custmer")
                        .WithMany("Treatments")
                        .HasForeignKey("CustmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CloudApp.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CloudApp.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CloudApp.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
