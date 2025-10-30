using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Utility;

namespace Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> AppUser { get; set; }
        public DbSet<Fridge> tblFridges { get; set; }
        public DbSet<FridgeInStock> tblFridgeInStocks { get; set; }
        public DbSet<Allocation> tblAllocations { get; set; }
        public DbSet<RequestHeader> tblRequestHeaders { get; set; }
        public DbSet<RequestDetails> tblRequestDetais { get; set; }
        public DbSet<Customer> tblCustomer { get; set; }
        public DbSet<Employee> tblEmployee { get; set; }
        public DbSet<FaultTechnician> tblFaultTechnicians { get; set; }
        public DbSet<FridgeVisit> tblFridgeVisits { get; set; }
        public DbSet<CustomerFridge> tblCustomerFridge { get; set; }
        public DbSet<BusinessInfo> tblBusinessInfo { get; set; }
        public DbSet<FaultReport> tblFaultReports { get; set; }
        public DbSet<RequestNote> tblRequestNotes { get; set; }
        public DbSet<CustomerFeedback> tblCustomerFeedbacks { get; set; }
        public DbSet<BookingNotification> tblBookingNotifications { get; set; }
        public DbSet<RebookingNotification> tblRebookingNotifications { get; set; }
        public DbSet<FaultImage> tblFaultImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Identity entities
            //modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            //});

            //modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId });
            //});

            //modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //});

            //modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //});

            //modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            //});

            // Configure Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerID);
                entity.HasOne(c => c.ApplicationUser)
                    .WithOne()
                    .HasForeignKey<Customer>(c => c.ApplicationUserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Employee
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeID);
                entity.HasOne(e => e.ApplicationUser)
                    .WithOne()
                    .HasForeignKey<Employee>(e => e.ApplicationUserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Fridge
            modelBuilder.Entity<Fridge>(entity =>
            {
                entity.HasKey(e => e.FridgeId);
            });

            // Configure FridgeInStock
            modelBuilder.Entity<FridgeInStock>(entity =>
            {
                entity.HasKey(e => e.FridgeInStockId);
                entity.HasOne(fis => fis.Fridge)
                    .WithMany(f => f.FridgeInstances)
                    .HasForeignKey(fis => fis.FridgeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure CustomerFridge
            modelBuilder.Entity<CustomerFridge>(entity =>
            {
                entity.HasKey(e => e.CustomerFridgeId);
                entity.HasOne(cf => cf.Customer)
                    .WithMany()
                    .HasForeignKey(cf => cf.CustomerID)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(cf => cf.FridgeInStock)
                    .WithMany()
                    .HasForeignKey(cf => cf.FridgeInStockId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(cf => cf.Fridge)
                    .WithMany()
                    .HasForeignKey(cf => cf.FridgeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure RequestHeader
            modelBuilder.Entity<RequestHeader>(entity =>
            {
                entity.HasKey(e => e.RequestHeaderId);
                entity.HasOne(r => r.Customer)
                    .WithMany()
                    .HasForeignKey(r => r.CustomerID)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(r => r.Employee)
                    .WithMany()
                    .HasForeignKey(r => r.EmployeeID)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(r => r.OriginalRequest)
                    .WithMany()
                    .HasForeignKey(r => r.OriginalRequestHeaderId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure RequestDetails
            modelBuilder.Entity<RequestDetails>(entity =>
            {
                entity.HasKey(e => e.RequestDetailId);
                entity.HasOne(rd => rd.RequestHeader)
                    .WithMany(r => r.RequestFridges)
                    .HasForeignKey(rd => rd.RequestHeaderId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(rd => rd.Fridge)
                    .WithMany()
                    .HasForeignKey(rd => rd.FridgeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure RequestNote
            modelBuilder.Entity<RequestNote>(entity =>
            {
                entity.HasKey(e => e.RequestNoteId);
                entity.HasOne(rn => rn.RequestHeader)
                    .WithMany()
                    .HasForeignKey(rn => rn.RequestHeaderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure FridgeVisit
            modelBuilder.Entity<FridgeVisit>(entity =>
            {
                entity.HasKey(e => e.VisitId);
                entity.HasOne(fv => fv.RequestHeader)
                    .WithMany(r => r.FridgeVisits)
                    .HasForeignKey(fv => fv.RequestHeaderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure FaultReport
            modelBuilder.Entity<FaultReport>(entity =>
            {
                entity.HasKey(e => e.FaultReportId);
                entity.HasOne(fr => fr.Customer)
                    .WithMany()
                    .HasForeignKey(fr => fr.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(fr => fr.FridgeInStock)
                    .WithMany()
                    .HasForeignKey(fr => fr.FridgeInStockId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(fr => fr.FaultTechnicians)
                    .WithOne(ft => ft.FaultReport)
                    .HasForeignKey(ft => ft.FaultReportId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(fr => fr.OriginalFaultReport)
                    .WithMany(fr => fr.RelaunchedFaultReports)
                    .HasForeignKey(fr => fr.OriginalFaultReportId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure FaultTechnician
            modelBuilder.Entity<FaultTechnician>(entity =>
            {
                entity.HasKey(e => e.FaultId);
                entity.HasOne(ft => ft.FaultReport)
                    .WithMany(fr => fr.FaultTechnicians)
                    .HasForeignKey(ft => ft.FaultReportId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(ft => ft.FridgeVisit)
                    .WithMany()
                    .HasForeignKey(ft => ft.VisitId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}