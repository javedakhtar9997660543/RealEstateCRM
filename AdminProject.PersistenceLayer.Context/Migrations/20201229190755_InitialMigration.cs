using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminProject.PersistenceLayer.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyLoginHistory_UserMasters_UserId",
                table: "DailyLoginHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginAttemptHistory_UserMasters_UserId",
                table: "LoginAttemptHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleModule_ModuleMasters_ModuleMasterId",
                table: "RoleModule");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleModule_RoleMasters_RoleMasterId",
                table: "RoleModule");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMasters_CompanyMaster_CompanyId",
                table: "UserMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_RoleMasters_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_UserMasters_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMasters",
                table: "UserMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleMasters",
                table: "RoleMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleMasters",
                table: "ModuleMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailServices",
                table: "EmailServices");

            migrationBuilder.RenameTable(
                name: "UserMasters",
                newName: "UserMaster");

            migrationBuilder.RenameTable(
                name: "RoleMasters",
                newName: "RoleMaster");

            migrationBuilder.RenameTable(
                name: "ModuleMasters",
                newName: "ModuleMaster");

            migrationBuilder.RenameTable(
                name: "EmailServices",
                newName: "EmailService");

            migrationBuilder.RenameIndex(
                name: "IX_UserMasters_CompanyId",
                table: "UserMaster",
                newName: "IX_UserMaster_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMaster",
                table: "UserMaster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleMaster",
                table: "RoleMaster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleMaster",
                table: "ModuleMaster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailService",
                table: "EmailService",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyLoginHistory_UserMaster_UserId",
                table: "DailyLoginHistory",
                column: "UserId",
                principalTable: "UserMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginAttemptHistory_UserMaster_UserId",
                table: "LoginAttemptHistory",
                column: "UserId",
                principalTable: "UserMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleModule_ModuleMaster_ModuleMasterId",
                table: "RoleModule",
                column: "ModuleMasterId",
                principalTable: "ModuleMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleModule_RoleMaster_RoleMasterId",
                table: "RoleModule",
                column: "RoleMasterId",
                principalTable: "RoleMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMaster_CompanyMaster_CompanyId",
                table: "UserMaster",
                column: "CompanyId",
                principalTable: "CompanyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_RoleMaster_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "RoleMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_UserMaster_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "UserMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyLoginHistory_UserMaster_UserId",
                table: "DailyLoginHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginAttemptHistory_UserMaster_UserId",
                table: "LoginAttemptHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleModule_ModuleMaster_ModuleMasterId",
                table: "RoleModule");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleModule_RoleMaster_RoleMasterId",
                table: "RoleModule");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMaster_CompanyMaster_CompanyId",
                table: "UserMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_RoleMaster_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_UserMaster_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMaster",
                table: "UserMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleMaster",
                table: "RoleMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleMaster",
                table: "ModuleMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailService",
                table: "EmailService");

            migrationBuilder.RenameTable(
                name: "UserMaster",
                newName: "UserMasters");

            migrationBuilder.RenameTable(
                name: "RoleMaster",
                newName: "RoleMasters");

            migrationBuilder.RenameTable(
                name: "ModuleMaster",
                newName: "ModuleMasters");

            migrationBuilder.RenameTable(
                name: "EmailService",
                newName: "EmailServices");

            migrationBuilder.RenameIndex(
                name: "IX_UserMaster_CompanyId",
                table: "UserMasters",
                newName: "IX_UserMasters_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMasters",
                table: "UserMasters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleMasters",
                table: "RoleMasters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleMasters",
                table: "ModuleMasters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailServices",
                table: "EmailServices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyLoginHistory_UserMasters_UserId",
                table: "DailyLoginHistory",
                column: "UserId",
                principalTable: "UserMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginAttemptHistory_UserMasters_UserId",
                table: "LoginAttemptHistory",
                column: "UserId",
                principalTable: "UserMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleModule_ModuleMasters_ModuleMasterId",
                table: "RoleModule",
                column: "ModuleMasterId",
                principalTable: "ModuleMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleModule_RoleMasters_RoleMasterId",
                table: "RoleModule",
                column: "RoleMasterId",
                principalTable: "RoleMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMasters_CompanyMaster_CompanyId",
                table: "UserMasters",
                column: "CompanyId",
                principalTable: "CompanyMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_RoleMasters_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "RoleMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_UserMasters_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "UserMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
