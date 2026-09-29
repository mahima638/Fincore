using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class Country
    {
        [Key]
        public int country_id { get; set; }

        public string ? country_name { get; set; }

        public int ? country_code { get; set; }

      

        public List<Company> ? companies { get; set; }

        public List<State> ? state { get; set; }
       
    }
}
