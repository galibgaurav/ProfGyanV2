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
    public class SessionTrainer_MapController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/SessionTrainer_Map
        public IQueryable<SessionTrainer_Map> GetSessionTrainer_Map()
        {
            return db.SessionTrainer_Map;
        }

        // GET: api/SessionTrainer_Map/5
        [ResponseType(typeof(SessionTrainer_Map))]
        public async Task<IHttpActionResult> GetSessionTrainer_Map(string id)
        {
            SessionTrainer_Map sessionTrainer_Map = await db.SessionTrainer_Map.FindAsync(id);
            if (sessionTrainer_Map == null)
            {
                return NotFound();
            }

            return Ok(sessionTrainer_Map);
        }

        // PUT: api/SessionTrainer_Map/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSessionTrainer_Map(string id, SessionTrainer_Map sessionTrainer_Map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sessionTrainer_Map.SessionTrainer_MapID)
            {
                return BadRequest();
            }

            db.Entry(sessionTrainer_Map).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionTrainer_MapExists(id))
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

        // POST: api/SessionTrainer_Map
        [ResponseType(typeof(SessionTrainer_Map))]
        public async Task<IHttpActionResult> PostSessionTrainer_Map(SessionTrainer_Map sessionTrainer_Map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SessionTrainer_Map.Add(sessionTrainer_Map);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SessionTrainer_MapExists(sessionTrainer_Map.SessionTrainer_MapID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sessionTrainer_Map.SessionTrainer_MapID }, sessionTrainer_Map);
        }

        // DELETE: api/SessionTrainer_Map/5
        [ResponseType(typeof(SessionTrainer_Map))]
        public async Task<IHttpActionResult> DeleteSessionTrainer_Map(string id)
        {
            SessionTrainer_Map sessionTrainer_Map = await db.SessionTrainer_Map.FindAsync(id);
            if (sessionTrainer_Map == null)
            {
                return NotFound();
            }

            db.SessionTrainer_Map.Remove(sessionTrainer_Map);
            await db.SaveChangesAsync();

            return Ok(sessionTrainer_Map);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SessionTrainer_MapExists(string id)
        {
            return db.SessionTrainer_Map.Count(e => e.SessionTrainer_MapID == id) > 0;
        }
    }
}