using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminProject.PersistenceLayer.Repository.Migrations
{
    public partial class CRMMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMaster_CompanyMaster_CompanyId",
                table: "UserMaster");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "UserMaster",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "UserMaster",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AddressMaster",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "AddressMaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AccountStatus = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    Phone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    AltMobile = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    ReferredByUserId = table.Column<int>(nullable: true),
                    ReferenceSource = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyType",
                columns: table => new
                {
                    PropertyTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyType", x => x.PropertyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UploadedDocument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Document = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    FileType = table.Column<int>(nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false, defaultValueSql: "2"),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    DocumentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadedDocument_Customer_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    PropertyName = table.Column<string>(nullable: false),
                    PropertyId = table.Column<int>(nullable: true),
                    AreaSize = table.Column<int>(nullable: false),
                    ConstructionStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyMaster_PropertyType_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PropertyType",
                        principalColumn: "PropertyTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyCertification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidUntil = table.Column<DateTime>(nullable: false),
                    IssuedBy = table.Column<string>(nullable: true),
                    CertificationNumber = table.Column<string>(nullable: true),
                    PropertyMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyCertification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyCertification_PropertyMaster_PropertyMasterId",
                        column: x => x.PropertyMasterId,
                        principalTable: "PropertyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTower",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    TowerName = table.Column<string>(nullable: false),
                    TowerNumber = table.Column<int>(nullable: false),
                    ConstructionStatus = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Floors = table.Column<int>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false),
                    PropertyMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyTower_PropertyMaster_PropertyMasterId",
                        column: x => x.PropertyMasterId,
                        principalTable: "PropertyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInquiry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    InquirySource = table.Column<string>(nullable: true),
                    InquirySourceId = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    InquiryDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    SaleStatus = table.Column<int>(type: "int", nullable: false, defaultValueSql: "2"),
                    PropertyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInquiry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInquiry_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInquiry_PropertyMaster_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PropertyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInquiry_UserMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TowerFloor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    FloorName = table.Column<string>(nullable: true),
                    FloorNumber = table.Column<int>(nullable: false),
                    TotalFlats = table.Column<int>(nullable: false),
                    TowerId = table.Column<int>(nullable: false),
                    IsRoof = table.Column<bool>(nullable: false),
                    IsGroundFloor = table.Column<bool>(nullable: false),
                    PropertyTowerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowerFloor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TowerFloor_PropertyTower_PropertyTowerId",
                        column: x => x.PropertyTowerId,
                        principalTable: "PropertyTower",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    DurationMins = table.Column<int>(nullable: true),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    NotificationSentTime = table.Column<DateTime>(nullable: false),
                    NotificationSentBy = table.Column<int>(nullable: false),
                    MeetingNotes = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    AppointmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_SalesInquiry_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "SalesInquiry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_UserMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flat",
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
                    TowerId = table.Column<int>(nullable: true),
                    FloorId = table.Column<int>(nullable: true),
                    TowerFloorId = table.Column<int>(nullable: true),
                    PropertyTowerId = table.Column<int>(nullable: true),
                    FlatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flat_SalesInquiry_FlatId",
                        column: x => x.FlatId,
                        principalTable: "SalesInquiry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flat_PropertyTower_PropertyTowerId",
                        column: x => x.PropertyTowerId,
                        principalTable: "PropertyTower",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flat_TowerFloor_TowerFloorId",
                        column: x => x.TowerFloorId,
                        principalTable: "TowerFloor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomSpecification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RoomType = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: true),
                    RoomLengthSize = table.Column<int>(nullable: true),
                    RoomWidthSize = table.Column<int>(nullable: true),
                    RoomHeightSize = table.Column<int>(nullable: true),
                    TotalSize = table.Column<string>(nullable: true),
                    IsAttachedWashRoom = table.Column<bool>(nullable: false),
                    IsFurnished = table.Column<bool>(nullable: false),
                    IsAttachedBalcony = table.Column<bool>(nullable: false),
                    RoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSpecification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomSpecification_Flat_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Flat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsDocument = table.Column<bool>(nullable: false),
                    DocumentType = table.Column<int>(nullable: true),
                    DocumentStatus = table.Column<int>(nullable: true),
                    PropertyMasterId = table.Column<int>(nullable: true),
                    RoomSpecificationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImage_PropertyMaster_PropertyMasterId",
                        column: x => x.PropertyMasterId,
                        principalTable: "PropertyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyImage_RoomSpecification_RoomSpecificationId",
                        column: x => x.RoomSpecificationId,
                        principalTable: "RoomSpecification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressMaster_AddressId",
                table: "AddressMaster",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressMaster_CustomerId",
                table: "AddressMaster",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointmentId",
                table: "Appointment",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_CustomerId",
                table: "Appointment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UserId",
                table: "Appointment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_FlatId",
                table: "Flat",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_PropertyTowerId",
                table: "Flat",
                column: "PropertyTowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_TowerFloorId",
                table: "Flat",
                column: "TowerFloorId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyCertification_PropertyMasterId",
                table: "PropertyCertification",
                column: "PropertyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyMasterId",
                table: "PropertyImage",
                column: "PropertyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_RoomSpecificationId",
                table: "PropertyImage",
                column: "RoomSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyMaster_PropertyId",
                table: "PropertyMaster",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTower_PropertyMasterId",
                table: "PropertyTower",
                column: "PropertyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSpecification_RoomId",
                table: "RoomSpecification",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInquiry_CustomerId",
                table: "SalesInquiry",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInquiry_PropertyId",
                table: "SalesInquiry",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInquiry_UserId",
                table: "SalesInquiry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TowerFloor_PropertyTowerId",
                table: "TowerFloor",
                column: "PropertyTowerId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadedDocument_DocumentId",
                table: "UploadedDocument",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressMaster_Customer_AddressId",
                table: "AddressMaster",
                column: "AddressId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressMaster_Customer_CustomerId",
                table: "AddressMaster",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMaster_CompanyMaster_CompanyId",
                table: "UserMaster",
                column: "CompanyId",
                principalTable: "CompanyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressMaster_Customer_AddressId",
                table: "AddressMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressMaster_Customer_CustomerId",
                table: "AddressMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMaster_CompanyMaster_CompanyId",
                table: "UserMaster");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "PropertyCertification");

            migrationBuilder.DropTable(
                name: "PropertyImage");

            migrationBuilder.DropTable(
                name: "UploadedDocument");

            migrationBuilder.DropTable(
                name: "RoomSpecification");

            migrationBuilder.DropTable(
                name: "Flat");

            migrationBuilder.DropTable(
                name: "SalesInquiry");

            migrationBuilder.DropTable(
                name: "TowerFloor");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "PropertyTower");

            migrationBuilder.DropTable(
                name: "PropertyMaster");

            migrationBuilder.DropTable(
                name: "PropertyType");

            migrationBuilder.DropIndex(
                name: "IX_AddressMaster_AddressId",
                table: "AddressMaster");

            migrationBuilder.DropIndex(
                name: "IX_AddressMaster_CustomerId",
                table: "AddressMaster");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AddressMaster");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AddressMaster");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "UserMaster",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMaster_CompanyMaster_CompanyId",
                table: "UserMaster",
                column: "CompanyId",
                principalTable: "CompanyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
