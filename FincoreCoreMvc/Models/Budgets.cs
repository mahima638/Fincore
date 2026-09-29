using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class Budgets
    {
        [Key]
        public int Budget_Id { get; set; }

        public string Budget_Code { get; set; }

        public string Budget_Name { get; set; }

        public int Budget_Category_Id { get; set; }

        [ForeignKey("Budget_Category_Id")]
        public BudgetsCategories BudgetCategory { get; set; }

        public string Financial_Year { get; set; }

        public DateTime? Start_Date { get; set; }

        public DateTime? End_Date { get; set; }

        public decimal Budget_Amount { get; set; }

        public byte Is_Active { get; set; }

        public DateTime? Created_At { get; set; }

        public DateTime? Modified_At { get; set; }

        public int Created_By { get; set; }

        [ForeignKey("Created_By")]
        public User CreatedByUser { get; set; }

        public int? Modified_By { get; set; }

        [ForeignKey("Modified_By")]
        public User ModifiedByUser { get; set; }

        public List<BudgetLines> BudgetLines { get; set; }
    }
}