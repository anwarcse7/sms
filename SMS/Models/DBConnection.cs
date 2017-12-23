using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SMS.Areas.Attendance.Models;

namespace SMS.Models
{
    public class DBConnection : DbContext
    {
        public DbSet<AttendanceUser> tbl_AttendanceUser { get; set; }
        public DbSet<CurrentAttendance> tbl_CurrentAttendance { get; set; } 
    }
}