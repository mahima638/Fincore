using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class Permissions
    {
        [Key]
        public int permission_id { get; set; }

        public string ? permission_name { get; set; }

        public byte ? is_active { get; set; }


        [Required]
        [ForeignKey("CreatedByUser")]
        public int ? CreatedBy { get; set; }
        public User CreatedByUser { get; set; }

        public DateTime ?  created_at { get; set; }

        public DateTime? modified_at { get; set; }

        [Required]
        [ForeignKey("ModifiedByUser")]
        public int ? ModifiedBy { get; set; }
        public User ModifiedByUser { get; set; }

        public int ? role_id { get; set; }

        [ForeignKey("role_id")]
        public Role role { get; set; }
    }
}
