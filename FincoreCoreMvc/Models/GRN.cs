using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class GRN
    {
        [Key]
        public int GRNId { get; set; }

        [Required]
        [StringLength(30)]
        public string GRNCode { get; set; } = string.Empty;

        [Required]
        [ForeignKey("PurchaseOrder")]
        public int POId { get; set; }
        public virtual PurchaseOrder? PurchaseOrder { get; set; }

        [Required]
        public int VendorId { get; set; }
        public DateTime ReceivedDate { get; set; } = DateTime.Now;

        [Required]
        public int ReceivedBy { get; set; } = 1;

        [Required]
        [StringLength(20)]
        public string QualityCheckStatus { get; set; } = "Pending";
        public int? QualityCheckedBy { get; set; }

        [Required]
        [StringLength(20)]
        public string GRNStatus { get; set; } = "Draft";

        [StringLength(500)]
        public string? Remarks { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        //public virtual List<GRNItem> Items { get; set; } = new List<GRNItem>();
    }
}

