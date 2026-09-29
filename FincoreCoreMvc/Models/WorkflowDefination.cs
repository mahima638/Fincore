using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class WorkflowDefination
    {
        [Key]
        public int workflowdefination_id { get; set; }
        public string ? workflow_name { get; set; }

        public string ? workflow_description { get; set; }

        public string ? module_name { get; set; }
        public byte ?  is_active { get; set; }

        [ForeignKey("user_id")]
        public int ?  created_by { get; set; }


        public DateTime ? created_at { get; set; }

        public DateTime? modified_at { get; set; }


        [ForeignKey("user_id")]
        public int? modified_by { get; set; }

        public List<WorkflowSteps> ? workflowsteps { get; set; }
    }
}
