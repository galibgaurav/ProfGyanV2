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
    public class ValidationPasscodesController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/ValidationPasscodes
        public IQueryable<ValidationPasscode> GetValidationPasscode()
        {
            return db.ValidationPasscode;
        }

        // GET: api/ValidationPasscodes/5
        [ResponseType(typeof(ValidationPasscode))]
        public async Task<IHttpActionResult> GetValidationPasscode(string id)
        {
            ValidationPasscode validationPasscode = await db.ValidationPasscode.FindAsync(id);
            if (validationPasscode == null)
            {
                return NotFound();
            }

            return Ok(validationPasscode);
        }

        // PUT: api/ValidationPasscodes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutValidationPasscode(string id, ValidationPasscode validationPasscode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != validationPasscode.validationElement)
            {
                return BadRequest();
            }

            db.Entry(validationPasscode).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValidationPasscodeExists(id))
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

        // POST: api/ValidationPasscodes
        [ResponseType(typeof(ValidationPasscode))]
        public async Task<IHttpActionResult> PostValidationPasscode(ValidationPasscode validationPasscode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ValidationPasscode.Add(validationPasscode);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ValidationPasscodeExists(validationPasscode.validationElement))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = validationPasscode.validationElement }, validationPasscode);
        }

        // DELETE: api/ValidationPasscodes/5
        [ResponseType(typeof(ValidationPasscode))]
        public async Task<IHttpActionResult> DeleteValidationPasscode(string id)
        {
            ValidationPasscode validationPasscode = await db.ValidationPasscode.FindAsync(id);
            if (validationPasscode == null)
            {
                return NotFound();
            }

            db.ValidationPasscode.Remove(validationPasscode);
            await db.SaveChangesAsync();

            return Ok(validationPasscode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ValidationPasscodeExists(string id)
        {
            return db.ValidationPasscode.Count(e => e.validationElement == id) > 0;
        }
    }
}