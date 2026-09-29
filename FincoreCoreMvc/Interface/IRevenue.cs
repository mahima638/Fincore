using FincoreCoreMvc.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FincoreCoreMvc.Interface
{
    public interface IRevenue
    {
        //Revenue Entry Number – Auto-generated

        //Customer – Dropdown
    //    Task<List<Customer>> fetchcustomer();

        //Revenue Date – Date picker


        //Revenue Type – Dropdown
  //      Task<List<RevenueEntry>> fetchrevenue(); 

//Description – Text area

//Amount – Amount in ₹
//Task Add Amount ()

//Payment Status – Dropdown(Pending, Partial, Paid)

//Reference / Invoice Number – Optional

            Task<List<Customer>> fetchcustomer();

            Task<List<RevenueEntry>> fetchrevenue();

            Task AddRevenue(RevenueEntry r);

        Task<RevenueEntry?> GetRevenueById(int id);

        Task UpdateRevenue(RevenueEntry r);
        Task deleterevenue(int id);

    }
    
}

