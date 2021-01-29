using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoshaverAmlak.DataLayer.Migrations
{
    public partial class GenerateDatabaseV02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AirConditioner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirConditioner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BalconyPlace",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalconyPlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingFacade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingFacade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AmountOfInvestiment = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cupboard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupboard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CWType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CWType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoorOpenerType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorOpenerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloorMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeatingType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeDirection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeDirection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeFileType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeFileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotWaterType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotWaterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AmountOfInvestiment = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investor_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Neighbourhood",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighbourhood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Descrption = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owner_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealEstate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstate_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rebuilt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rebuilt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeHome",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeHome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfDocument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkArea",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaxArea = table.Column<double>(nullable: false),
                    MinArea = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWorkArea_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuyerTel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    BuyerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerTel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyerTel_Buyer_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestorTel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    InvestorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestorTel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestorTel_Investor_InvestorId",
                        column: x => x.InvestorId,
                        principalTable: "Investor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerTel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerTel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerTel_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    RealEstateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateAddress_RealEstate_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateTel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    RealEstateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateTel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateTel_RealEstate_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRegion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRegion_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRegion_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    OwnerName = table.Column<string>(nullable: true),
                    OwnerNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<long>(nullable: false),
                    PartalPrice = table.Column<long>(nullable: false),
                    FinalPrice = table.Column<long>(nullable: false),
                    YearOfConstruction = table.Column<string>(nullable: true),
                    Area = table.Column<double>(nullable: false),
                    IsParking = table.Column<bool>(nullable: false),
                    ParkingCount = table.Column<int>(nullable: false),
                    IsWarehouse = table.Column<bool>(nullable: false),
                    WarehouseArea = table.Column<int>(nullable: false),
                    IsBalcony = table.Column<bool>(nullable: false),
                    BalconyArea = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    TotalNsumberOfFloors = table.Column<int>(nullable: false),
                    NumberOfUnitsPerFloor = table.Column<int>(nullable: false),
                    IsEvacuated = table.Column<bool>(nullable: false),
                    IsQuickSale = table.Column<bool>(nullable: false),
                    StreetWidth = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    BalconyPlaceId = table.Column<int>(nullable: false),
                    NeighbourhoodId = table.Column<int>(nullable: false),
                    RebuiltId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    TypeHomeId = table.Column<int>(nullable: false),
                    HomeDirectionId = table.Column<int>(nullable: false),
                    CupboardId = table.Column<int>(nullable: false),
                    CWTypeId = table.Column<int>(nullable: false),
                    BuildingFacadeId = table.Column<int>(nullable: false),
                    FloorMaterialId = table.Column<int>(nullable: false),
                    DoorOpenerTypeId = table.Column<int>(nullable: false),
                    AirConditionerId = table.Column<int>(nullable: false),
                    HotWaterTypeId = table.Column<int>(nullable: false),
                    HeatingTypeId = table.Column<int>(nullable: false),
                    TypeOfDocumentId = table.Column<int>(nullable: false),
                    HomeFileTypeId = table.Column<int>(nullable: false),
                    FileTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeFile_AirConditioner_AirConditionerId",
                        column: x => x.AirConditionerId,
                        principalTable: "AirConditioner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_BalconyPlace_BalconyPlaceId",
                        column: x => x.BalconyPlaceId,
                        principalTable: "BalconyPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_BuildingFacade_BuildingFacadeId",
                        column: x => x.BuildingFacadeId,
                        principalTable: "BuildingFacade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_CWType_CWTypeId",
                        column: x => x.CWTypeId,
                        principalTable: "CWType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_Cupboard_CupboardId",
                        column: x => x.CupboardId,
                        principalTable: "Cupboard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_DoorOpenerType_DoorOpenerTypeId",
                        column: x => x.DoorOpenerTypeId,
                        principalTable: "DoorOpenerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_FloorMaterial_FloorMaterialId",
                        column: x => x.FloorMaterialId,
                        principalTable: "FloorMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_HeatingType_HeatingTypeId",
                        column: x => x.HeatingTypeId,
                        principalTable: "HeatingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_HomeDirection_HomeDirectionId",
                        column: x => x.HomeDirectionId,
                        principalTable: "HomeDirection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_HomeFileType_HomeFileTypeId",
                        column: x => x.HomeFileTypeId,
                        principalTable: "HomeFileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_HotWaterType_HotWaterTypeId",
                        column: x => x.HotWaterTypeId,
                        principalTable: "HotWaterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_Neighbourhood_NeighbourhoodId",
                        column: x => x.NeighbourhoodId,
                        principalTable: "Neighbourhood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_Rebuilt_RebuiltId",
                        column: x => x.RebuiltId,
                        principalTable: "Rebuilt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_TypeHome_TypeHomeId",
                        column: x => x.TypeHomeId,
                        principalTable: "TypeHome",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeFile_TypeOfDocument_TypeOfDocumentId",
                        column: x => x.TypeOfDocumentId,
                        principalTable: "TypeOfDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilitiesHomeFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    FacilitiesId = table.Column<int>(nullable: false),
                    HomeFileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitiesHomeFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilitiesHomeFile_Facilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilitiesHomeFile_HomeFile_HomeFileId",
                        column: x => x.HomeFileId,
                        principalTable: "HomeFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageHome",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    HomeFileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageHome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageHome_HomeFile_HomeFileId",
                        column: x => x.HomeFileId,
                        principalTable: "HomeFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyer_UserId",
                table: "Buyer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerTel_BuyerId",
                table: "BuyerTel",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceId",
                table: "City",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitiesHomeFile_FacilitiesId",
                table: "FacilitiesHomeFile",
                column: "FacilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitiesHomeFile_HomeFileId",
                table: "FacilitiesHomeFile",
                column: "HomeFileId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_AirConditionerId",
                table: "HomeFile",
                column: "AirConditionerId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_BalconyPlaceId",
                table: "HomeFile",
                column: "BalconyPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_BuildingFacadeId",
                table: "HomeFile",
                column: "BuildingFacadeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_CWTypeId",
                table: "HomeFile",
                column: "CWTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_CityId",
                table: "HomeFile",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_CupboardId",
                table: "HomeFile",
                column: "CupboardId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_DoorOpenerTypeId",
                table: "HomeFile",
                column: "DoorOpenerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_FileTypeId",
                table: "HomeFile",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_FloorMaterialId",
                table: "HomeFile",
                column: "FloorMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_HeatingTypeId",
                table: "HomeFile",
                column: "HeatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_HomeDirectionId",
                table: "HomeFile",
                column: "HomeDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_HomeFileTypeId",
                table: "HomeFile",
                column: "HomeFileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_HotWaterTypeId",
                table: "HomeFile",
                column: "HotWaterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_NeighbourhoodId",
                table: "HomeFile",
                column: "NeighbourhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_RebuiltId",
                table: "HomeFile",
                column: "RebuiltId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_RegionId",
                table: "HomeFile",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_RoomId",
                table: "HomeFile",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_TypeHomeId",
                table: "HomeFile",
                column: "TypeHomeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_TypeOfDocumentId",
                table: "HomeFile",
                column: "TypeOfDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageHome_HomeFileId",
                table: "ImageHome",
                column: "HomeFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Investor_UserId",
                table: "Investor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestorTel_InvestorId",
                table: "InvestorTel",
                column: "InvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_UserId",
                table: "Owner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerTel_OwnerId",
                table: "OwnerTel",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_UserId",
                table: "RealEstate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateAddress_RealEstateId",
                table: "RealEstateAddress",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateTel_RealEstateId",
                table: "RealEstateTel",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegion_RegionId",
                table: "UserRegion",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegion_UserId",
                table: "UserRegion",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkArea_UserId",
                table: "UserWorkArea",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerTel");

            migrationBuilder.DropTable(
                name: "FacilitiesHomeFile");

            migrationBuilder.DropTable(
                name: "ImageHome");

            migrationBuilder.DropTable(
                name: "InvestorTel");

            migrationBuilder.DropTable(
                name: "OwnerTel");

            migrationBuilder.DropTable(
                name: "RealEstateAddress");

            migrationBuilder.DropTable(
                name: "RealEstateTel");

            migrationBuilder.DropTable(
                name: "UserRegion");

            migrationBuilder.DropTable(
                name: "UserWorkArea");

            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "HomeFile");

            migrationBuilder.DropTable(
                name: "Investor");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "RealEstate");

            migrationBuilder.DropTable(
                name: "AirConditioner");

            migrationBuilder.DropTable(
                name: "BalconyPlace");

            migrationBuilder.DropTable(
                name: "BuildingFacade");

            migrationBuilder.DropTable(
                name: "CWType");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Cupboard");

            migrationBuilder.DropTable(
                name: "DoorOpenerType");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropTable(
                name: "FloorMaterial");

            migrationBuilder.DropTable(
                name: "HeatingType");

            migrationBuilder.DropTable(
                name: "HomeDirection");

            migrationBuilder.DropTable(
                name: "HomeFileType");

            migrationBuilder.DropTable(
                name: "HotWaterType");

            migrationBuilder.DropTable(
                name: "Neighbourhood");

            migrationBuilder.DropTable(
                name: "Rebuilt");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "TypeHome");

            migrationBuilder.DropTable(
                name: "TypeOfDocument");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");
        }
    }
}
