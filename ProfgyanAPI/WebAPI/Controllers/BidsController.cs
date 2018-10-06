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
    public class BidsController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/Bids
        public IQueryable<Bid> GetBid()
        {
            return db.Bid;
        }

        // GET: api/Bids/5
        [ResponseType(typeof(Bid))]
        public async Task<IHttpActionResult> GetBid(string id)
        {
            Bid bid = await db.Bid.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }

            return Ok(bid);
        }

        // PUT: api/Bids/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBid(string id, Bid bid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bid.BidId)
            {
                return BadRequest();
            }

            db.Entry(bid).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidExists(id))
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

        // POST: api/Bids
        [ResponseType(typeof(Bid))]
        public async Task<IHttpActionResult> PostBid(Bid bid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bid.Add(bid);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BidExists(bid.BidId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bid.BidId }, bid);
        }

        // DELETE: api/Bids/5
        [ResponseType(typeof(Bid))]
        public async Task<IHttpActionResult> DeleteBid(string id)
        {
            Bid bid = await db.Bid.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }

            db.Bid.Remove(bid);
            await db.SaveChangesAsync();

            return Ok(bid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BidExists(string id)
        {
            return db.Bid.Count(e => e.BidId == id) > 0;
        }
    }
}