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
    public class SubscriptionTrainee_MapController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/SubscriptionTrainee_Map
        public IQueryable<SubscriptionTrainee_Map> GetSubscriptionTrainee_Map()
        {
            return db.SubscriptionTrainee_Map;
        }

        // GET: api/SubscriptionTrainee_Map/5
        [ResponseType(typeof(SubscriptionTrainee_Map))]
        public async Task<IHttpActionResult> GetSubscriptionTrainee_Map(string id)
        {
            SubscriptionTrainee_Map subscriptionTrainee_Map = await db.SubscriptionTrainee_Map.FindAsync(id);
            if (subscriptionTrainee_Map == null)
            {
                return NotFound();
            }

            return Ok(subscriptionTrainee_Map);
        }

        // PUT: api/SubscriptionTrainee_Map/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubscriptionTrainee_Map(string id, SubscriptionTrainee_Map subscriptionTrainee_Map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscriptionTrainee_Map.SubscriptionTrainee_MapID)
            {
                return BadRequest();
            }

            db.Entry(subscriptionTrainee_Map).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionTrainee_MapExists(id))
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

        // POST: api/SubscriptionTrainee_Map
        [ResponseType(typeof(SubscriptionTrainee_Map))]
        public async Task<IHttpActionResult> PostSubscriptionTrainee_Map(SubscriptionTrainee_Map subscriptionTrainee_Map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubscriptionTrainee_Map.Add(subscriptionTrainee_Map);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubscriptionTrainee_MapExists(subscriptionTrainee_Map.SubscriptionTrainee_MapID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subscriptionTrainee_Map.SubscriptionTrainee_MapID }, subscriptionTrainee_Map);
        }

        // DELETE: api/SubscriptionTrainee_Map/5
        [ResponseType(typeof(SubscriptionTrainee_Map))]
        public async Task<IHttpActionResult> DeleteSubscriptionTrainee_Map(string id)
        {
            SubscriptionTrainee_Map subscriptionTrainee_Map = await db.SubscriptionTrainee_Map.FindAsync(id);
            if (subscriptionTrainee_Map == null)
            {
                return NotFound();
            }

            db.SubscriptionTrainee_Map.Remove(subscriptionTrainee_Map);
            await db.SaveChangesAsync();

            return Ok(subscriptionTrainee_Map);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubscriptionTrainee_MapExists(string id)
        {
            return db.SubscriptionTrainee_Map.Count(e => e.SubscriptionTrainee_MapID == id) > 0;
        }
    }
}