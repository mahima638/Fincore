using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace FincoreCoreMvc.Models
{
    public class APInvoice
    {
        [Key]
        public int APInvoiceId { get; set; }

        [Required]
        [StringLength(50)]
        public string InvoiceNumber { get; set; }


        // Foreign Key  Vendor table
        [Required]
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }

        public Vendor Vendor { get; set; }


        // Foreign Key → PurchaseOrder table
        [Required]
        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderId { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }


        // Foreign Key → GRN table
        [Required]
        [ForeignKey("GRN")]
        public int GRNId { get; set; }

        public GRN GRN { get; set; }


        // Foreign Key → WorkOrder table
        [ForeignKey("WorkOrder")]
        public int? WorkOrderId { get; set; }

       // public WorkOrder WorkOrder { get; set; }


        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }


        // Foreign Key → User table
        [ForeignKey("ApprovedByUser")]
        public int? ApprovedBy { get; set; }

        public User ApprovedByUser { get; set; }


        public string InvoiceFile { get; set; }

        public string ApprovalStatus { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }


        // One AP Invoice can have multiple Payments
        public List<Payment> Payments { get; set; }
    }
}
