using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamWedds.PersistenceLayer.Repository.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Country = table.Column<int>(nullable: false),
                    PinCode = table.Column<string>(nullable: true),
                    AddressType = table.Column<int>(nullable: true),
                    AddressStatus = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    OwnerType = table.Column<int>(nullable: true),
                    Lattitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommonSetup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainType = table.Column<string>(nullable: true),
                    SubType = table.Column<string>(nullable: true),
                    DisplayText = table.Column<string>(nullable: true),
                    DisplayValue = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonSetup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    DivisionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ContactFor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailServices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(nullable: false),
                    FromEmail = table.Column<string>(nullable: true),
                    FromName = table.Column<string>(nullable: true),
                    ToName = table.Column<string>(nullable: true),
                    ToEmail = table.Column<string>(nullable: true),
                    CcEmail = table.Column<string>(nullable: true),
                    BccEmail = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    IsHtml = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsAttachment = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    AttachmentFileName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    TemplateCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Severity = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    MachineName = table.Column<string>(nullable: true),
                    AppDomainName = table.Column<string>(nullable: true),
                    ProcessId = table.Column<string>(nullable: true),
                    ProcessName = table.Column<string>(nullable: true),
                    ThreadName = table.Column<string>(nullable: true),
                    Win32ThreadId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    FormattedMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleMasters",
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
                    ParentModuleId = table.Column<int>(nullable: true),
                    ModuleCode = table.Column<int>(nullable: true),
                    IsMobile = table.Column<bool>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsSystemModule = table.Column<bool>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    IsStoreWise = table.Column<bool>(nullable: true),
                    ModuleType = table.Column<int>(nullable: false),
                    ModuleDescription = table.Column<string>(nullable: true),
                    PageUrl = table.Column<string>(nullable: true),
                    IsMandatory = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtpMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Otp = table.Column<string>(nullable: true),
                    Guid = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Attempts = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleMasters",
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
                    Code = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    RoleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    LogoutTime = table.Column<int>(nullable: false),
                    LoginFailedAttempt = table.Column<int>(nullable: false),
                    MaxLeaveMarkDays = table.Column<int>(nullable: false),
                    WeeklyOffDays = table.Column<string>(nullable: true),
                    IdleSystemDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemSettings_CompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    EmpCode = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AccountStatus = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    SeniorEmpId = table.Column<int>(nullable: true),
                    IsEmployee = table.Column<bool>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMasters_CompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleModule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    IsMandatory = table.Column<bool>(nullable: false),
                    ModuleMasterId = table.Column<int>(nullable: true),
                    RoleMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleModule_ModuleMasters_ModuleMasterId",
                        column: x => x.ModuleMasterId,
                        principalTable: "ModuleMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleModule_RoleMasters_RoleMasterId",
                        column: x => x.RoleMasterId,
                        principalTable: "RoleMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyLoginHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    SessionId = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    BrowserName = table.Column<string>(nullable: true),
                    LoginType = table.Column<int>(nullable: true),
                    LogOutTime = table.Column<DateTime>(nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: true),
                    IsLogin = table.Column<bool>(nullable: false),
                    ApkDeviceName = table.Column<string>(nullable: true),
                    Apkversion = table.Column<string>(nullable: true),
                    Lattitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyLoginHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyLoginHistory_UserMasters_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoginAttemptHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FailedAttempt = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    LoginDate = table.Column<DateTime>(nullable: true),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    Lattitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Browser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAttemptHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginAttemptHistory_UserMasters_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_RoleMasters_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_UserMasters_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleModulePermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    RoleModuleId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    ModuleId = table.Column<int>(nullable: true),
                    PermissionId = table.Column<int>(nullable: false),
                    PermissionValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleModulePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleModulePermission_RoleModule_RoleModuleId",
                        column: x => x.RoleModuleId,
                        principalTable: "RoleModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyLoginHistory_UserId",
                table: "DailyLoginHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttemptHistory_UserId",
                table: "LoginAttemptHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModule_ModuleMasterId",
                table: "RoleModule",
                column: "ModuleMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModule_RoleMasterId",
                table: "RoleModule",
                column: "RoleMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_CompanyId",
                table: "SystemSettings",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasters_CompanyId",
                table: "UserMasters",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleModulePermission_RoleModuleId",
                table: "UserRoleModulePermission",
                column: "RoleModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressMaster");

            migrationBuilder.DropTable(
                name: "CommonSetup");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "DailyLoginHistory");

            migrationBuilder.DropTable(
                name: "EmailServices");

            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropTable(
                name: "LoginAttemptHistory");

            migrationBuilder.DropTable(
                name: "OtpMaster");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "UserRoleModulePermission");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "RoleModule");

            migrationBuilder.DropTable(
                name: "UserMasters");

            migrationBuilder.DropTable(
                name: "ModuleMasters");

            migrationBuilder.DropTable(
                name: "RoleMasters");

            migrationBuilder.DropTable(
                name: "CompanyMaster");
        }
    }
}
