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
    public class PaymentModesController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/PaymentModes
        public IQueryable<PaymentMode> GetPaymentModes()
        {
            return db.PaymentModes;
        }

        // GET: api/PaymentModes/5
        [ResponseType(typeof(PaymentMode))]
        public async Task<IHttpActionResult> GetPaymentMode(string id)
        {
            PaymentMode paymentMode = await db.PaymentModes.FindAsync(id);
            if (paymentMode == null)
            {
                return NotFound();
            }

            return Ok(paymentMode);
        }

        // PUT: api/PaymentModes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPaymentMode(string id, PaymentMode paymentMode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentMode.ModeId)
            {
                return BadRequest();
            }

            db.Entry(paymentMode).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentModeExists(id))
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

        // POST: api/PaymentModes
        [ResponseType(typeof(PaymentMode))]
        public async Task<IHttpActionResult> PostPaymentMode(PaymentMode paymentMode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentModes.Add(paymentMode);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaymentModeExists(paymentMode.ModeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = paymentMode.ModeId }, paymentMode);
        }

        // DELETE: api/PaymentModes/5
        [ResponseType(typeof(PaymentMode))]
        public async Task<IHttpActionResult> DeletePaymentMode(string id)
        {
            PaymentMode paymentMode = await db.PaymentModes.FindAsync(id);
            if (paymentMode == null)
            {
                return NotFound();
            }

            db.PaymentModes.Remove(paymentMode);
            await db.SaveChangesAsync();

            return Ok(paymentMode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentModeExists(string id)
        {
            return db.PaymentModes.Count(e => e.ModeId == id) > 0;
        }
    }
}