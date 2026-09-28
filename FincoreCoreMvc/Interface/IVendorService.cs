using FincoreCoreMvc.Models;

namespace FincoreCoreMvc.Interface
{
    public interface IVendorService
    {
        Task AddVendor(Vendor vend);
        Task <List<Company>> GetCompany();

        Task<List<Vendor>> GetVendor();

        Task DelVendor(int id);

        Task UpdVendor(Vendor vnd);

        Task<Vendor> FindVendorById(int id);
    }
}
