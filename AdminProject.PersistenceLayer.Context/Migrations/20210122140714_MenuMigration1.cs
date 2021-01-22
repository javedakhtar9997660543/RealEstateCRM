using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminProject.PersistenceLayer.Repository.Migrations
{
    public partial class MenuMigration1 : Migration
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

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Alignment = table.Column<string>(maxLength: 50, nullable: false),
                    Path = table.Column<string>(maxLength: 750, nullable: false),
                    Root = table.Column<bool>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    Title_TId = table.Column<int>(nullable: true),
                    Title_TName = table.Column<string>(maxLength: 100, nullable: true),
                    Icon = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SubTitle = table.Column<string>(maxLength: 100, nullable: false),
                    Path = table.Column<string>(maxLength: 500, nullable: false),
                    Permission = table.Column<string>(maxLength: 50, nullable: true),
                    Icon = table.Column<string>(maxLength: 100, nullable: true),
                    SubTitle_TId = table.Column<int>(nullable: true),
                    SubTitle_TName = table.Column<string>(maxLength: 100, nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubMenu_Menu_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuilderProperties_PropertyId",
                table: "BuilderProperties",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_SubMenu_ParentId",
                table: "SubMenu",
                column: "ParentId");

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

            migrationBuilder.DropTable(
                name: "SubMenu");

            migrationBuilder.DropTable(
                name: "Menu");

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
