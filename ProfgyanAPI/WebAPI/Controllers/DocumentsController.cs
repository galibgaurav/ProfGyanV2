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
using System.Web;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    public class DocumentsController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/Documents
        public IQueryable<Document> GetDocuments()
        {
            return db.Documents;
        }

        // GET: api/Documents/5
        [ResponseType(typeof(Document))]
        public async Task<IHttpActionResult> GetDocument(string id)
        {
            Document document = await db.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        // PUT: api/Documents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDocument(string id, Document document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != document.DocumentId)
            {
                return BadRequest();
            }

            db.Entry(document).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
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

        // POST: api/Documents
        [ResponseType(typeof(Document))]
        [Authorize]
        public async Task<IHttpActionResult> PostDocument()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            var UserEmail = claims.Select(x => { if (x.Type == "Email") return x.Value; else return null; }).SingleOrDefault(x=>x!=null);
            Document document = new Document();
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            if(httpRequest.Files.Count==1)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    document.DocumentId = Guid.NewGuid().ToString();
                    document.FileName = postedFile.FileName;
                    document.FileType = postedFile.ContentType;
                    document.UserIdentity = UserEmail;
                    postedFile.SaveAs(System.Configuration.ConfigurationManager.AppSettings["DocumentUploadBasePath"].ToString()+"\\" + postedFile.FileName);
                }
                try
                {
                    db.Documents.Add(document);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (DocumentExists(document.DocumentId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

            }

            return CreatedAtRoute("DefaultApi", new { id = document.DocumentId }, document);
        }

        // DELETE: api/Documents/5
        [ResponseType(typeof(Document))]
        public async Task<IHttpActionResult> DeleteDocument(string id)
        {
            Document document = await db.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            db.Documents.Remove(document);
            await db.SaveChangesAsync();

            return Ok(document);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentExists(string id)
        {
            return db.Documents.Count(e => e.DocumentId == id) > 0;
        }
    }
}
