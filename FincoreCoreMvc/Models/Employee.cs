using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class Employee
    {
        [Key]
        public int employee_id { get; set; }

        [Required]
        [ForeignKey("user_id")]
        public int ? user_id { get; set; }
        public User   user { get; set; }
        [Required]
        [ForeignKey("department_id")]
        public int  ? department_id { get; set; }
        public Department  department { get; set; }
        [Required]
        [ForeignKey("designation_id")]
        public int ? designation_id { get; set; }
        public Role designation { get; set; }
        [Required]
        [ForeignKey("company_id")]
        public int  ? company_id { get; set; }
        public Company company { get; set; }

        public DateTime? joining_date { get; set; }


        public byte  ? is_active { get; set; }

    
       

        [Column("Reporting Manager")]
        [ForeignKey("reporting_manager")]
        public int ? reporting_manager_id { get; set; }
        public Employee ?  reporting_manager { get; set; }


        List<Employee> ?  subordinates { get; set; }



    }
}
