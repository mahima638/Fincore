using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }

        [ForeignKey("role_id")]
        public int  ? role_id { get; set; }
        public Role role { get; set; }


        [Required]
        public string ? full_name { get; set; }
        [Required]
        public string ?  email { get; set; }
        [Required]
        public string ? pass { get; set; }
        [Required]
        public string ? phone { get; set; }

        public byte ? is_active { get; set; }


        [ForeignKey("CreatedByUser")]
        public int? created_by { get; set; }
        public User CreatedByUser { get; set; }

        public DateTime ? created_at { get; set; }

        public DateTime? modified_at { get; set; }


        [ForeignKey("ModifiedByUser")]
        public int? modified_by { get; set; }
        public User? ModifiedByUser { get; set; }



    }
}
