using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FincoreCoreMvc.Models
{
    public class Role
    {
        [Key]
        public int role_id { get; set; }

        public string role_name { get; set; }

        public string description { get; set; }

        public string isActive { get; set; }

       // public string Created
    }
}
