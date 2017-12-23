using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.Areas.Attendance.Models
{
    public class CurrentAttendance
    {
        [Key]
        public Int64 CurrentAttendanceId { get; set; }
        [Required]
        [ForeignKey("AttendanceUser")]
        public Int64 AttendanceUserId { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime InTime { get; set; }
        [DataType(DataType.Time)]
        [Required]
        public DateTime OutTime { get; set; }
        public string Status { get; set; }
        //Foreign Key Class
        public AttendanceUser AttendanceUser { get; set; }

    }
}