using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace FincoreCoreMvc.Models
{
    public class Role
    {
        [Key]
        public int role_id { get; set; }

        public string ?  role_name { get; set; }

        public string?  description { get; set; }

        public byte ? isActive { get; set; }

        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }
        public User CreatedByUser { get; set; }

        public DateTime ? created_at { get; set; }

        public DateTime ?  modified_at { get; set; }

        [Required]
        [ForeignKey("ModifiedByUser")]
        public int ModifiedBy { get; set; }
        public User ModifiedByUser { get; set; }
        public List<Permissions> ? permissions { get; set; }

        public List<User> ?  users { get; set; }


       
    }
}
