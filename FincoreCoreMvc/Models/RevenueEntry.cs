using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class RevenueEntry
    {
        public int RevenueEntryId { get; set; }

        public string InvoiceNumber { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        public string RevenueType { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime RevenueDate { get; set; }

        [Required]
        [ForeignKey("AccountMaster")]
        public int Account_Id { get; set; }
        public AccountMasters AccountMaster { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        [Required]
        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }
        public User CreatedByUser { get; set; }

        [Required]
        [ForeignKey("ModifiedByUser")]
        public int ModifiedBy { get; set; }
        public User ModifiedByUser { get; set; }

        // Navigation Properties
        public List<ARInvoice> ARInvoices { get; set; }
    }
}
