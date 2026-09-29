using FincoreCoreMvc.Data;
using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Service
{
    public class RevenueServices : IRevenue
    {
        private readonly AppDbContext db;

        public RevenueServices(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Customer>> fetchcustomer()
        {
            return await db.Customer.ToListAsync();
        }

        public async Task<List<RevenueEntry>> fetchrevenue()
        {
            return await db.revenue_entry.ToListAsync();
        }

        public async Task AddRevenue(RevenueEntry r)
        {
            await db.revenue_entry.AddAsync(r);
            await db.SaveChangesAsync();
        }

        public async Task<RevenueEntry?> GetRevenueById(int id)
        {
            return await db.revenue_entry
                .FirstOrDefaultAsync(x => x.RevenueEntryId == id);
        }

        public async Task UpdateRevenue(RevenueEntry r)
        {
            db.revenue_entry.Update(r);
            await db.SaveChangesAsync();
        }
        public async Task deleterevenue(int id)
        {
            var data = await db.revenue_entry.FindAsync(id);

            if (data != null)
            {
                db.revenue_entry.Remove(data);
                await db.SaveChangesAsync();
            }
        }
    }
}