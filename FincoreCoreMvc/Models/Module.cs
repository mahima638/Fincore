using System.ComponentModel.DataAnnotations;

namespace FincoreCoreMvc.Models
{
    public class Module
    {
        [Key]
        public int module_id { get; set; }

        public string module_name { get; set; }


    }
}
