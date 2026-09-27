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


        //[ForeignKey("user_id")]
        public int created_by { get; set; }
        //  public User user { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? modified_at { get; set; }


        // ForeignKey[("user_id")]
        public int? modified_by { get; set; }

    }
}
