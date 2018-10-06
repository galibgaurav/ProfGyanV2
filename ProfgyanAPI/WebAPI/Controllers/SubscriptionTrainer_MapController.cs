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
    public class SubscriptionTrainer_MapController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/SubscriptionTrainer_Map
        public IQueryable<SubscriptionTrainer_Map> GetSubscriptionTrainer_Map()
        {
            return db.SubscriptionTrainer_Map;
        }

        // GET: api/SubscriptionTrainer_Map/5
        [ResponseType(typeof(SubscriptionTrainer_Map))]
        public async Task<IHttpActionResult> GetSubscriptionTrainer_Map(string id)
        {
            SubscriptionTrainer_Map subscriptionTrainer_Map = await db.SubscriptionTrainer_Map.FindAsync(id);
            if (subscriptionTrainer_Map == null)
            {
                return NotFound();
            }

            return Ok(subscriptionTrainer_Map);
        }

        // PUT: api/SubscriptionTrainer_Map/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubscriptionTrainer_Map(string id, SubscriptionTrainer_Map subscriptionTrainer_Map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscriptionTrainer_Map.SubscriptionTrainer_MapID)
            {
                return BadRequest();
            }

            db.Entry(subscriptionTrainer_Map).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionTrainer_MapExists(id))
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

        // POST: api/SubscriptionTrainer_Map
        [ResponseType(typeof(SubscriptionTrainer_Map))]
        public async Task<IHttpActionResult> PostSubscriptionTrainer_Map(SubscriptionTrainer_Map subscriptionTrainer_Map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubscriptionTrainer_Map.Add(subscriptionTrainer_Map);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubscriptionTrainer_MapExists(subscriptionTrainer_Map.SubscriptionTrainer_MapID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subscriptionTrainer_Map.SubscriptionTrainer_MapID }, subscriptionTrainer_Map);
        }

        // DELETE: api/SubscriptionTrainer_Map/5
        [ResponseType(typeof(SubscriptionTrainer_Map))]
        public async Task<IHttpActionResult> DeleteSubscriptionTrainer_Map(string id)
        {
            SubscriptionTrainer_Map subscriptionTrainer_Map = await db.SubscriptionTrainer_Map.FindAsync(id);
            if (subscriptionTrainer_Map == null)
            {
                return NotFound();
            }

            db.SubscriptionTrainer_Map.Remove(subscriptionTrainer_Map);
            await db.SaveChangesAsync();

            return Ok(subscriptionTrainer_Map);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubscriptionTrainer_MapExists(string id)
        {
            return db.SubscriptionTrainer_Map.Count(e => e.SubscriptionTrainer_MapID == id) > 0;
        }
    }
}