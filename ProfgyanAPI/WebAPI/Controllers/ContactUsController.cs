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
using Profgyan.DTO;

namespace WebAPI.Controllers
{
    public class ContactUsController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/ContactUs
        public IQueryable<ContactUs> GetContactUs()
        {
            return db.ContactUs;
        }

        // GET: api/ContactUs/5
        [ResponseType(typeof(ContactUs))]
        public async Task<IHttpActionResult> GetContactUs(string id)
        {
            ContactUs contactUs = await db.ContactUs.FindAsync(id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return Ok(contactUs);
        }

        // PUT: api/ContactUs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContactUs(string id, ContactUs contactUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactUs.ContactusId)
            {
                return BadRequest();
            }

            db.Entry(contactUs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactUsExists(id))
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

        // POST: api/ContactUs
        [ResponseType(typeof(ContactUs))]
        public async Task<IHttpActionResult> PostContactUs(ContactUsDTO contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ContactUs contactUs = new ContactUs()
            {
                ContactusId = Guid.NewGuid().ToString().Replace('-',' '),
                Name = contact.Name,
                Email = contact.Email,
                Message = contact.Message,
                Subject = contact.Subject,
                Mobile = contact.Mobile
            };

            db.ContactUs.Add(contactUs);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContactUsExists(contactUs.ContactusId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = contactUs.ContactusId }, contactUs);
        }

        // DELETE: api/ContactUs/5
        [ResponseType(typeof(ContactUs))]
        public async Task<IHttpActionResult> DeleteContactUs(string id)
        {
            ContactUs contactUs = await db.ContactUs.FindAsync(id);
            if (contactUs == null)
            {
                return NotFound();
            }

            db.ContactUs.Remove(contactUs);
            await db.SaveChangesAsync();

            return Ok(contactUs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactUsExists(string id)
        {
            return db.ContactUs.Count(e => e.ContactusId == id) > 0;
        }
    }
}