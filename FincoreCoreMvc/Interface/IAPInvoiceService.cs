using FincoreCoreMvc.Models;
using System.Numerics;

namespace FincoreCoreMvc.Interface
{
    public interface IAPInvoiceService   
    {
        Task AddAPInvoice(APInvoice a);
        Task<List<APInvoice>> getAPInvoices();
        Task<List<Vendor>> getVendors();
        Task<List<PurchaseOrder>> getPurchaseOrders();
        Task<List<User>> getUsers();
        Task DelAPInvoice(int id);
    }
}