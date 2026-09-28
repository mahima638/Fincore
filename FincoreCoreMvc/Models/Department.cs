using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class Department
    {
        [Key]
        public int department_id { get; set; }

        public string department_name { get; set; }

        public byte is_active { get; set; }

        [ForeignKey("branch_id")]
        public int branch_id { get; set; }

        [Required]
        [ForeignKey("CreatedByUser")]
        public int ? CreatedBy { get; set; }
        public User CreatedByUser { get; set; }

        public DateTime created_at { get; set; }


        [Required]
        [ForeignKey("ModifiedByUser")]
        public int ? ModifiedBy { get; set; }
        public User ModifiedByUser { get; set; }

    }
}
