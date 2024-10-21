using System.ComponentModel.DataAnnotations;

namespace HRMS.Areas.HRMS.Models
{
    public class Department
    {
        // Primary Key
        [Key]
        public int ID { get; set; }

        // Name of the department
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Description of the department
        [MaxLength(500)]
        public string Description { get; set; }

        // Navigation property for Members belonging to this department
        public ICollection<Member> Members { get; set; }
    }
}