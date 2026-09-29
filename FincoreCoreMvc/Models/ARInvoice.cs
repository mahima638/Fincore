using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class ARInvoice
    {
        public int ARInvoiceId { get; set; }

        [Required]
        public string InvoiceNumber { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [ForeignKey("RevenueEntry")]
        public int RevenueEntryId { get; set; }
        public RevenueEntry RevenueEntry { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public decimal? AmountReceived { get; set; }

        public decimal? AmountOutstanding { get; set; }

        [Required]
        public string PaymentStatus { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        // Navigation Properties
        public List<Payment> Payments { get; set; }
    }
}
