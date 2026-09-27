using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class Permissions
    {
        [Key]
        public int permission_id { get; set; }

        public string permission_name { get; set; }

        public byte is_active { get; set; }


        public int created_by { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? modified_at { get; set; }

        public int? modified_by { get; set; }

        public int role_id { get; set; }

        [ForeignKey("role_id")]
        public Role role { get; set; }
    }
}
