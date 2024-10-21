using System.ComponentModel.DataAnnotations;

namespace HRMS.Areas.HRMS.Models
{
    public enum AttendanceStatus
    {
        Present,
        Absent
    }

    public class Attendance
    {
        // Primary Key
        [Key]
        public int ID { get; set; }

        // Foreign Key for Member
        public int MemberId { get; set; }

        // Navigation property for the associated Member
        [Required]
        public Member Member { get; set; }

        // Date of attendance
        [Required]
        public DateOnly Date { get; set; }

        // Attendance status
        public AttendanceStatus Status { get; set; }
    }
}