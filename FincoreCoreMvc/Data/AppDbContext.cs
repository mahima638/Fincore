using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<APInvoice> APInvoices { get; set; }

        public DbSet<Payment> Payments { get; set; }




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

        }
    }
}
