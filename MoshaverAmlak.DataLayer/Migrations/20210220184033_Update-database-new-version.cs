using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoshaverAmlak.DataLayer.Migrations
{
    public partial class Updatedatabasenewversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeFile_AirConditioner_AirConditionerId",
                table: "HomeFile");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeFile_BalconyPlace_BalconyPlaceId",
                table: "HomeFile");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeFile_BuildingFacade_BuildingFacadeId",
                table: "HomeFile");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeFile_CWType_CWTypeId",
                table: "HomeFile");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeFile_Cupboard_CupboardId",
                table: "HomeFile");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeFile_DoorOpenerType_DoorOpenerTypeId",
                table: "HomeFile");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeFile_FloorMaterial_FloorMaterialId",
                table: "HomeFile");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeFile_HeatingType_HeatingTypeId",
                table: "HomeFile");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeFile_HotWaterType_HotWaterTypeId",
                table: "HomeFile");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeFile_Room_RoomId",
                table: "HomeFile");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeFile_TypeHome_TypeHomeId",
                table: "HomeFile");

            migrationBuilder.DropTable(
                name: "AirConditioner");

            migrationBuilder.DropTable(
                name: "BalconyPlace");

            migrationBuilder.DropTable(
                name: "BuildingFacade");

            migrationBuilder.DropTable(
                name: "Cupboard");

            migrationBuilder.DropTable(
                name: "CWType");

            migrationBuilder.DropTable(
                name: "DoorOpenerType");

            migrationBuilder.DropTable(
                name: "FloorMaterial");

            migrationBuilder.DropTable(
                name: "HeatingType");

            migrationBuilder.DropTable(
                name: "HotWaterType");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "TypeHome");

            migrationBuilder.DropIndex(
                name: "IX_HomeFile_AirConditionerId",
                table: "HomeFile");

            migrationBuilder.DropIndex(
                name: "IX_HomeFile_BalconyPlaceId",
                table: "HomeFile");

            migrationBuilder.DropIndex(
                name: "IX_HomeFile_BuildingFacadeId",
                table: "HomeFile");

            migrationBuilder.DropIndex(
                name: "IX_HomeFile_CWTypeId",
                table: "HomeFile");

            migrationBuilder.DropIndex(
                name: "IX_HomeFile_CupboardId",
                table: "HomeFile");

            migrationBuilder.DropIndex(
                name: "IX_HomeFile_DoorOpenerTypeId",
                table: "HomeFile");

            migrationBuilder.DropIndex(
                name: "IX_HomeFile_FloorMaterialId",
                table: "HomeFile");

            migrationBuilder.DropIndex(
                name: "IX_HomeFile_HeatingTypeId",
                table: "HomeFile");

            migrationBuilder.DropIndex(
                name: "IX_HomeFile_HotWaterTypeId",
                table: "HomeFile");

            migrationBuilder.DropIndex(
                name: "IX_HomeFile_RoomId",
                table: "HomeFile");

            migrationBuilder.DropIndex(
                name: "IX_HomeFile_TypeHomeId",
                table: "HomeFile");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CategoryFacilityId",
                table: "Facilities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoryFacilities",
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
                    table.PrimaryKey("PK_CategoryFacilities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_CategoryFacilityId",
                table: "Facilities",
                column: "CategoryFacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_CategoryFacilities_CategoryFacilityId",
                table: "Facilities",
                column: "CategoryFacilityId",
                principalTable: "CategoryFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_CategoryFacilities_CategoryFacilityId",
                table: "Facilities");

            migrationBuilder.DropTable(
                name: "CategoryFacilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_CategoryFacilityId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "CategoryFacilityId",
                table: "Facilities");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AirConditioner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirConditioner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BalconyPlace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalconyPlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingFacade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingFacade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cupboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupboard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CWType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CWType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoorOpenerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorOpenerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloorMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeatingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotWaterType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotWaterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeHome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeHome", x => x.Id);
                });

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
                name: "IX_HomeFile_CupboardId",
                table: "HomeFile",
                column: "CupboardId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_DoorOpenerTypeId",
                table: "HomeFile",
                column: "DoorOpenerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_FloorMaterialId",
                table: "HomeFile",
                column: "FloorMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_HeatingTypeId",
                table: "HomeFile",
                column: "HeatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_HotWaterTypeId",
                table: "HomeFile",
                column: "HotWaterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_RoomId",
                table: "HomeFile",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeFile_TypeHomeId",
                table: "HomeFile",
                column: "TypeHomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeFile_AirConditioner_AirConditionerId",
                table: "HomeFile",
                column: "AirConditionerId",
                principalTable: "AirConditioner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeFile_BalconyPlace_BalconyPlaceId",
                table: "HomeFile",
                column: "BalconyPlaceId",
                principalTable: "BalconyPlace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeFile_BuildingFacade_BuildingFacadeId",
                table: "HomeFile",
                column: "BuildingFacadeId",
                principalTable: "BuildingFacade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeFile_CWType_CWTypeId",
                table: "HomeFile",
                column: "CWTypeId",
                principalTable: "CWType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeFile_Cupboard_CupboardId",
                table: "HomeFile",
                column: "CupboardId",
                principalTable: "Cupboard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeFile_DoorOpenerType_DoorOpenerTypeId",
                table: "HomeFile",
                column: "DoorOpenerTypeId",
                principalTable: "DoorOpenerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeFile_FloorMaterial_FloorMaterialId",
                table: "HomeFile",
                column: "FloorMaterialId",
                principalTable: "FloorMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeFile_HeatingType_HeatingTypeId",
                table: "HomeFile",
                column: "HeatingTypeId",
                principalTable: "HeatingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeFile_HotWaterType_HotWaterTypeId",
                table: "HomeFile",
                column: "HotWaterTypeId",
                principalTable: "HotWaterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeFile_Room_RoomId",
                table: "HomeFile",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeFile_TypeHome_TypeHomeId",
                table: "HomeFile",
                column: "TypeHomeId",
                principalTable: "TypeHome",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
