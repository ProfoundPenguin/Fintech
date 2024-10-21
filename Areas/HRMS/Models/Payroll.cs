using System.ComponentModel.DataAnnotations;

namespace HRMS.Areas.HRMS.Models
{
    public class Payroll
    {
        // Primary Key
        [Key]
        public int ID { get; set; }

        // Name of the department
        [Required]
        [MaxLength(100)]
        public Member Member { get; set; }

        public DateTime PayDate { get; set; }
        public decimal? Amount { get; set; }

        // Navigation property for Members belonging to this department
        public ICollection<Member> Members { get; set; }
    }
}