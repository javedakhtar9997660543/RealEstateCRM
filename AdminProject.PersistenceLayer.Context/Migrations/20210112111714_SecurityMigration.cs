using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminProject.PersistenceLayer.Repository.Migrations
{
    public partial class SecurityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionValue",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "IsMandatory",
                table: "ModuleMaster");

            migrationBuilder.DropColumn(
                name: "IsMobile",
                table: "ModuleMaster");

            migrationBuilder.DropColumn(
                name: "IsSystemModule",
                table: "ModuleMaster");

            migrationBuilder.DropColumn(
                name: "PageUrl",
                table: "ModuleMaster");

            migrationBuilder.DropColumn(
                name: "Lattitude",
                table: "LoginAttemptHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "LoginAttemptHistory");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "EmailMergeFields");

            migrationBuilder.DropColumn(
                name: "ApkDeviceName",
                table: "DailyLoginHistory");

            migrationBuilder.DropColumn(
                name: "Apkversion",
                table: "DailyLoginHistory");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "DailyLoginHistory");

            migrationBuilder.DropColumn(
                name: "Lattitude",
                table: "DailyLoginHistory");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "DailyLoginHistory");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Permissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Permissions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "DENYPERMISSION",
                table: "Permissions",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "GRANTPERMISSION",
                table: "Permissions",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LEVELKEY",
                table: "Permissions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LEVELTABLE",
                table: "Permissions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Permissions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Permissions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OBJECTINTEGERKEY",
                table: "Permissions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OBJECTSTRINGKEY",
                table: "Permissions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OBJECTTABLE",
                table: "Permissions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Application",
                table: "DailyLoginHistory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastExtension",
                table: "DailyLoginHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provider",
                table: "DailyLoginHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "DailyLoginHistory",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CountryGroup",
                columns: table => new
                {
                    TREATYCODE = table.Column<string>(nullable: false),
                    MEMBERCOUNTRY = table.Column<string>(nullable: false),
                    PROPERTYTYPES = table.Column<string>(nullable: true),
                    DATECOMMENCED = table.Column<DateTime>(nullable: true),
                    DATECEASED = table.Column<DateTime>(nullable: true),
                    ASSOCIATEMEMBER = table.Column<decimal>(type: "decimal(9,4)", nullable: true),
                    DEFAULTFLAG = table.Column<decimal>(type: "decimal(9,4)", nullable: true),
                    PREVENTNATPHASE = table.Column<bool>(nullable: true),
                    FULLMEMBERDATE = table.Column<DateTime>(nullable: true),
                    ASSOCIATEMEMBERDATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryGroup", x => new { x.TREATYCODE, x.MEMBERCOUNTRY });
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CURRENCY = table.Column<string>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    DESCRIPTION_TID = table.Column<int>(nullable: true),
                    SellRate = table.Column<decimal>(type: "decimal(9,4)", nullable: true),
                    DECIMALPLACES = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CURRENCY);
                });

            migrationBuilder.CreateTable(
                name: "RowAccess",
                columns: table => new
                {
                    ACCESSNAME = table.Column<string>(nullable: false),
                    ACCESSDESC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowAccess", x => x.ACCESSNAME);
                });

            migrationBuilder.CreateTable(
                name: "SettingDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NameTid = table.Column<int>(nullable: true),
                    DescriptionTid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingDefinition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableType",
                columns: table => new
                {
                    TABLETYPE = table.Column<short>(nullable: false),
                    TABLENAME = table.Column<string>(nullable: true),
                    DATABASETABLE = table.Column<string>(nullable: true),
                    TABLENAME_TID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableType", x => x.TABLETYPE);
                });

            migrationBuilder.CreateTable(
                name: "TASK",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    TASKNAME = table.Column<string>(nullable: true),
                    TASKNAME_TID = table.Column<int>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    DESCRIPTION_TID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxRate",
                columns: table => new
                {
                    TAXCODE = table.Column<string>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    DESCRIPTION_TID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRate", x => x.TAXCODE);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    COLCHARACTER = table.Column<string>(nullable: true),
                    COLINTEGER = table.Column<int>(nullable: true),
                    COLBOOLEAN = table.Column<bool>(nullable: true),
                    COLDECIMAL = table.Column<decimal>(nullable: true),
                    SettingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_SettingDefinition_SettingId",
                        column: x => x.SettingId,
                        principalTable: "SettingDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSettings_UserMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TableCode",
                columns: table => new
                {
                    TABLECODE = table.Column<int>(nullable: false),
                    TABLETYPE = table.Column<short>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    DESCRIPTION_TID = table.Column<int>(nullable: true),
                    USERCODE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableCode", x => x.TABLECODE);
                    table.ForeignKey(
                        name: "FK_TableCode_TableType_TABLETYPE",
                        column: x => x.TABLETYPE,
                        principalTable: "TableType",
                        principalColumn: "TABLETYPE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    COUNTRYCODE = table.Column<string>(maxLength: 3, nullable: false),
                    COUNTRY = table.Column<string>(nullable: true),
                    COUNTRY_TID = table.Column<int>(nullable: true),
                    COUNTRYADJECTIVE = table.Column<string>(nullable: true),
                    POSTCODEFIRST = table.Column<decimal>(nullable: true),
                    POSTCODELITERAL = table.Column<string>(nullable: true),
                    POSTCODELITERAL_TID = table.Column<int>(nullable: true),
                    POSTALNAME = table.Column<string>(nullable: true),
                    STATEABBREVIATED = table.Column<decimal>(nullable: true),
                    ADDRESSSTYLE = table.Column<int>(nullable: true),
                    NAMESTYLE = table.Column<int>(nullable: true),
                    AllMembersFlag = table.Column<decimal>(type: "decimal(9,4)", nullable: false),
                    RECORDTYPE = table.Column<string>(nullable: true),
                    ALTERNATECODE = table.Column<string>(nullable: true),
                    COUNTRYABBREV = table.Column<string>(nullable: true),
                    INFORMALNAME = table.Column<string>(nullable: true),
                    ISD = table.Column<string>(nullable: true),
                    PRIORARTFLAG = table.Column<bool>(nullable: true),
                    NOTES = table.Column<string>(nullable: true),
                    DATECOMMENCED = table.Column<DateTime>(nullable: true),
                    DATECEASED = table.Column<DateTime>(nullable: true),
                    WORKDAYFLAG = table.Column<short>(nullable: true),
                    INFORMALNAME_TID = table.Column<int>(nullable: true),
                    COUNTRYADJECTIVE_TID = table.Column<int>(nullable: true),
                    POSTALNAME_TID = table.Column<int>(nullable: true),
                    NOTES_TID = table.Column<int>(nullable: true),
                    STATELITERAL = table.Column<string>(nullable: true),
                    STATELITERAL_TID = table.Column<int>(nullable: true),
                    PostCodeAutoFlag = table.Column<decimal>(type: "decimal(9,4)", nullable: true),
                    POSTCODESEARCHCODE = table.Column<int>(nullable: true),
                    DEFAULTTAXCODE = table.Column<string>(nullable: true),
                    DEFAULTCURRENCY = table.Column<string>(nullable: true),
                    REQUIREEXEMPTTAXNO = table.Column<decimal>(type: "decimal(9,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.COUNTRYCODE);
                    table.ForeignKey(
                        name: "FK_Country_TableCode_ADDRESSSTYLE",
                        column: x => x.ADDRESSSTYLE,
                        principalTable: "TableCode",
                        principalColumn: "TABLECODE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_Currency_DEFAULTCURRENCY",
                        column: x => x.DEFAULTCURRENCY,
                        principalTable: "Currency",
                        principalColumn: "CURRENCY",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_TaxRate_DEFAULTTAXCODE",
                        column: x => x.DEFAULTTAXCODE,
                        principalTable: "TaxRate",
                        principalColumn: "TAXCODE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_TableCode_NAMESTYLE",
                        column: x => x.NAMESTYLE,
                        principalTable: "TableCode",
                        principalColumn: "TABLECODE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_TableCode_POSTCODESEARCHCODE",
                        column: x => x.POSTCODESEARCHCODE,
                        principalTable: "TableCode",
                        principalColumn: "TABLECODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COUNTRYCODE = table.Column<string>(nullable: true),
                    STATE = table.Column<string>(nullable: true),
                    STATENAME = table.Column<string>(nullable: true),
                    STATENAME_TID = table.Column<int>(nullable: true),
                    CountryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.ID);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "COUNTRYCODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_ADDRESSSTYLE",
                table: "Country",
                column: "ADDRESSSTYLE");

            migrationBuilder.CreateIndex(
                name: "IX_Country_DEFAULTCURRENCY",
                table: "Country",
                column: "DEFAULTCURRENCY");

            migrationBuilder.CreateIndex(
                name: "IX_Country_DEFAULTTAXCODE",
                table: "Country",
                column: "DEFAULTTAXCODE");

            migrationBuilder.CreateIndex(
                name: "IX_Country_NAMESTYLE",
                table: "Country",
                column: "NAMESTYLE");

            migrationBuilder.CreateIndex(
                name: "IX_Country_POSTCODESEARCHCODE",
                table: "Country",
                column: "POSTCODESEARCHCODE");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TableCode_TABLETYPE",
                table: "TableCode",
                column: "TABLETYPE");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_SettingId",
                table: "UserSettings",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryGroup");

            migrationBuilder.DropTable(
                name: "RowAccess");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "TASK");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "SettingDefinition");

            migrationBuilder.DropTable(
                name: "TableCode");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "TaxRate");

            migrationBuilder.DropTable(
                name: "TableType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DENYPERMISSION",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "GRANTPERMISSION",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "LEVELKEY",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "LEVELTABLE",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "OBJECTINTEGERKEY",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "OBJECTSTRINGKEY",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "OBJECTTABLE",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Application",
                table: "DailyLoginHistory");

            migrationBuilder.DropColumn(
                name: "LastExtension",
                table: "DailyLoginHistory");

            migrationBuilder.DropColumn(
                name: "Provider",
                table: "DailyLoginHistory");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "DailyLoginHistory");

            migrationBuilder.AddColumn<string>(
                name: "PermissionValue",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMandatory",
                table: "ModuleMaster",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMobile",
                table: "ModuleMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystemModule",
                table: "ModuleMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PageUrl",
                table: "ModuleMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lattitude",
                table: "LoginAttemptHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "LoginAttemptHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "EmailMergeFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApkDeviceName",
                table: "DailyLoginHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apkversion",
                table: "DailyLoginHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "DailyLoginHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lattitude",
                table: "DailyLoginHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "DailyLoginHistory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
