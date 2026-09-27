using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FincoreCoreMvc.Models
{
    public class Role
    {
        [Key]
        public int role_id { get; set; }

        public string   role_name { get; set; }

        public string?  description { get; set; }

        public byte isActive { get; set; }

        public int created_by { get; set; }

        public DateTime created_at { get; set; }

        public DateTime ?  modified_at { get; set; }

        public int  ? modified_by { get; set; }
        public List<Permissions> ? permissions { get; set; }

        public List<User> ?  users { get; set; }


       
    }
}
