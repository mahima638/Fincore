using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class ExpenseClaims
    {
        [Key]
        public int Expense_Claim_Id { get; set; }

        public string Claim_Number { get; set; }

        public string Description { get; set; }

        public int Opex_Request_Id { get; set; }

        [ForeignKey("Opex_Request_Id")]
        public OpexRequests OpexRequest { get; set; }

        public DateTime Expense_Date { get; set; }

        public string Expense_Type { get; set; }

        public decimal Expense_Amount { get; set; }

        public int Claim_By { get; set; }

        [ForeignKey("Claim_By")]
        public User ClaimByUser { get; set; }

        public string Approval_Status { get; set; }

        public DateTime? Created_At { get; set; }

        public DateTime? Modified_At { get; set; }

        public int? Approved_By { get; set; }

        [ForeignKey("Approved_By")]
        public User ApprovedByUser { get; set; }
    }
}