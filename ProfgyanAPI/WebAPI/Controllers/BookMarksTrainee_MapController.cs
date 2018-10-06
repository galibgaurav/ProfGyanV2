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
    public class BookMarksTrainee_MapController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/BookMarksTrainee_Map
        public IQueryable<BookMarksTrainee_Map> GetBookMarksTrainee_Map()
        {
            return db.BookMarksTrainee_Map;
        }

        // GET: api/BookMarksTrainee_Map/5
        [ResponseType(typeof(BookMarksTrainee_Map))]
        public async Task<IHttpActionResult> GetBookMarksTrainee_Map(string id)
        {
            BookMarksTrainee_Map bookMarksTrainee_Map = await db.BookMarksTrainee_Map.FindAsync(id);
            if (bookMarksTrainee_Map == null)
            {
                return NotFound();
            }

            return Ok(bookMarksTrainee_Map);
        }

        // PUT: api/BookMarksTrainee_Map/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookMarksTrainee_Map(string id, BookMarksTrainee_Map bookMarksTrainee_Map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookMarksTrainee_Map.BookmarkId)
            {
                return BadRequest();
            }

            db.Entry(bookMarksTrainee_Map).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookMarksTrainee_MapExists(id))
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

        // POST: api/BookMarksTrainee_Map
        [ResponseType(typeof(BookMarksTrainee_Map))]
        public async Task<IHttpActionResult> PostBookMarksTrainee_Map(BookMarksTrainee_Map bookMarksTrainee_Map)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookMarksTrainee_Map.Add(bookMarksTrainee_Map);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookMarksTrainee_MapExists(bookMarksTrainee_Map.BookmarkId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bookMarksTrainee_Map.BookmarkId }, bookMarksTrainee_Map);
        }

        // DELETE: api/BookMarksTrainee_Map/5
        [ResponseType(typeof(BookMarksTrainee_Map))]
        public async Task<IHttpActionResult> DeleteBookMarksTrainee_Map(string id)
        {
            BookMarksTrainee_Map bookMarksTrainee_Map = await db.BookMarksTrainee_Map.FindAsync(id);
            if (bookMarksTrainee_Map == null)
            {
                return NotFound();
            }

            db.BookMarksTrainee_Map.Remove(bookMarksTrainee_Map);
            await db.SaveChangesAsync();

            return Ok(bookMarksTrainee_Map);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookMarksTrainee_MapExists(string id)
        {
            return db.BookMarksTrainee_Map.Count(e => e.BookmarkId == id) > 0;
        }
    }
}