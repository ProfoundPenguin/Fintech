// Models/Member.cs
using System.ComponentModel.DataAnnotations;

namespace HRMS.Areas.HRMS.Models
{

    public enum EmployeeType
    {
        Onsite,
        Remote
    }

    public enum EmployeeCategory
    {
        Paid,
        Unpaid
    }

    public enum Status
    {
        Active,
        Inactive
    }

    public class Member
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } 
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } 
        [Phone]
        public string Phone { get; set; }
        public Role Role { get; set; }
        public Department Department { get; set; } 
        public EmployeeType EmployeeType { get; set; } 
        public EmployeeCategory EmployeeCategory { get; set; }
        public DateTime DateOfJoining { get; set; }
        public decimal? Salary { get; set; }
        public Status Status { get; set; } 
        
    }

}
