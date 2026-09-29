using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class GRNItem
    {
        [Key]
        public int GRNItemId { get; set; }

        [Required]
        [ForeignKey("GRN")]
        public int GRNId { get; set; }
        public virtual GRN? GRN { get; set; }

        [Required]
        [ForeignKey("POItem")]
        public int POItemId { get; set; }
        public virtual PurchaseOrderItem? POItem { get; set; }
        public decimal ReceivedQuantity { get; set; }
        public decimal AcceptedQuantity { get; set; }
        public decimal RejectedQuantity { get; set; }

        [StringLength(255)]
        public string? RejectionReason { get; set; }
    }
}
