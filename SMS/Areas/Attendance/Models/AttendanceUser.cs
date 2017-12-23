using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.Areas.Attendance.Models
{
    public class AttendanceUser
    {
        [Key]
        public Int64 AttendanceUserId { get; set; }
        //Foreign Key
        // Format: Student (100918001) 10 = Student, 09 = Class, 18 = Year, 001 = Student Id/Roll 
        // Format: Teacher (110718007) 11 = Teacher, 07 = Department, 18 = Year, 007 = Teacher Id
        [Index(IsUnique = true)]
        [Required]
        public Int64 UserCode { get; set; }
        [Column(TypeName = "image")]
        public byte[] FingerPrint { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(20)]
        public string AdminMobileNo { get; set; }

        public ICollection<CurrentAttendance> CurrentAttendances { get; set; } 
    }
}