using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMS.Areas.Attendance.Models;
using SMS.Models;

namespace SMS.Areas.Attendance.Controllers
{
    public class AttendanceUserController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: /Attendance/AttendanceUser/
        public ActionResult Index()
        {
            return View(db.tbl_AttendanceUser.ToList());
        }

        // GET: /Attendance/AttendanceUser/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceUser attendanceuser = db.tbl_AttendanceUser.Find(id);
            if (attendanceuser == null)
            {
                return HttpNotFound();
            }
            return View(attendanceuser);
        }

        // GET: /Attendance/AttendanceUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Attendance/AttendanceUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AttendanceUserId,UserCode,FingerPrint,Phone,AdminMobileNo")] AttendanceUser attendanceuser)
        {
            if (ModelState.IsValid)
            {
                db.tbl_AttendanceUser.Add(attendanceuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendanceuser);
        }

        // GET: /Attendance/AttendanceUser/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceUser attendanceuser = db.tbl_AttendanceUser.Find(id);
            if (attendanceuser == null)
            {
                return HttpNotFound();
            }
            return View(attendanceuser);
        }

        // POST: /Attendance/AttendanceUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AttendanceUserId,UserCode,FingerPrint,Phone,AdminMobileNo")] AttendanceUser attendanceuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendanceuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendanceuser);
        }

        // GET: /Attendance/AttendanceUser/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceUser attendanceuser = db.tbl_AttendanceUser.Find(id);
            if (attendanceuser == null)
            {
                return HttpNotFound();
            }
            return View(attendanceuser);
        }

        // POST: /Attendance/AttendanceUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AttendanceUser attendanceuser = db.tbl_AttendanceUser.Find(id);
            db.tbl_AttendanceUser.Remove(attendanceuser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
