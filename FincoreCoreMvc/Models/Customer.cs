using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        public string CustomerCode { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        public byte IsActive { get; set; }

        // Navigation Properties
        public List<RevenueEntry> RevenueEntries { get; set; }
        public List<ARInvoice> ARInvoices { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
