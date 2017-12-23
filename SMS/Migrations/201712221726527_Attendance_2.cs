namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attendance_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AttendanceUsers", "FingerPrint", c => c.Binary(storeType: "image"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AttendanceUsers", "FingerPrint", c => c.Binary(nullable: false, storeType: "image"));
        }
    }
}
