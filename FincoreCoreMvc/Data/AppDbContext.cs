using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<APInvoice> APInvoices { get; set; }

        public DbSet<Payment> Payments { get; set; }




        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Assets> asset { get; set; }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<RevenueEntry> revenue_entry { get; set; }

        public DbSet<ARInvoice> ARInvoices { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<Permissions> permission { get; set; }
        public DbSet<Company> company { get; set; }

        public DbSet<Department> department { get; set; }
        public DbSet<Employee> employee { get; set; }
       


        public DbSet<AccountMasters> AccountMasters { get; set; }

        public DbSet<BudgetLines> BudgetLines { get; set; }

        public DbSet<Budgets> Budgets { get; set; }

        public DbSet<BudgetsCategories> BudgetsCategories { get; set; }

        public DbSet<CapexRequests> CapexRequests { get; set; }

        public DbSet<ExpenseClaims> ExpenseClaims { get; set; }

        public DbSet<OpexRequests> OpexRequests { get; set; }
        public DbSet<GRN> grn { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<APInvoice>()
                .HasOne(x => x.Vendor)
                .WithMany()
                .HasForeignKey(x => x.VendorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<APInvoice>()
                .HasOne(x => x.PurchaseOrder)
                .WithMany()
                .HasForeignKey(x => x.POId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<APInvoice>()
                .HasOne(x => x.ApprovedByUser)
                .WithMany()
                .HasForeignKey(x => x.ApprovedBy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payment>()
                .HasOne(x => x.APInvoice)
                .WithMany()
                .HasForeignKey(x => x.APInvoiceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payment>()
                .HasOne(x => x.Vendor)
                .WithMany()
                .HasForeignKey(x => x.VendorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payment>()
                .HasOne(x => x.ApprovedByUser)
                .WithMany()
                .HasForeignKey(x => x.ApprovedBy)
                .OnDelete(DeleteBehavior.NoAction);
            // Payment → APInvoice
            modelBuilder.Entity<Payment>()
                .HasOne(x => x.APInvoice)
                .WithMany()
                .HasForeignKey(x => x.APInvoiceId)
                .OnDelete(DeleteBehavior.NoAction);

           
            modelBuilder.Entity<Payment>()
                .HasOne(x => x.ARInvoice)
                .WithMany()
                .HasForeignKey(x => x.ARInvoiceId)
                .OnDelete(DeleteBehavior.NoAction);

            
            modelBuilder.Entity<Payment>()
                .HasOne(x => x.Vendor)
                .WithMany()
                .HasForeignKey(x => x.VendorId)
                .OnDelete(DeleteBehavior.NoAction);

           
            modelBuilder.Entity<Payment>()
                .HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            
            modelBuilder.Entity<Payment>()
                .HasOne(x => x.ApprovedByUser)
                .WithMany()
                .HasForeignKey(x => x.ApprovedBy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Vendor>()
                .HasOne(v => v.Company)
                .WithMany()
                .HasForeignKey(v => v.company_id)
                .HasPrincipalKey(c => c.company_id);

            modelBuilder.Entity<Vendor>()
                .HasOne(v => v.CreatedByUser)
                .WithMany()
                .HasForeignKey(v => v.CreatedBy)
                .HasPrincipalKey(u => u.user_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vendor>()
                .HasOne(v => v.ModifiedByUser)
                .WithMany()
                .HasForeignKey(v => v.ModifiedBy)
                .HasPrincipalKey(u => u.user_id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AccountMasters>()
            .HasOne(x => x.CreatedByUser)
            .WithMany()
            .HasForeignKey(x => x.Created_By)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountMasters>()
                .HasOne(x => x.ModifiedByUser)
                .WithMany()
                .HasForeignKey(x => x.Modified_By)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<BudgetLines>()
                 .HasOne(x => x.CreatedByUser)
                 .WithMany()
                 .HasForeignKey(x => x.Created_By)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BudgetLines>()
                .HasOne(x => x.ModifiedByUser)
                .WithMany()
                .HasForeignKey(x => x.Modified_By)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BudgetLines>()
                .HasOne(x => x.Budget)
                .WithMany(x => x.BudgetLines)
                .HasForeignKey(x => x.Budget_Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BudgetLines>()
                .HasOne(x => x.BudgetCategory)
                .WithMany()
                .HasForeignKey(x => x.Budget_Category_Id)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Budgets>()
                .HasOne(x => x.CreatedByUser)
                .WithMany()
                .HasForeignKey(x => x.Created_By)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Budgets>()
                .HasOne(x => x.ModifiedByUser)
                .WithMany()
                .HasForeignKey(x => x.Modified_By)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<BudgetsCategories>()
                .HasOne(x => x.CreatedByUser)
                .WithMany()
                .HasForeignKey(x => x.Created_By)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BudgetsCategories>()
                .HasOne(x => x.ModifiedByUser)
                .WithMany()
                .HasForeignKey(x => x.Modified_By)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<CapexRequests>()
                .HasOne(x => x.RequestedByUser)
                .WithMany()
                .HasForeignKey(x => x.Requested_By)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CapexRequests>()
                .HasOne(x => x.ApprovedByUser)
                .WithMany()
                .HasForeignKey(x => x.Approved_By)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<OpexRequests>()
                .HasOne(x => x.RequestedByUser)
                .WithMany()
                .HasForeignKey(x => x.Requested_By)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OpexRequests>()
                .HasOne(x => x.ApprovedByUser)
                .WithMany()
                .HasForeignKey(x => x.Approved_By)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<ExpenseClaims>()
                .HasOne(x => x.ClaimByUser)
                .WithMany()
                .HasForeignKey(x => x.Claim_By)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ExpenseClaims>()
                .HasOne(x => x.ApprovedByUser)
                .WithMany()
                .HasForeignKey(x => x.Approved_By)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<BudgetLines>()
                .Property(x => x.Allocated_Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<BudgetLines>()
                .Property(x => x.Utilized_Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Budgets>()
                .Property(x => x.Budget_Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CapexRequests>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OpexRequests>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ExpenseClaims>()
                .Property(x => x.Expense_Amount)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Role>()
            .HasOne(x => x.CreatedByUser)
            .WithMany()
            .HasForeignKey(x => x.CreatedBy)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Role>()
                .HasOne(x => x.ModifiedByUser)
                .WithMany()
                .HasForeignKey(x => x.ModifiedBy)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Department>()
    .HasOne(x => x.CreatedByUser)
    .WithMany()
    .HasForeignKey(x => x.CreatedBy)
    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Department>()
                .HasOne(x => x.ModifiedByUser)
                .WithMany()
                .HasForeignKey(x => x.ModifiedBy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Permissions>()
    .HasOne(x => x.CreatedByUser)
    .WithMany()
    .HasForeignKey(x => x.CreatedBy)
    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Permissions>()
                .HasOne(x => x.ModifiedByUser)
                .WithMany()
                .HasForeignKey(x => x.ModifiedBy)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
    .HasOne(x => x.role)
    .WithMany(x => x.users)
    .HasForeignKey(x => x.role_id)
    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}