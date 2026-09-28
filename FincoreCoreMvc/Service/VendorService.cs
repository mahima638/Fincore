using FincoreCoreMvc.Data;
using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Service
{
    public class VendorService : IVendorService
    {
        public AppDbContext db;
        public VendorService(AppDbContext db) 
        {
            this.db = db;
        }
        public async Task AddVendor(Vendor vend)
        {
            await db.Vendors.AddAsync(vend);
            await db.SaveChangesAsync();
        }

        public async Task DelVendor(int id)
        {
            var d = await db.Vendors.FindAsync(id);
            db.Vendors.Remove(d);
            await db.SaveChangesAsync();
        }

        public async Task<Vendor> FindVendorById(int id)
        {
            var d = await db.Vendors.FindAsync(id);
            return d;
        }

        public async Task<List<Company>> GetCompany()
        {
            var c = await db.Companies.ToListAsync();
            return c;
        }

        public async Task<List<Vendor>> GetVendor()
        {
            var v = await db.Vendors. Include(x=>x.Company).ToListAsync();
            return v;
        }

        public async Task UpdVendor(Vendor vnd)
        {
            db.Vendors.Update(vnd);
            await db.SaveChangesAsync();
        }
    }
}
