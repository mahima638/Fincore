using FincoreCoreMvc.Data;
using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace FincoreCoreMvc.Service
{
    public class PaymentService : IPaymentService
    {
        AppDbContext db;

        public PaymentService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task AddPayment(Payment p)
        {
            await db.Payments.AddAsync(p);
            await db.SaveChangesAsync();
        }

        public async Task DelPayment(int id)
        {
            var data = await db.Payments.FindAsync(id);

            db.Payments.Remove(data);

            await db.SaveChangesAsync();
        }

        public async Task<List<Payment>> getPayments()
        {
            var data = await db.Payments
                .Include(x => x.APInvoice)
                .Include(x => x.ARInvoice)
                .Include(x => x.Vendor)
                .Include(x => x.Customer)
                .Include(x => x.ApprovedByUser)
                .ToListAsync();

            return data;
        }

        public async Task<List<APInvoice>> getAPInvoices()
        {
            var data = await db.APInvoices.ToListAsync();

            return data;
        }

        public async Task<List<ARInvoice>> getARInvoices()
        {
            var data = await db.ARInvoices.ToListAsync();

            return data;
        }

        public async Task<List<Vendor>> getVendors()
        {
            var data = await db.Vendors.ToListAsync();

            return data;
        }

        public async Task<List<Customer>> getCustomers()
        {
            var data = await db.Customers.ToListAsync();

            return data;
        }

        public async Task<List<User>> getUsers()
        {
            var data = await db.Users.ToListAsync();

            return data;
        }
    }
}