using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class State
    {
        [Key]
        public int state_id { get; set; }

        public string ?  state_name { get; set; }

        public int ? country_id { get; set; }

        [ForeignKey("country_id")]
        public Country  country { get; set; }

        public List<City> ?  cities { get; set; }
       

    }
}
