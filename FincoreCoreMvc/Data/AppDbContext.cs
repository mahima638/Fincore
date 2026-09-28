using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
        }
    }
}