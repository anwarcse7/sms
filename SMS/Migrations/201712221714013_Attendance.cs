namespace SMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceUsers",
                c => new
                    {
                        AttendanceUserId = c.Long(nullable: false, identity: true),
                        UserCode = c.Long(nullable: false),
                        FingerPrint = c.Binary(nullable: false, storeType: "image"),
                        Phone = c.String(maxLength: 20),
                        AdminMobileNo = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.AttendanceUserId)
                .Index(t => t.UserCode, unique: true);
            
            CreateTable(
                "dbo.CurrentAttendances",
                c => new
                    {
                        CurrentAttendanceId = c.Long(nullable: false, identity: true),
                        AttendanceUserId = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        InTime = c.DateTime(nullable: false),
                        OutTime = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.CurrentAttendanceId)
                .ForeignKey("dbo.AttendanceUsers", t => t.AttendanceUserId, cascadeDelete: true)
                .Index(t => t.AttendanceUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CurrentAttendances", "AttendanceUserId", "dbo.AttendanceUsers");
            DropIndex("dbo.CurrentAttendances", new[] { "AttendanceUserId" });
            DropIndex("dbo.AttendanceUsers", new[] { "UserCode" });
            DropTable("dbo.CurrentAttendances");
            DropTable("dbo.AttendanceUsers");
        }
    }
}
