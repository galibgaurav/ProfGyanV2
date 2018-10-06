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
using Profgyan.helper;

namespace WebAPI.Controllers
{
    public class CoursesController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        [AllowAnonymous]
        // GET: api/Courses
        public IQueryable<Course> GetCourses()
        {
            return db.Courses;
        }

        // GET: api/Courses/5
        [ResponseType(typeof(Course))]
        public async Task<IHttpActionResult> GetCourse(string id)
        {
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        [Authorize]
        public async Task<IHttpActionResult> PutCourse(string id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.CourseId)
            {
                return BadRequest();
            }

            db.Entry(course).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        [ResponseType(typeof(Course))]
        [Authorize]
        public async Task<IHttpActionResult> PostCourse(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var courseModel = AutoMapper.Mapper.Map<CourseDTO, Course>(courseDTO);
            courseModel.CourseId = GuidGenerator.GetGuid();
            db.Courses.Add(courseModel);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourseExists(courseModel.CourseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = courseModel.CourseId }, courseModel);
        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(Course))]
        [Authorize]
        public async Task<IHttpActionResult> DeleteCourse(string id)
        {
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            db.Courses.Remove(course);
            await db.SaveChangesAsync();

            return Ok(course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseExists(string id)
        {
            return db.Courses.Count(e => e.CourseId == id) > 0;
        }
    }
}