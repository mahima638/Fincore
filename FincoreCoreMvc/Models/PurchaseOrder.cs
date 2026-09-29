using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FincoreCoreMvc.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int POId { get; set; }

        [Required]
        [StringLength(30)]
        public string POCode { get; set; } = string.Empty;

        [Required]
        public int VendorId { get; set; }
        public int? QuotationId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; } = 0;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Draft";
        public byte IsActive { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? ModifiedAt { get; set; }
        public int CreatedBy { get; set; } = 1;
        public int? ModifiedBy { get; set; }
        public virtual List<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();
    }
}
