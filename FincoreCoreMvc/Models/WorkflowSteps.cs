using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class WorkflowSteps
    {
        [Key]
        public int workflowsteps_id { get; set; }
        public string  ? workflowstep_name { get; set; }

        public int ?  workflowstep_number { get; set; }
        [ForeignKey("workflowdefination_id")]
        public int ? workflowdefination_id { get; set; }
        public WorkflowDefination workflow { get; set; }

        [ForeignKey("role_id")]
        public int ? approver_role_id { get; set; }
        public Role role { get; set; }
        public byte ? is_active { get; set; }

        [ForeignKey("user_id")]
        public int ?  created_by { get; set; }
        public User user { get; set; }


        public DateTime ? created_at { get; set; }

        public DateTime? modified_at { get; set; }


        [ForeignKey("user_id")]
        public int? modified_by { get; set; }
    }
}
