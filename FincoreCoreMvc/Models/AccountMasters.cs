using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class AccountMasters
    {
        [Key]
        public int Account_Id { get; set; }

        public string Account_Code { get; set; }

        public string Account_Name { get; set; }

        public string Account_Type { get; set; }

        public byte Is_Active { get; set; }

        public DateTime? Created_At { get; set; }

        public DateTime? Modified_At { get; set; }

        public int Created_By { get; set; }

        [ForeignKey("Created_By")]
        public User CreatedByUser { get; set; }

        public int? Modified_By { get; set; }

        [ForeignKey("Modified_By")]
        public User ModifiedByUser { get; set; }

       // public List<RevenueEntries> RevenueEntries { get; set; }

       // public List<JournalEntries> JournalEntries { get; set; }
    }
}