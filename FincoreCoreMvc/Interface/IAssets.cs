using FincoreCoreMvc.Models;
using System.Numerics;

namespace FincoreCoreMvc.Interface
{
    public interface IAssets
    {
       
        Task AddAsset(Assets a);

       
        Task<List<Assets>> FetchAssets();

       
        Task<List<Vendor>> FetchVendors();

        Task<List<PurchaseOrder>> FetchPurchaseOrders();

        Task<List<GRN>> FetchGRNs();

        Task<List<CapexRequests>> FetchCapexRequests();

        Task<List<Department>> FetchDepartments();
        Task<Assets> GetAssetById(int id);
        Task UpdateAsset(Assets a);
    }
}