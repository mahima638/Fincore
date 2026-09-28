using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class BudgetLines
    {
        [Key]
        public int Budget_Line_Id { get; set; }

        public int Budget_Id { get; set; }

        [ForeignKey("Budget_Id")]
        public Budgets Budget { get; set; }

        public int Budget_Category_Id { get; set; }

        [ForeignKey("Budget_Category_Id")]
        public BudgetsCategories BudgetCategory { get; set; }

        public decimal Allocated_Amount { get; set; }

        public decimal? Utilized_Amount { get; set; }

        public byte Is_Active { get; set; }

        public DateTime? Created_At { get; set; }

        public DateTime? Modified_At { get; set; }

        public int Created_By { get; set; }

        [ForeignKey("Created_By")]
        public User CreatedByUser { get; set; }

        public int? Modified_By { get; set; }

        [ForeignKey("Modified_By")]
        public User ModifiedByUser { get; set; }

        public List<CapexRequests> CapexRequests { get; set; }

        public List<OpexRequests> OpexRequests { get; set; }
    }
}