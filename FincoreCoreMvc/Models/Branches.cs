using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class Branches
    {
        [Key]
        public int branch_id { get; set; }

        [ForeignKey("company_id")]
        public int comppany_id { get; set; }
        public Company company { get; set; }

        public int branch_code { get; set; }

        public string branch_name { get; set; }
       
        public string address { get; set; }

        [ForeignKey("city_id")]
        public int city_id { get; set; }
        public City city { get; set; }
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
