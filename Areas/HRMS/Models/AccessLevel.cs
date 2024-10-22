using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core.Areas.HRMS.Models
{
    public class AccessLevel
    {
        public enum level
        {
            admin,
            manager,
            employee
        }

        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public level Level { get; set; }
        [Column(TypeName = "text[]")]
        public List<Permission> Permission { get; set; }
    }
}
