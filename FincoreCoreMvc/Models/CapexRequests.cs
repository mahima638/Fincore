using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class CapexRequests
    {
        [Key]
        public int Capex_Request_Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public int Department_Id { get; set; }

        [ForeignKey("Department_Id")]
        public Department Department { get; set; }

        public int Budget_Line_Id { get; set; }

        [ForeignKey("Budget_Line_Id")]
        public BudgetLines BudgetLine { get; set; }

        public int Requested_By { get; set; }

        [ForeignKey("Requested_By")]
        public User RequestedByUser { get; set; }

        public string Approval_Status { get; set; }

        public int? Approved_By { get; set; }

        [ForeignKey("Approved_By")]
        public User ApprovedByUser { get; set; }

        public DateTime? Approved_At { get; set; }

        public DateTime? Created_At { get; set; }

        public DateTime? Modified_At { get; set; }

        //public List<Assets> Assets { get; set; }
    }
}