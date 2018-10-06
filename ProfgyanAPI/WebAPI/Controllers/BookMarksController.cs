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
    public class BookMarksController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/BookMarks
        public IQueryable<BookMark> GetBookMarks()
        {
            return db.BookMarks;
        }

        // GET: api/BookMarks/5
        [ResponseType(typeof(BookMark))]
        public async Task<IHttpActionResult> GetBookMark(string id)
        {
            BookMark bookMark = await db.BookMarks.FindAsync(id);
            if (bookMark == null)
            {
                return NotFound();
            }

            return Ok(bookMark);
        }

        // PUT: api/BookMarks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookMark(string id, BookMark bookMark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookMark.BookmarkId)
            {
                return BadRequest();
            }

            db.Entry(bookMark).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookMarkExists(id))
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

        // POST: api/BookMarks
        [ResponseType(typeof(BookMark))]
        public async Task<IHttpActionResult> PostBookMark(BookMark bookMark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookMarks.Add(bookMark);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookMarkExists(bookMark.BookmarkId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bookMark.BookmarkId }, bookMark);
        }

        // DELETE: api/BookMarks/5
        [ResponseType(typeof(BookMark))]
        public async Task<IHttpActionResult> DeleteBookMark(string id)
        {
            BookMark bookMark = await db.BookMarks.FindAsync(id);
            if (bookMark == null)
            {
                return NotFound();
            }

            db.BookMarks.Remove(bookMark);
            await db.SaveChangesAsync();

            return Ok(bookMark);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookMarkExists(string id)
        {
            return db.BookMarks.Count(e => e.BookmarkId == id) > 0;
        }
    }
}