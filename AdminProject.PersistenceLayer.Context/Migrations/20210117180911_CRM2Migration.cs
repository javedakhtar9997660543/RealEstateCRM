using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminProject.PersistenceLayer.Repository.Migrations
{
    public partial class CRM2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flat_PropertyTower_PropertyTowerId",
                table: "Flat");

            migrationBuilder.DropForeignKey(
                name: "FK_Flat_TowerFloor_TowerFloorId",
                table: "Flat");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImage_RoomSpecification_RoomSpecificationId",
                table: "PropertyImage");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTower_PropertyMaster_PropertyMasterId",
                table: "PropertyTower");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSpecification_Flat_RoomId",
                table: "RoomSpecification");

            migrationBuilder.DropForeignKey(
                name: "FK_TowerFloor_PropertyTower_PropertyTowerId",
                table: "TowerFloor");

            migrationBuilder.DropIndex(
                name: "IX_TowerFloor_PropertyTowerId",
                table: "TowerFloor");

            migrationBuilder.DropIndex(
                name: "IX_RoomSpecification_RoomId",
                table: "RoomSpecification");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTower_PropertyMasterId",
                table: "PropertyTower");

            migrationBuilder.DropIndex(
                name: "IX_PropertyImage_RoomSpecificationId",
                table: "PropertyImage");

            migrationBuilder.DropIndex(
                name: "IX_Flat_PropertyTowerId",
                table: "Flat");

            migrationBuilder.DropIndex(
                name: "IX_Flat_TowerFloorId",
                table: "Flat");

            migrationBuilder.DropColumn(
                name: "PropertyTowerId",
                table: "TowerFloor");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoomSpecification");

            migrationBuilder.DropColumn(
                name: "PropertyMasterId",
                table: "PropertyTower");

            migrationBuilder.DropColumn(
                name: "RoomSpecificationId",
                table: "PropertyImage");

            migrationBuilder.DropColumn(
                name: "PropertyTowerId",
                table: "Flat");

            migrationBuilder.DropColumn(
                name: "TowerFloorId",
                table: "Flat");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RoomSpecification",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlatId",
                table: "RoomSpecification",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "PropertyTower",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PropertyImage",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "PropertyImage",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PropertyImage",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PropertyCertification",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TowerFloor_TowerId",
                table: "TowerFloor",
                column: "TowerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSpecification_FlatId",
                table: "RoomSpecification",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTower_PropertyId",
                table: "PropertyTower",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_FloorId",
                table: "Flat",
                column: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flat_TowerFloor_FloorId",
                table: "Flat",
                column: "FloorId",
                principalTable: "TowerFloor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTower_PropertyMaster_PropertyId",
                table: "PropertyTower",
                column: "PropertyId",
                principalTable: "PropertyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSpecification_Flat_FlatId",
                table: "RoomSpecification",
                column: "FlatId",
                principalTable: "Flat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TowerFloor_PropertyTower_TowerId",
                table: "TowerFloor",
                column: "TowerId",
                principalTable: "PropertyTower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flat_TowerFloor_FloorId",
                table: "Flat");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTower_PropertyMaster_PropertyId",
                table: "PropertyTower");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSpecification_Flat_FlatId",
                table: "RoomSpecification");

            migrationBuilder.DropForeignKey(
                name: "FK_TowerFloor_PropertyTower_TowerId",
                table: "TowerFloor");

            migrationBuilder.DropIndex(
                name: "IX_TowerFloor_TowerId",
                table: "TowerFloor");

            migrationBuilder.DropIndex(
                name: "IX_RoomSpecification_FlatId",
                table: "RoomSpecification");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTower_PropertyId",
                table: "PropertyTower");

            migrationBuilder.DropIndex(
                name: "IX_Flat_FloorId",
                table: "Flat");

            migrationBuilder.DropColumn(
                name: "FlatId",
                table: "RoomSpecification");

            migrationBuilder.AddColumn<int>(
                name: "PropertyTowerId",
                table: "TowerFloor",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RoomSpecification",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "RoomSpecification",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "PropertyTower",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyMasterId",
                table: "PropertyTower",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PropertyImage",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "PropertyImage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PropertyImage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomSpecificationId",
                table: "PropertyImage",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PropertyCertification",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "PropertyTowerId",
                table: "Flat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TowerFloorId",
                table: "Flat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TowerFloor_PropertyTowerId",
                table: "TowerFloor",
                column: "PropertyTowerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSpecification_RoomId",
                table: "RoomSpecification",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTower_PropertyMasterId",
                table: "PropertyTower",
                column: "PropertyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_RoomSpecificationId",
                table: "PropertyImage",
                column: "RoomSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_PropertyTowerId",
                table: "Flat",
                column: "PropertyTowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_TowerFloorId",
                table: "Flat",
                column: "TowerFloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flat_PropertyTower_PropertyTowerId",
                table: "Flat",
                column: "PropertyTowerId",
                principalTable: "PropertyTower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flat_TowerFloor_TowerFloorId",
                table: "Flat",
                column: "TowerFloorId",
                principalTable: "TowerFloor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImage_RoomSpecification_RoomSpecificationId",
                table: "PropertyImage",
                column: "RoomSpecificationId",
                principalTable: "RoomSpecification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTower_PropertyMaster_PropertyMasterId",
                table: "PropertyTower",
                column: "PropertyMasterId",
                principalTable: "PropertyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSpecification_Flat_RoomId",
                table: "RoomSpecification",
                column: "RoomId",
                principalTable: "Flat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TowerFloor_PropertyTower_PropertyTowerId",
                table: "TowerFloor",
                column: "PropertyTowerId",
                principalTable: "PropertyTower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
