using FincoreCoreMvc.Models;
using System.Numerics;

namespace FincoreCoreMvc.Interface
{
    public interface IPaymentService
    {
        Task AddPayment(Payment p);

        Task<List<Payment>> getPayments();

        Task<List<APInvoice>> getAPInvoices();

        Task<List<ARInvoice>> getARInvoices();

        Task<List<Vendor>> getVendors();

        Task<List<Customer>> getCustomers();

        Task<List<User>> getUsers();

        Task DelPayment(int id);
    }
}