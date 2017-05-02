using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class ExerciseSessionsApiController : ApiController
    {
        private FitnessTrackerContext db = new FitnessTrackerContext();

        // GET: api/ExerciseSessionsApi
        public IQueryable<ExerciseSession> GetExerciseSessions()
        {
            return db.ExerciseSessions;
        }

        // GET: api/ExerciseSessionsApi/5
        [ResponseType(typeof(ExerciseSession))]
        public IHttpActionResult GetExerciseSession(int id)
        {
            ExerciseSession exerciseSession = db.ExerciseSessions.Find(id);
            if (exerciseSession == null)
            {
                return NotFound();
            }

            return Ok(exerciseSession);
        }

        // PUT: api/ExerciseSessionsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExerciseSession(int id, ExerciseSession exerciseSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exerciseSession.ExerciseSessionID)
            {
                return BadRequest();
            }

            db.Entry(exerciseSession).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseSessionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ExerciseSessionsApi
        [ResponseType(typeof(ExerciseSession))]
        public IHttpActionResult PostExerciseSession(ExerciseSession exerciseSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExerciseSessions.Add(exerciseSession);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exerciseSession.ExerciseSessionID }, exerciseSession);
        }

        // DELETE: api/ExerciseSessionsApi/5
        [ResponseType(typeof(ExerciseSession))]
        public IHttpActionResult DeleteExerciseSession(int id)
        {
            ExerciseSession exerciseSession = db.ExerciseSessions.Find(id);
            if (exerciseSession == null)
            {
                return NotFound();
            }

            db.ExerciseSessions.Remove(exerciseSession);
            db.SaveChanges();

            return Ok(exerciseSession);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseSessionExists(int id)
        {
            return db.ExerciseSessions.Count(e => e.ExerciseSessionID == id) > 0;
        }
    }
}