using HRMS.Areas.HRMS.Models;
using System.ComponentModel.DataAnnotations;

namespace core.Areas.HRMS.Models
{
    public class Permission
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        public String Description { get; set; }

    }
}
