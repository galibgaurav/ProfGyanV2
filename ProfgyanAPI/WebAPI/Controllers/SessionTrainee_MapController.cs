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
    public class SessionTrainee_MapController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/SessionTrainee_Map
        public IQueryable<SessionTrainee_Map> GetSessionTrainee_Map()
        {
            return db.SessionTrainee_Map;
        }

        // GET: api/SessionTrainee_Map/5
        [ResponseType(typeof(SessionTrainee_Map))]
        public async Task<IHttpActionResult> GetSessionTrainee_Map(string id)
        {
            SessionTrainee_Map sessionTrainee_Map = await db.SessionTrainee_Map.FindAsync(id);
            if (sessionTrainee_Map == null)
            {
                return NotFound();
            }

            return Ok(sessionTrainee_Map);
        }

        // PUT: api/SessionTrainee_Map/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSessionTrainee_Map(string id, SessionTrainee_Map sessionTrainee_Map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sessionTrainee_Map.SessionTrainee_MapID)
            {
                return BadRequest();
            }

            db.Entry(sessionTrainee_Map).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionTrainee_MapExists(id))
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

        // POST: api/SessionTrainee_Map
        [ResponseType(typeof(SessionTrainee_Map))]
        public async Task<IHttpActionResult> PostSessionTrainee_Map(SessionTrainee_Map sessionTrainee_Map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SessionTrainee_Map.Add(sessionTrainee_Map);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SessionTrainee_MapExists(sessionTrainee_Map.SessionTrainee_MapID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sessionTrainee_Map.SessionTrainee_MapID }, sessionTrainee_Map);
        }

        // DELETE: api/SessionTrainee_Map/5
        [ResponseType(typeof(SessionTrainee_Map))]
        public async Task<IHttpActionResult> DeleteSessionTrainee_Map(string id)
        {
            SessionTrainee_Map sessionTrainee_Map = await db.SessionTrainee_Map.FindAsync(id);
            if (sessionTrainee_Map == null)
            {
                return NotFound();
            }

            db.SessionTrainee_Map.Remove(sessionTrainee_Map);
            await db.SaveChangesAsync();

            return Ok(sessionTrainee_Map);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SessionTrainee_MapExists(string id)
        {
            return db.SessionTrainee_Map.Count(e => e.SessionTrainee_MapID == id) > 0;
        }
    }
}