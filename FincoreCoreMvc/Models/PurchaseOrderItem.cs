using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class PurchaseOrderItem
    {
        [Key]
        public int POItemId { get; set; }

        [Required]
        [ForeignKey("PurchaseOrder")]
        public int POId { get; set; }
        public virtual PurchaseOrder? PurchaseOrder { get; set; }
        public int? PRItemId { get; set; }

        [Required]
        [StringLength(40)]
        public string ItemName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ItemDescription { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxPercentage { get; set; } = 0;
        public decimal TaxAmount { get; set; } = 0;

        [Required]
        [StringLength(10)]
        public string ItemStatus { get; set; } = "Pending";

        [Required]
        [StringLength(20)]
        public string UnitOfMaterial { get; set; } = "Units";
        public decimal LineTotal { get; set; }
    }
}
