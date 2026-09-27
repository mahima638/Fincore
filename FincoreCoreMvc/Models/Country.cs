using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class Country
    {
        [Key]
        public int country_id { get; set; }

        public string country_name { get; set; }

        public int country_code { get; set; }

        public int currency_id { get; set; }
        [ForeignKey("currency_id")]
        public Currency currency { get; set; }

        public List<Company> companies { get; set; }

        public List<State> state { get; set; }
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
