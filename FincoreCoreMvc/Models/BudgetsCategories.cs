using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class BudgetsCategories
    {
        [Key]
        public int Budget_Category_Id { get; set; }

        public string Categor_Name { get; set; }

        public int Department_Id { get; set; }

        [ForeignKey("Department_Id")]
        public Department Department { get; set; }

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