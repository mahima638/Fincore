using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class JournalEntry
    {
        [Key]
        public int JournalEntryId { get; set; }

        [Required]
        public string JournalNumber { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        [Required]
        [ForeignKey("AccountMasters")]
        public int Account_Id { get; set; }

        public AccountMasters AccountMasters { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal? DebitAmount { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal? CreditAmount { get; set; }


        public string Description { get; set; }

        [Required]
        public int Created_By { get; set; }

        public User CreatedByUser { get; set; }


        [Required]
        public DateTime Created_At { get; set; }
    }
}