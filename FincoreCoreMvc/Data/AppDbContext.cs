using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AccountMasters> AccountMasters { get; set; }

        public DbSet<BudgetLines> BudgetLines { get; set; }

        public DbSet<Budgets> Budgets { get; set; }

        public DbSet<BudgetsCategories> BudgetsCategories { get; set; }

        public DbSet<CapexRequests> CapexRequests { get; set; }

        public DbSet<ExpenseClaims> ExpenseClaims { get; set; }

        public DbSet<OpexRequests> OpexRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
        }
    }
}