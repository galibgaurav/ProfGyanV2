using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Profgyan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ProfGyan.Controllers
{
    public class RoleController: ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        [HttpGet]
        [Route("api/GetAllRoles")]
        [AllowAnonymous]
        public HttpResponseMessage GetRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var roles = roleMngr.Roles
                .Select(x => new { x.Id, x.Name })
                .ToList();
            return this.Request.CreateResponse(HttpStatusCode.OK, roles);
        }
        [HttpGet]
        [Route("api/GetRole/{username}")]
        [Authorize]
        public HttpResponseMessage GetRoles(string username)
        {
            var userStore = new UserStore<ProfGyanUser>(db);
            var manager = new UserManager<ProfGyanUser>(userStore);
            var user = manager.Users.SingleOrDefault(x => x.UserName==username);
            var userRoles = user.Roles.ToList();

            var roleStore = new RoleStore<IdentityRole>(db);
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var roles = roleMngr.Roles
                .Select(x => new { x.Id, x.Name })
                .ToList();
           
            return this.Request.CreateResponse(HttpStatusCode.OK, roles.Where(x => x.Id == userRoles[0].RoleId).ToList());
        }

         protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);

        }
    }
}