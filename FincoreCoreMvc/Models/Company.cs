using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class Company
    {
        [Key]
        public int company_id { get; set; }
        public string  ? company_name { get; set; }

        public string ?  company_code { get; set; }

        public string ? contact_number { get; set; }

        public string ? email { get; set; }

        public string ?  gstin { get; set; }

        public string  ? cin { get; set; }

        public string ? pan { get; set; }

        public string ? address { get; set; }

        public byte  ? is_active { get; set; }

        public int  ? city_id { get; set; }

        [ForeignKey("city_id")]
        public City city { get; set; }
        [ForeignKey("CreatedByUser")]
        public int? CreatedBy { get; set; }
        public User CreatedByUser { get; set; }

        public DateTime ? created_at { get; set; }

        public DateTime? modified_at { get; set; }


        [ForeignKey("ModifiedByUser")]
        public int? ModifiedBy { get; set; }
        public User ModifiedByUser { get; set; }

        List<Branches> ?  branches { get; set; }
        List<Employee> ?  employees { get; set; }



    }
}
