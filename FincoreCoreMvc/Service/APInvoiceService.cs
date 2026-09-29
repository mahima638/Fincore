using FincoreCoreMvc.Data;
using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace FincoreCoreMvc.Service
{
    public class APInvoiceService : IAPInvoiceService
    {
        AppDbContext db;

        public APInvoiceService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task AddAPInvoice(APInvoice a)
        {
            await db.APInvoices.AddAsync(a);
            await db.SaveChangesAsync();
        }

        public async Task DelAPInvoice(int id)
        {
            var data = await db.APInvoices.FindAsync(id);

            db.APInvoices.Remove(data);
            await db.SaveChangesAsync();
        }

        public async Task<List<APInvoice>> getAPInvoices()
        {
            var data = await db.APInvoices
                .Include(x => x.Vendor)
                .Include(x => x.PurchaseOrder)
                .Include(x => x.ApprovedByUser)
                .ToListAsync();

            return data;
        }

        public async Task<List<Vendor>> getVendors()
        {
            var data = await db.Vendors.ToListAsync();

            return data;
        }

        public async Task<List<PurchaseOrder>> getPurchaseOrders()
        {
            var data = await db.PurchaseOrders.ToListAsync();

            return data;
        }

        public async Task<List<User>> getUsers()
        {
            var data = await db.Users.ToListAsync();

            return data;
        }
    }
}