using FincoreCoreMvc.Models;

namespace FincoreCoreMvc.Interface
{
    public interface IARInvoice
    {
        Task<List<ARInvoice>> fetcharinvoice();

        Task AddARInvoice(ARInvoice a);
        Task<ARInvoice?> getarinvoicebyid(int id);

        Task UpdateARInvoice(ARInvoice a);

        Task deletearinvoice(int id);
    }
}