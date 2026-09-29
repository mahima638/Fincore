using FincoreCoreMvc.Data;
using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FincoreCoreMvc.Service
{
    public class ARInvoiceService : IARInvoice
    {
        private readonly AppDbContext db;

        public ARInvoiceService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<List<ARInvoice>> fetcharinvoice()
        {
            return await db.ARInvoices.ToListAsync();
        }

        public async Task AddARInvoice(ARInvoice a)
        {
            await db.ARInvoices.AddAsync(a);
            await db.SaveChangesAsync();
        }
        public async Task<ARInvoice?> getarinvoicebyid(int id)
        {
            return await db.ARInvoices
                .FirstOrDefaultAsync(x => x.ARInvoiceId == id);
        }

        public async Task UpdateARInvoice(ARInvoice a)
        {
            db.ARInvoices.Update(a);
            await db.SaveChangesAsync();
        }

        public async Task deletearinvoice(int id)
        {
            var data = await db.ARInvoices.FindAsync(id);

            if (data != null)
            {
                db.ARInvoices.Remove(data);
                await db.SaveChangesAsync();
            }
        }
    }
}