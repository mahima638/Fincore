using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace FincoreCoreMvc.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentNumber { get; set; }


        public string PaymentType { get; set; }


        // Foreign Key → APInvoice
        [ForeignKey("APInvoice")]
        public int? APInvoiceId { get; set; }

        public APInvoice APInvoice { get; set; }


        // Foreign Key → ARInvoice
        [ForeignKey("ARInvoice")]
        public int? ARInvoiceId { get; set; }

        public ARInvoice ARInvoice { get; set; }


        // Foreign Key → Vendor
        [ForeignKey("Vendor")]
        public int? VendorId { get; set; }

        public Vendor Vendor { get; set; }


        // Foreign Key → Customer
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public Customer Customer { get; set; }


        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; }


        // Foreign Key → User
        [ForeignKey("ApprovedByUser")]
        public int? ApprovedBy { get; set; }

        public User ApprovedByUser { get; set; }


        public bool ReconciledFlag { get; set; }

        public string ApprovalStatus { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

    }
}