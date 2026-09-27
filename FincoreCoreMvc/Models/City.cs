using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class City
    {
        [Key]
        public int city_id { get; set; }

        public string city_name { get; set; }

        public int state_id { get; set; }
        [ForeignKey("state_id")]
        public State state { get; set; }

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
