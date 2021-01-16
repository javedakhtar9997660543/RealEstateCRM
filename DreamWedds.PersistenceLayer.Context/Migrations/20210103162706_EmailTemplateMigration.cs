using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamWedds.PersistenceLayer.Repository.Migrations
{
    public partial class EmailTemplateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailTemplate",
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
                    Type = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    HtmlContent = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: true),
                    AuthorName = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    TemplateCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailMergeFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    FieldName = table.Column<string>(nullable: true),
                    SrcField = table.Column<string>(nullable: true),
                    SrcFieldValue = table.Column<string>(nullable: true),
                    TemplateId = table.Column<int>(nullable: true),
                    Sequence = table.Column<int>(nullable: true),
                    TemplateCode = table.Column<int>(nullable: true),
                    EmailTemplateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMergeFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailMergeFields_EmailTemplate_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "EmailTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailMergeFields_EmailTemplateId",
                table: "EmailMergeFields",
                column: "EmailTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailMergeFields");

            migrationBuilder.DropTable(
                name: "EmailTemplate");
        }
    }
}
