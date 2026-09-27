using System.ComponentModel.DataAnnotations;

namespace FincoreCoreMvc.Models
{
    public class Currency
    {
        [Key]
        public int currency_id { get; set; }

        public string currency_name { get; set; }

        public string currency_symbol { get; set; }

        public List<Country> countried { get; set; }
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
