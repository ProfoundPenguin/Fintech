using System.ComponentModel.DataAnnotations;

namespace HRMS.Areas.HRMS.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; } // Unique identifier for each position

        [Required]
        [StringLength(100)]
        public string Title { get; set; } // Title of the position

        [StringLength(500)]
        public string Description { get; set; } // Description of the position

        public ICollection<Member> Members { get; set; }
    }
}
