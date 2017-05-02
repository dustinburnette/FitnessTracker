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
    public class ExerciseTypesApiController : ApiController
    {
        private FitnessTrackerContext db = new FitnessTrackerContext();

        // GET: api/ExerciseTypesApi
        public IQueryable<ExerciseType> GetExerciseTypes()
        {
            return db.ExerciseTypes;
        }

        // GET: api/ExerciseTypesApi/5
        [ResponseType(typeof(ExerciseType))]
        public IHttpActionResult GetExerciseType(int id)
        {
            ExerciseType exerciseType = db.ExerciseTypes.Find(id);
            if (exerciseType == null)
            {
                return NotFound();
            }

            return Ok(exerciseType);
        }

        // PUT: api/ExerciseTypesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExerciseType(int id, ExerciseType exerciseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exerciseType.ExerciseTypeID)
            {
                return BadRequest();
            }

            db.Entry(exerciseType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseTypeExists(id))
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

        // POST: api/ExerciseTypesApi
        [ResponseType(typeof(ExerciseType))]
        public IHttpActionResult PostExerciseType(ExerciseType exerciseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExerciseTypes.Add(exerciseType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exerciseType.ExerciseTypeID }, exerciseType);
        }

        // DELETE: api/ExerciseTypesApi/5
        [ResponseType(typeof(ExerciseType))]
        public IHttpActionResult DeleteExerciseType(int id)
        {
            ExerciseType exerciseType = db.ExerciseTypes.Find(id);
            if (exerciseType == null)
            {
                return NotFound();
            }

            db.ExerciseTypes.Remove(exerciseType);
            db.SaveChanges();

            return Ok(exerciseType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseTypeExists(int id)
        {
            return db.ExerciseTypes.Count(e => e.ExerciseTypeID == id) > 0;
        }
    }
}