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
    public class SocialMediasController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/SocialMedias
        public IQueryable<SocialMedia> GetSocialMedias()
        {
            return db.SocialMedias;
        }

        // GET: api/SocialMedias/5
        [ResponseType(typeof(SocialMedia))]
        public async Task<IHttpActionResult> GetSocialMedia(string id)
        {
            SocialMedia socialMedia = await db.SocialMedias.FindAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            return Ok(socialMedia);
        }

        // PUT: api/SocialMedias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSocialMedia(string id, SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != socialMedia.SocialMediaId)
            {
                return BadRequest();
            }

            db.Entry(socialMedia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialMediaExists(id))
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

        // POST: api/SocialMedias
        [ResponseType(typeof(SocialMedia))]
        public async Task<IHttpActionResult> PostSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SocialMedias.Add(socialMedia);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SocialMediaExists(socialMedia.SocialMediaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = socialMedia.SocialMediaId }, socialMedia);
        }

        // DELETE: api/SocialMedias/5
        [ResponseType(typeof(SocialMedia))]
        public async Task<IHttpActionResult> DeleteSocialMedia(string id)
        {
            SocialMedia socialMedia = await db.SocialMedias.FindAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            db.SocialMedias.Remove(socialMedia);
            await db.SaveChangesAsync();

            return Ok(socialMedia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SocialMediaExists(string id)
        {
            return db.SocialMedias.Count(e => e.SocialMediaId == id) > 0;
        }
    }
}