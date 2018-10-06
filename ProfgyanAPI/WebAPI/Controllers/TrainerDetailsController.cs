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
    public class TrainerDetailsController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/TrainerDetails
        public IQueryable<TrainerDetail> GetTrainerDetails()
        {
            return db.TrainerDetails;
        }

        // GET: api/TrainerDetails/5
        [ResponseType(typeof(TrainerDetail))]
        public async Task<IHttpActionResult> GetTrainerDetail(string id)
        {
            TrainerDetail trainerDetail = await db.TrainerDetails.FindAsync(id);
            if (trainerDetail == null)
            {
                return NotFound();
            }

            return Ok(trainerDetail);
        }

        // PUT: api/TrainerDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainerDetail(string id, TrainerDetail trainerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainerDetail.TrDetailId)
            {
                return BadRequest();
            }

            db.Entry(trainerDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerDetailExists(id))
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

        // POST: api/TrainerDetails
        [ResponseType(typeof(TrainerDetail))]
        public async Task<IHttpActionResult> PostTrainerDetail(TrainerDetail trainerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrainerDetails.Add(trainerDetail);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainerDetailExists(trainerDetail.TrDetailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = trainerDetail.TrDetailId }, trainerDetail);
        }

        // DELETE: api/TrainerDetails/5
        [ResponseType(typeof(TrainerDetail))]
        public async Task<IHttpActionResult> DeleteTrainerDetail(string id)
        {
            TrainerDetail trainerDetail = await db.TrainerDetails.FindAsync(id);
            if (trainerDetail == null)
            {
                return NotFound();
            }

            db.TrainerDetails.Remove(trainerDetail);
            await db.SaveChangesAsync();

            return Ok(trainerDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainerDetailExists(string id)
        {
            return db.TrainerDetails.Count(e => e.TrDetailId == id) > 0;
        }
    }
}