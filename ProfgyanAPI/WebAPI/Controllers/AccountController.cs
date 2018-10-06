using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Profgyan.Data;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Profgyan.DataModel;
using WebAPI;
using System.Web.Http.Description;
using System.Linq;
using Profgyan.DTO;
using System.Net.Http;
using System.Net;
using System.Web;
using System;

namespace ProfGyan.Controllers
{
    public class AccountController : ApiController
    {
        //Db context
        private ProfGyanDBContext db = new ProfGyanDBContext();

        [HttpGet]
        [ResponseType(typeof(UserInfo))]
        [WebAPI.Authorize]
        [Route("api/GetLoggedInUserInfo")]
        public  async Task<IHttpActionResult> GetLoggedInUserInfo()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            var UserEmail = claims.Select(x => { if (x.Type == "Email") return x.Value; else return null; }).SingleOrDefault(x => x != null);
            var user = db.Users.SingleOrDefault(x => x.Email == UserEmail);
            if (user == null)
            {
                ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "User Not Found, Please perform SignUp/Register"));
            }
            UserInfo result = new UserInfo()
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };

            var trainer = db.Trainers.SingleOrDefault(x => x.UserID == user.Id);
            if (trainer != null)
            {
                //trainerDTO.firstName=trainer.FirstName;
                //trainerDTO.lastName=trainer.LastName;
                var commDetails = db.CommonDetails.SingleOrDefault(x => x.ID == trainer.CommonDetailID);
                result.trainerDTO = new TrainerDTO();
                if (commDetails != null)
                {
                    result.trainerDTO.academicYear = commDetails.AcademicYear.ToString();
                    result.trainerDTO.address = commDetails.Address;
                    result.trainerDTO.City = commDetails.City;
                    result.trainerDTO.department = commDetails.Department;
                    result.trainerDTO.dob = commDetails.DOB.ToString();
                    result.trainerDTO.highestQualification = commDetails.HighestQualification;
                    result.trainerDTO.PINCode = commDetails.PINCode;
                    result.trainerDTO.state = commDetails.state;
                    }
                var trainerDetail = db.TrainerDetails.SingleOrDefault(x => x.TrainerId == trainer.TrainerId);
                if (trainerDetail != null)
                {
                    result.trainerDTO.companies = trainerDetail.Companies;
                    result.trainerDTO.industrialExp = trainerDetail.Experience;
                    result.trainerDTO.skillSet = trainerDetail.SkillSet;
                    result.trainerDTO.socialMediaLink = trainerDetail.SocialMediaId;
                    result.trainerDTO.teachingExp = trainerDetail.TeachingExperience;
                }
            }
            return Ok(result);
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("api/User/Register")]
        [HttpPost]
        public async Task<IdentityResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return new IdentityResult("Registraion Data not valid");
                //return BadRequest(ModelState);
            }
            var userStore = new UserStore<ProfGyanUser>(new ProfGyanDBContext());
            var manager = new UserManager<ProfGyanUser>(userStore);
            var user = new ProfGyanUser() { UserName = model.UserName, Email = model.Email };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            
            IdentityResult result = await manager.CreateAsync(user, model.Password);
            await manager.AddToRolesAsync(user.Id, model.Roles);
            return result;

        }

        [HttpGet]
        [Route("api/GetUserClaims")]
        [WebAPI.Authorize]
        //Only for testing the Auth and auth feature
        public RegisterBindingModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            RegisterBindingModel model = new RegisterBindingModel()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value,
              };
            return model;
        }
        [HttpGet]
        [Route("api/logout")]
        [WebAPI.Authorize]
        public HttpResponseMessage Logout()
        {
            var authentication = HttpContext.Current.GetOwinContext().Authentication;
            authentication.SignOut();
            string redirectUri = String.Format("{0}", "http://localhost:4200/");
            return this.Request.CreateResponse(HttpStatusCode.OK,redirectUri);

        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
