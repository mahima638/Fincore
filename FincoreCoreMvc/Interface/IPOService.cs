using System.Collections.Generic;
using System.Threading.Tasks;
using FincoreCoreMvc.Models;

namespace FincoreCoreMvc.Interface
{
    public interface IPOService
    {
        Task<List<PurchaseOrder>> GetPurchaseOrdersAsync();
        Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(int id);
        Task<int> AddPurchaseOrderAsync(PurchaseOrder po);
        Task EditPurchaseOrderAsync(PurchaseOrder po, int id);
        Task DeletePurchaseOrderAsync(int id);
        Task UpdateStatusAsync(int id, string status);
        Task<string> GeneratePOCodeAsync();
    }
}
