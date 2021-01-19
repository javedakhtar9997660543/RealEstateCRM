using AdminProject.PersistenceLayer.Entities.Common;
using AdminProject.PersistenceLayer.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdminProject.CommonLayer.Aspects.Extensions;
using AdminProject.PersistenceLayer.Entities.Entities.RealEstate;
using Microsoft.AspNetCore.Http;

namespace AdminProject.PersistenceLayer.Repository
{
    public class AdminDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminDbContext(DbContextOptions<AdminDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<AddressMaster> AddressMaster { get; set; }
        public DbSet<UserMaster> UserMaster { get; set; }
        public DbSet<RoleMaster> RoleMaster { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<DailyLoginHistory> DailyLoginHistory { get; set; }
        public DbSet<LoginAttemptHistory> LoginAttemptHistory { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<UserRoleModulePermission> UserRoleModulePermission { get; set; }
        public DbSet<SystemSettings> SystemSettings { get; set; }
        public DbSet<EmailService> EmailService { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<OtpMaster> OtpMaster { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
        public DbSet<ModuleMaster> ModuleMaster { get; set; }
        public DbSet<CompanyMaster> CompanyMaster { get; set; }
        public DbSet<RoleModule> RoleModule { get; set; }
        public DbSet<CommonSetup> CommonSetup { get; set; }
        public DbSet<EmailTemplate> EmailTemplate { get; set; }
        public DbSet<EmailMergeFields> EmailMergeFields { get; set; }
        public DbSet<SecurityTask> SecurityTask { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<SettingDefinition> SettingDefinition { get; set; }
        public DbSet<RowAccess> RowAccess { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<CountryGroup> CountryGroup { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<TableCode> TableCode { get; set; }
        public DbSet<TaxRate> TaxRate { get; set; }
        public DbSet<BuilderMaster> BuilderMaster { get; set; }
        public DbSet<BuilderProperties> BuilderProperties { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>();
                        entry.Entity.IsDeleted = false;
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<int>();
                        entry.Entity.ModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryGroup>()
                .HasKey(o => new { o.Id, o.MemberCountry });
            modelBuilder.Entity<PropertyMaster>()
                .Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<PropertyTower>()
                .Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Appointment>()
                .Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Appointment>()
                .Property(t => t.Status)
                .IsRequired()
                .HasColumnType("int")
                .HasDefaultValueSql("1");

            modelBuilder.Entity<SalesInquiry>()
                .Property(t => t.SaleStatus)
                .IsRequired()
                .HasColumnType("int")
                .HasDefaultValueSql("2");
            modelBuilder.Entity<Customer>()
                .Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Customer>()
                .Property(t => t.ReferenceSource)
                .IsRequired()
                .HasColumnType("int")
                .HasDefaultValueSql("0");
            modelBuilder.Entity<Customer>()
                .Property(t => t.AccountStatus)
                .IsRequired()
                .HasColumnType("int")
                .HasDefaultValueSql("0");

            modelBuilder.Entity<UploadedDocument>()
                .Property(t => t.CreatedDate)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<UploadedDocument>()
                .Property(t => t.DocumentStatus)
                .IsRequired()
                .HasColumnType("int")
                .HasDefaultValueSql("1");
            modelBuilder.Entity<UploadedDocument>()
                .Property(t => t.DocumentType)
                .IsRequired()
                .HasColumnType("int")
                .HasDefaultValueSql("2");
        }


    }
}
