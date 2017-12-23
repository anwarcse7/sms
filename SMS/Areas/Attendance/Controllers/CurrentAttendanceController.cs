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
    public class CurrentAttendanceController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: /Attendance/CurrentAttendance/
        public ActionResult Index()
        {
            var tbl_currentattendance = db.tbl_CurrentAttendance.Include(c => c.AttendanceUser);
            return View(tbl_currentattendance.ToList());
        }

        // GET: /Attendance/CurrentAttendance/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentAttendance currentattendance = db.tbl_CurrentAttendance.Find(id);
            if (currentattendance == null)
            {
                return HttpNotFound();
            }
            return View(currentattendance);
        }

        // GET: /Attendance/CurrentAttendance/Create
        public ActionResult Create()
        {
            ViewBag.AttendanceUserId = new SelectList(db.tbl_AttendanceUser, "AttendanceUserId", "Phone");
            return View();
        }

        // POST: /Attendance/CurrentAttendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CurrentAttendanceId,AttendanceUserId,Date,InTime,OutTime,Status")] CurrentAttendance currentattendance)
        {
            if (ModelState.IsValid)
            {
                db.tbl_CurrentAttendance.Add(currentattendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttendanceUserId = new SelectList(db.tbl_AttendanceUser, "AttendanceUserId", "Phone", currentattendance.AttendanceUserId);
            return View(currentattendance);
        }

        // GET: /Attendance/CurrentAttendance/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentAttendance currentattendance = db.tbl_CurrentAttendance.Find(id);
            if (currentattendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttendanceUserId = new SelectList(db.tbl_AttendanceUser, "AttendanceUserId", "Phone", currentattendance.AttendanceUserId);
            return View(currentattendance);
        }

        // POST: /Attendance/CurrentAttendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CurrentAttendanceId,AttendanceUserId,Date,InTime,OutTime,Status")] CurrentAttendance currentattendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currentattendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttendanceUserId = new SelectList(db.tbl_AttendanceUser, "AttendanceUserId", "Phone", currentattendance.AttendanceUserId);
            return View(currentattendance);
        }

        // GET: /Attendance/CurrentAttendance/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentAttendance currentattendance = db.tbl_CurrentAttendance.Find(id);
            if (currentattendance == null)
            {
                return HttpNotFound();
            }
            return View(currentattendance);
        }

        // POST: /Attendance/CurrentAttendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CurrentAttendance currentattendance = db.tbl_CurrentAttendance.Find(id);
            db.tbl_CurrentAttendance.Remove(currentattendance);
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
