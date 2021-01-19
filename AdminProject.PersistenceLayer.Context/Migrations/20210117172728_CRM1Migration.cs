using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminProject.PersistenceLayer.Repository.Migrations
{
    public partial class CRM1Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressMaster_Customer_AddressId",
                table: "AddressMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyCertification_PropertyMaster_PropertyMasterId",
                table: "PropertyCertification");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_PropertyMaster_PropertyMasterId",
                table: "PropertyImage");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedDocument_Customer_DocumentId",
                table: "UploadedDocument");

            migrationBuilder.DropIndex(
                name: "IX_UploadedDocument_DocumentId",
                table: "UploadedDocument");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_PropertyMasterId",
                table: "PropertyImage");

            migrationBuilder.DropIndex(
                name: "IX_PropertyCertification_PropertyMasterId",
                table: "PropertyCertification");

            migrationBuilder.DropIndex(
                name: "IX_AddressMaster_AddressId",
                table: "AddressMaster");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "UploadedDocument");

            migrationBuilder.DropColumn(
                name: "DocumentStatus",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "IsDocument",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "PropertyMasterId",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "PropertyMasterId",
                table: "PropertyCertification");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AddressMaster");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "UploadedDocument",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "PropertyImage",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UploadedDocument_CustomerId",
                table: "UploadedDocument",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyCertification_PropertyId",
                table: "PropertyCertification",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressMaster_UserId",
                table: "AddressMaster",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressMaster_UserMaster_UserId",
                table: "AddressMaster",
                column: "UserId",
                principalTable: "UserMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyCertification_PropertyMaster_PropertyId",
                table: "PropertyCertification",
                column: "PropertyId",
                principalTable: "PropertyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_PropertyMaster_PropertyId",
                table: "PropertyImage",
                column: "PropertyId",
                principalTable: "PropertyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedDocument_Customer_CustomerId",
                table: "UploadedDocument",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressMaster_UserMaster_UserId",
                table: "AddressMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyCertification_PropertyMaster_PropertyId",
                table: "PropertyCertification");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_PropertyMaster_PropertyId",
                table: "PropertyImage");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedDocument_Customer_CustomerId",
                table: "UploadedDocument");

            migrationBuilder.DropIndex(
                name: "IX_UploadedDocument_CustomerId",
                table: "UploadedDocument");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_PropertyId",
                table: "PropertyImage");

            migrationBuilder.DropIndex(
                name: "IX_PropertyCertification_PropertyId",
                table: "PropertyCertification");

            migrationBuilder.DropIndex(
                name: "IX_AddressMaster_UserId",
                table: "AddressMaster");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "UploadedDocument");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "PropertyImage");

            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "UploadedDocument",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentStatus",
                table: "PropertyImage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "PropertyImage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDocument",
                table: "PropertyImage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PropertyMasterId",
                table: "PropertyImage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyMasterId",
                table: "PropertyCertification",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AddressMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UploadedDocument_DocumentId",
                table: "UploadedDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyMasterId",
                table: "PropertyImage",
                column: "PropertyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyCertification_PropertyMasterId",
                table: "PropertyCertification",
                column: "PropertyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressMaster_AddressId",
                table: "AddressMaster",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressMaster_Customer_AddressId",
                table: "AddressMaster",
                column: "AddressId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyCertification_PropertyMaster_PropertyMasterId",
                table: "PropertyCertification",
                column: "PropertyMasterId",
                principalTable: "PropertyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_PropertyMaster_PropertyMasterId",
                table: "PropertyImage",
                column: "PropertyMasterId",
                principalTable: "PropertyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedDocument_Customer_DocumentId",
                table: "UploadedDocument",
                column: "DocumentId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
