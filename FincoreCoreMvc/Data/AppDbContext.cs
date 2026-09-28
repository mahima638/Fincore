using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> user { get; set; }

        public DbSet<Role> role { get; set; }
        public DbSet<Department> department { get; set; }

        public DbSet<Permissions> permission { get; set; }

        public DbSet<Company> company { get; set; }

        public DbSet<Employee> employee { get; set; }




    



    }
}