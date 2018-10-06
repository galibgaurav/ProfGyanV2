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
    public class TrainingTypesController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/TrainingTypes
        public IQueryable<TrainingType> GetTrainingTypes()
        {
            return db.TrainingTypes;
        }

        // GET: api/TrainingTypes/5
        [ResponseType(typeof(TrainingType))]
        public async Task<IHttpActionResult> GetTrainingType(string id)
        {
            TrainingType trainingType = await db.TrainingTypes.FindAsync(id);
            if (trainingType == null)
            {
                return NotFound();
            }

            return Ok(trainingType);
        }

        // PUT: api/TrainingTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainingType(string id, TrainingType trainingType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingType.TypeId)
            {
                return BadRequest();
            }

            db.Entry(trainingType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingTypeExists(id))
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

        // POST: api/TrainingTypes
        [ResponseType(typeof(TrainingType))]
        public async Task<IHttpActionResult> PostTrainingType(TrainingType trainingType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrainingTypes.Add(trainingType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainingTypeExists(trainingType.TypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = trainingType.TypeId }, trainingType);
        }

        // DELETE: api/TrainingTypes/5
        [ResponseType(typeof(TrainingType))]
        public async Task<IHttpActionResult> DeleteTrainingType(string id)
        {
            TrainingType trainingType = await db.TrainingTypes.FindAsync(id);
            if (trainingType == null)
            {
                return NotFound();
            }

            db.TrainingTypes.Remove(trainingType);
            await db.SaveChangesAsync();

            return Ok(trainingType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainingTypeExists(string id)
        {
            return db.TrainingTypes.Count(e => e.TypeId == id) > 0;
        }
    }
}