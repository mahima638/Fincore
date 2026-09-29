using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace FincoreCoreMvc.Models
{
    public class Assets
    {
        
        public int AssetsId { get; set; }

        [Required]
        public string AssetCode { get; set; }

        [Required]
        public string AssetName { get; set; }

        [ForeignKey("CapexRequest")]
        public int? Capex_Request_Id { get; set; }
        public CapexRequests CapexRequest { get; set; }

        [ForeignKey("PurchaseOrder")]
        public int? PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        [ForeignKey("GRN")]
        public int? GRNId { get; set; }
        public GRN GRN { get; set; }

        [ForeignKey("Vendor")]
        public int? VendorId { get; set; }
        public Vendor Vendor { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public DateTime? PurchaseDate { get; set; }

        
        public decimal? PurchaseCost { get; set; }

        
        public string Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
