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
    public class BookMarksTrainer_MapController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/BookMarksTrainer_Map
        public IQueryable<BookMarksTrainer_Map> GetBookMarksTrainer_Map()
        {
            return db.BookMarksTrainer_Map;
        }

        // GET: api/BookMarksTrainer_Map/5
        [ResponseType(typeof(BookMarksTrainer_Map))]
        public async Task<IHttpActionResult> GetBookMarksTrainer_Map(string id)
        {
            BookMarksTrainer_Map bookMarksTrainer_Map = await db.BookMarksTrainer_Map.FindAsync(id);
            if (bookMarksTrainer_Map == null)
            {
                return NotFound();
            }

            return Ok(bookMarksTrainer_Map);
        }

        // PUT: api/BookMarksTrainer_Map/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookMarksTrainer_Map(string id, BookMarksTrainer_Map bookMarksTrainer_Map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookMarksTrainer_Map.BookMarksTrainer_MapID)
            {
                return BadRequest();
            }

            db.Entry(bookMarksTrainer_Map).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookMarksTrainer_MapExists(id))
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

        // POST: api/BookMarksTrainer_Map
        [ResponseType(typeof(BookMarksTrainer_Map))]
        public async Task<IHttpActionResult> PostBookMarksTrainer_Map(BookMarksTrainer_Map bookMarksTrainer_Map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookMarksTrainer_Map.Add(bookMarksTrainer_Map);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookMarksTrainer_MapExists(bookMarksTrainer_Map.BookMarksTrainer_MapID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bookMarksTrainer_Map.BookMarksTrainer_MapID }, bookMarksTrainer_Map);
        }

        // DELETE: api/BookMarksTrainer_Map/5
        [ResponseType(typeof(BookMarksTrainer_Map))]
        public async Task<IHttpActionResult> DeleteBookMarksTrainer_Map(string id)
        {
            BookMarksTrainer_Map bookMarksTrainer_Map = await db.BookMarksTrainer_Map.FindAsync(id);
            if (bookMarksTrainer_Map == null)
            {
                return NotFound();
            }

            db.BookMarksTrainer_Map.Remove(bookMarksTrainer_Map);
            await db.SaveChangesAsync();

            return Ok(bookMarksTrainer_Map);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookMarksTrainer_MapExists(string id)
        {
            return db.BookMarksTrainer_Map.Count(e => e.BookMarksTrainer_MapID == id) > 0;
        }
    }
}