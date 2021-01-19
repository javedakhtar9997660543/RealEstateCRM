using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminProject.PersistenceLayer.Repository.Migrations
{
    public partial class CRM4Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomSpecification");

            migrationBuilder.DropTable(
                name: "Flat");

            migrationBuilder.DropTable(
                name: "TowerFloor");

            migrationBuilder.AddColumn<int>(
                name: "BuilderMasterId",
                table: "AddressMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BuilderMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    EstablishmentYear = table.Column<DateTime>(nullable: false),
                    CompletedProjectsCount = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuilderMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTowerFloor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    FloorName = table.Column<string>(maxLength: 50, nullable: true),
                    FloorNumber = table.Column<int>(nullable: false),
                    TotalFlats = table.Column<int>(nullable: false),
                    TowerId = table.Column<int>(nullable: false),
                    IsRoof = table.Column<bool>(nullable: false),
                    IsGroundFloor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTowerFloor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyTowerFloor_PropertyTower_TowerId",
                        column: x => x.TowerId,
                        principalTable: "PropertyTower",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuilderProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuilderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuilderProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuilderProperties_BuilderMaster_BuilderId",
                        column: x => x.BuilderId,
                        principalTable: "BuilderMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyFlat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatNumber = table.Column<int>(nullable: false),
                    TotalRooms = table.Column<int>(nullable: false),
                    TotalWashrooms = table.Column<int>(nullable: true),
                    TotalBalcony = table.Column<int>(nullable: true),
                    SuperArea = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    CarpetArea = table.Column<int>(nullable: true),
                    AreaMeasurementUnit = table.Column<int>(nullable: true),
                    IsStudyRoomIncluded = table.Column<bool>(nullable: false),
                    IsStoreRoomIncluded = table.Column<bool>(nullable: false),
                    AppointmentId = table.Column<int>(nullable: true),
                    FloorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyFlat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyFlat_SalesInquiry_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "SalesInquiry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyFlat_PropertyTowerFloor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "PropertyTowerFloor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyRoomDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    RoomType = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: true),
                    RoomLengthSize = table.Column<int>(nullable: true),
                    RoomWidthSize = table.Column<int>(nullable: true),
                    RoomHeightSize = table.Column<int>(nullable: true),
                    TotalSize = table.Column<int>(nullable: false),
                    IsAttachedWashRoom = table.Column<bool>(nullable: false),
                    IsFurnished = table.Column<bool>(nullable: false),
                    IsAttachedBalcony = table.Column<bool>(nullable: false),
                    FlatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyRoomDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyRoomDetail_PropertyFlat_FlatId",
                        column: x => x.FlatId,
                        principalTable: "PropertyFlat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressMaster_BuilderMasterId",
                table: "AddressMaster",
                column: "BuilderMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BuilderProperties_BuilderId",
                table: "BuilderProperties",
                column: "BuilderId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFlat_AppointmentId",
                table: "PropertyFlat",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFlat_FloorId",
                table: "PropertyFlat",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRoomDetail_FlatId",
                table: "PropertyRoomDetail",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTowerFloor_TowerId",
                table: "PropertyTowerFloor",
                column: "TowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressMaster_BuilderMaster_BuilderMasterId",
                table: "AddressMaster",
                column: "BuilderMasterId",
                principalTable: "BuilderMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyMaster_BuilderProperties_PropertyId",
                table: "PropertyMaster",
                column: "PropertyId",
                principalTable: "BuilderProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressMaster_BuilderMaster_BuilderMasterId",
                table: "AddressMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyMaster_BuilderProperties_PropertyId",
                table: "PropertyMaster");

            migrationBuilder.DropTable(
                name: "BuilderProperties");

            migrationBuilder.DropTable(
                name: "PropertyRoomDetail");

            migrationBuilder.DropTable(
                name: "BuilderMaster");

            migrationBuilder.DropTable(
                name: "PropertyFlat");

            migrationBuilder.DropTable(
                name: "PropertyTowerFloor");

            migrationBuilder.DropIndex(
                name: "IX_AddressMaster_BuilderMasterId",
                table: "AddressMaster");

            migrationBuilder.DropColumn(
                name: "BuilderMasterId",
                table: "AddressMaster");

            migrationBuilder.CreateTable(
                name: "TowerFloor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FloorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsGroundFloor = table.Column<bool>(type: "bit", nullable: false),
                    IsRoof = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalFlats = table.Column<int>(type: "int", nullable: false),
                    TowerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowerFloor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TowerFloor_PropertyTower_TowerId",
                        column: x => x.TowerId,
                        principalTable: "PropertyTower",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    AreaMeasurementUnit = table.Column<int>(type: "int", nullable: true),
                    CarpetArea = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    FlatNumber = table.Column<int>(type: "int", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: true),
                    IsStoreRoomIncluded = table.Column<bool>(type: "bit", nullable: false),
                    IsStudyRoomIncluded = table.Column<bool>(type: "bit", nullable: false),
                    SuperArea = table.Column<int>(type: "int", nullable: false),
                    TotalBalcony = table.Column<int>(type: "int", nullable: true),
                    TotalRooms = table.Column<int>(type: "int", nullable: false),
                    TotalWashrooms = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flat_SalesInquiry_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "SalesInquiry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flat_TowerFloor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "TowerFloor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomSpecification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatId = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    IsAttachedBalcony = table.Column<bool>(type: "bit", nullable: false),
                    IsAttachedWashRoom = table.Column<bool>(type: "bit", nullable: false),
                    IsFurnished = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RoomHeightSize = table.Column<int>(type: "int", nullable: true),
                    RoomLengthSize = table.Column<int>(type: "int", nullable: true),
                    RoomType = table.Column<int>(type: "int", nullable: false),
                    RoomWidthSize = table.Column<int>(type: "int", nullable: true),
                    TotalSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSpecification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomSpecification_Flat_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flat_AppointmentId",
                table: "Flat",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_FloorId",
                table: "Flat",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSpecification_FlatId",
                table: "RoomSpecification",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_TowerFloor_TowerId",
                table: "TowerFloor",
                column: "TowerId");
        }
    }
}
