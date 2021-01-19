using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminProject.PersistenceLayer.Repository.Migrations
{
    public partial class CRM5Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyMaster_BuilderProperties_PropertyId",
                table: "PropertyMaster");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "BuilderProperties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuilderProperties_PropertyId",
                table: "BuilderProperties",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuilderProperties_PropertyMaster_PropertyId",
                table: "BuilderProperties",
                column: "PropertyId",
                principalTable: "PropertyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuilderProperties_PropertyMaster_PropertyId",
                table: "BuilderProperties");

            migrationBuilder.DropIndex(
                name: "IX_BuilderProperties_PropertyId",
                table: "BuilderProperties");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "BuilderProperties");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyMaster_BuilderProperties_PropertyId",
                table: "PropertyMaster",
                column: "PropertyId",
                principalTable: "BuilderProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
