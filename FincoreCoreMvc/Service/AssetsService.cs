using FincoreCoreMvc.Data;
using FincoreCoreMvc.Models;
using FincoreCoreMvc.Interface;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace FincoreCoreMvc.Service
{
    public class AssetsService : IAssets
    {
        private readonly AppDbContext db;

        public AssetsService(AppDbContext db)
        {
            this.db = db;
        }

      
        public async Task AddAsset(Assets a)
        {
            a.CreatedAt = DateTime.Now;

            await db.asset.AddAsync(a);
            await db.SaveChangesAsync();
        }

     
        public async Task<List<Assets>> FetchAssets()
        {
            var data = await db.asset
                .Include(x => x.Vendor)
                .Include(x => x.PurchaseOrder)
                .Include(x => x.GRN)
                .Include(x => x.CapexRequest)
                .Include(x => x.Department)
                .ToListAsync();

            return data;
        }

      
        public async Task<List<Vendor>> FetchVendors()
        {
            var data = await db.Vendors.ToListAsync();
            return data;
        }

   
        public async Task<List<PurchaseOrder>> FetchPurchaseOrders()
        {
            var data = await db.PurchaseOrders.ToListAsync();
            return data;
        }

  
        public async Task<List<GRN>> FetchGRNs()
        {
            var data = await db.grn.ToListAsync();
            return data;
        }

       
        public async Task<List<CapexRequests>> FetchCapexRequests()
        {
            var data = await db.CapexRequests.ToListAsync();
            return data;
        }

   
        public async Task<List<Department>> FetchDepartments()
        {
            var data = await db.department.ToListAsync();
            return data;
        }
        public async Task<Assets> GetAssetById(int id)
        {
            var data = await db.asset
                .FirstOrDefaultAsync(x => x.AssetsId == id);

            return data;
        }

        public async Task UpdateAsset(Assets a)
        {
            var data = await db.asset.FindAsync(a);
            if (data != null)
            {

                await db.SaveChangesAsync();
            }
        }
    }
}