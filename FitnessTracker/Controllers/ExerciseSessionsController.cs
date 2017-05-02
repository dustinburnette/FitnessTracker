using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class ExerciseSessionsController : Controller
    {
        private FitnessTrackerContext db = new FitnessTrackerContext();

        // GET: ExerciseSessions
        public ActionResult Index()
        {
            var exerciseSessions = db.ExerciseSessions.Include(e => e.Exercise);
            return View(exerciseSessions.ToList());
        }

        // GET: ExerciseSessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseSession exerciseSession = db.ExerciseSessions.Find(id);
            if (exerciseSession == null)
            {
                return HttpNotFound();
            }
            return View(exerciseSession);
        }

        // GET: ExerciseSessions/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseTypeID = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "Description");
            return View();
        }

        // POST: ExerciseSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExerciseSessionID,StartTime,EndTime,ExerciseTypeID")] ExerciseSession exerciseSession)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseSessions.Add(exerciseSession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseTypeID = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "Description", exerciseSession.ExerciseTypeID);
            return View(exerciseSession);
        }

        // GET: ExerciseSessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseSession exerciseSession = db.ExerciseSessions.Find(id);
            if (exerciseSession == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseTypeID = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "Description", exerciseSession.ExerciseTypeID);
            return View(exerciseSession);
        }

        // POST: ExerciseSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExerciseSessionID,StartTime,EndTime,ExerciseTypeID")] ExerciseSession exerciseSession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseTypeID = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "Description", exerciseSession.ExerciseTypeID);
            return View(exerciseSession);
        }

        // GET: ExerciseSessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseSession exerciseSession = db.ExerciseSessions.Find(id);
            if (exerciseSession == null)
            {
                return HttpNotFound();
            }
            return View(exerciseSession);
        }

        // POST: ExerciseSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseSession exerciseSession = db.ExerciseSessions.Find(id);
            db.ExerciseSessions.Remove(exerciseSession);
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
