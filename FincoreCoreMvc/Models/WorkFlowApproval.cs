using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class WorkFlowApproval
    {
        [Key]
        public int workflowapproval_id { get; set; }

        [ForeignKey("workflowdefination_id")]
        public int ? workflowdefination_id { get; set; }
        public WorkflowDefination workflow { get; set; }

        [ForeignKey("workflowstep_id")]
        public int ?  workflowstep_id { get; set; }
        public WorkflowSteps workflowstep { get; set; }

        public string ?  status { get; set; }


        [ForeignKey("user_id")]
        public int ? action_by { get; set; }
        public User approver_user { get; set; }

        public DateTime ? action_date { get; set; } =  DateTime.Now;

        public string ? comments { get; set; }

        public User user { get; set; }



    }
}
