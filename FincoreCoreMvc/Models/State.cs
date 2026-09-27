using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class State
    {
        [Key]
        public int state_id { get; set; }

        public string state_name { get; set; }

        public int country_id { get; set; }

        [ForeignKey("country_id")]
        public Country  country { get; set; }

        public List<City> cities { get; set; }
        public byte is_active { get; set; }

        //[ForeignKey("user_id")]
        public int created_by { get; set; }
        //  public User user { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? modified_at { get; set; }


        // ForeignKey[("user_id")]
        public int? modified_by { get; set; }

    }
}
