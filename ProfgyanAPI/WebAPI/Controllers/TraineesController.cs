using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Profgyan.Data;
using Profgyan.DataModel;

namespace WebAPI.Controllers
{
    public class TraineesController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/Trainees
        public IQueryable<Trainee> GetTrainees()
        {
            return db.Trainees;
        }

        // GET: api/Trainees/5
        [ResponseType(typeof(Trainee))]
        public async Task<IHttpActionResult> GetTrainee(string id)
        {
            Trainee trainee = await db.Trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }

            return Ok(trainee);
        }

        // PUT: api/Trainees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainee(string id, Trainee trainee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainee.TraineeID)
            {
                return BadRequest();
            }

            db.Entry(trainee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraineeExists(id))
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

        // POST: api/Trainees
        [ResponseType(typeof(Trainee))]
        public async Task<IHttpActionResult> PostTrainee(Trainee trainee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trainees.Add(trainee);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TraineeExists(trainee.TraineeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = trainee.TraineeID }, trainee);
        }

        // DELETE: api/Trainees/5
        [ResponseType(typeof(Trainee))]
        public async Task<IHttpActionResult> DeleteTrainee(string id)
        {
            Trainee trainee = await db.Trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }

            db.Trainees.Remove(trainee);
            await db.SaveChangesAsync();

            return Ok(trainee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TraineeExists(string id)
        {
            return db.Trainees.Count(e => e.TraineeID == id) > 0;
        }
    }
}