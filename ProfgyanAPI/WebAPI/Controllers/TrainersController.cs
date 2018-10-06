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
using System.Security.Claims;
using System.Globalization;

namespace WebAPI.Controllers
{
    public class TrainersController : ApiController
    {
        private ProfGyanDBContext db = new ProfGyanDBContext();

        // GET: api/Trainers
        public IQueryable<Trainer> GetTrainers()
        {
            return db.Trainers;
        }
        
        // GET: api/Trainers/5
        [ResponseType(typeof(Trainer))]
        public async Task<IHttpActionResult> GetTrainer(string id)
        {
            Trainer trainer = await db.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return Ok(trainer);
        }
       
        [ResponseType(typeof(TrainerDTO))]
        [Route("api/Trainers/TrainerDetail")]
        [Authorize]
        public async Task<IHttpActionResult> GetTrainerDetail()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            var UserEmail = claims.Select(x => { if (x.Type == "Email") return x.Value; else return null; }).SingleOrDefault(x => x != null);

            var user = db.Users.SingleOrDefault(x => x.Email == UserEmail);

            TrainerDTO trainerDTO = new TrainerDTO();
            var trainer=db.Trainers.SingleOrDefault(x => x.UserID == user.Id);
            if(trainer!=null)
            {
                //trainerDTO.firstName=trainer.FirstName;
                //trainerDTO.lastName=trainer.LastName;
                var commDetails = await db.CommonDetails.SingleOrDefaultAsync(x => x.ID == trainer.CommonDetailID);
                if(commDetails!=null)
                {
                    trainerDTO.academicYear=commDetails.AcademicYear.ToString();
                    trainerDTO.address=commDetails.Address;
                    trainerDTO.City=commDetails.City;
                    trainerDTO.department=commDetails.Department;
                    trainerDTO.dob=commDetails.DOB.ToString();
                    trainerDTO.highestQualification=commDetails.HighestQualification;
                    trainerDTO.PINCode=commDetails.PINCode;
                    trainerDTO.state=commDetails.state;
                }
                var trainerDetail = await db.TrainerDetails.SingleOrDefaultAsync(x => x.TrainerId == trainer.TrainerId);
                if(trainerDetail!=null)
                {
                    trainerDTO.companies=trainerDetail.Companies;
                    trainerDTO.teachingExp=trainerDetail.Experience;
                    trainerDTO.skillSet = trainerDetail.SkillSet;
                    trainerDTO.socialMediaLink=trainerDetail.SocialMediaId;
                    trainerDTO.teachingExp=trainerDetail.TeachingExperience;
                }
             }
                return Ok(trainerDTO);
            }

        // PUT: api/Trainers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainer(string id, Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainer.TrainerId)
            {
                return BadRequest();
            }

            db.Entry(trainer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(id))
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

        // POST: api/Trainers
        [ResponseType(typeof(TrainerDTO))]
        public async Task<IHttpActionResult> PostTrainer(TrainerDTO trainer)
        {

            var user = await db.Users.Where(x => x.Email == trainer.email).SingleOrDefaultAsync();
            if(user==null)
                {
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Not Found, Please perform SignUp/Register"));
                }
            //Check if trainer application detail exist-In case he/she has partially filled the apllictaion form

            var trainerDb = db.Trainers.SingleOrDefault(x => x.UserID == user.Id);


            //if (trainerDb!=null)
            //{
            //    trainerDb.
            //}
            //else
            //{

            //}
            CommonDetail commonDetailObj = new CommonDetail()
                {

                ID = Guid.NewGuid().ToString(),
                Address = trainer.address,
                AcademicYear = Convert.ToDateTime(trainer.academicYear),
                DOB = Convert.ToDateTime(trainer.dob),
                Department = trainer.department,
                Grade = null,   
                Photo = null,
                HighestQualification = trainer.highestQualification,

                };
            
                Trainer trainerObj = new Trainer()
                {
                    TrainerId = Guid.NewGuid().ToString(),
                    UserID=user.Id,
                    //FirstName = trainer.firstName,
                    //LastName = trainer.lastName,
                    CommonDetailID = commonDetailObj.ID,
                    TypeId = null,
                    RatingId = null,
                    StatusId = null,
                    IsVerified = false
                };
                TrainerDetail trainerDetailObj = new TrainerDetail()
                {
                    TrDetailId = Guid.NewGuid().ToString(),
                    TrainerId = trainerObj.TrainerId,
                    Experience = trainer.industrialExp,
                    Companies = trainer.companies,
                    SkillSet = trainer.skillSet,
                    TeachingExperience = trainer.teachingExp,
                    TeachingReason = null,
                    SocialMediaId = trainer.socialMediaLink
                };

            try
            {
                db.CommonDetails.Add(commonDetailObj);
                db.Trainers.Add(trainerObj);
                db.TrainerDetails.Add(trainerDetailObj);

                var result=await db.SaveChangesAsync();
                return  CreatedAtRoute("DefaultApi", new { id = trainerObj.TrainerId }, trainerObj);
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [ResponseType(typeof(TrainerPersonalDTO))]
        [Route("api/Trainers/AddTrainerPersonalDetail")]
        
        public async Task<IHttpActionResult> PostTrainerPersonalDetails(TrainerPersonalDTO trainerPersonalDetails)
        {

            var user = await db.Users.Where(x => x.Email == trainerPersonalDetails.email).SingleOrDefaultAsync();
            if (user == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Not Found, Please perform SignUp/Register"));
            }
            //Check if trainer application detail exist-In case he/she has partially filled the apllictaion form

            var trainerDb = db.Trainers.SingleOrDefault(x => x.UserID == user.Id);
                
            if(trainerDb!=null)
            {
                    var CommDetail = db.CommonDetails.Where(x => x.ID == trainerDb.CommonDetailID).SingleOrDefault();
                    CommDetail.Address= trainerPersonalDetails.address;
                    CommDetail.state=trainerPersonalDetails.state;
                    CommDetail.City=trainerPersonalDetails.City;
                    //CommDetail.DOB = DateTime.ParseExact(trainerPersonalDetails.dob, "dd/MM/YYYY", CultureInfo.InvariantCulture);
                    CommDetail.DOB = Convert.ToDateTime(trainerPersonalDetails.dob);
                    CommDetail.PINCode=trainerPersonalDetails.PINCode;
                    db.Entry(CommDetail).State = EntityState.Modified;
                    
                    try
                    {
                        var result=await db.SaveChangesAsync();
                        trainerPersonalDetails.CommonDetailID = CommDetail.ID;
                        trainerPersonalDetails.TrainerId = trainerDb.TrainerId;
                        return Ok(trainerPersonalDetails);
                    }
                    catch (Exception ex)
                    {
                        return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
                    }
                
            }
            else
            {

                CommonDetail commonDetailObj = new CommonDetail()
                {

                    ID = Guid.NewGuid().ToString(),
                    Address = trainerPersonalDetails.address,
                    AcademicYear = null,
                    DOB = Convert.ToDateTime(trainerPersonalDetails.dob),
                    Department = String.Empty,
                    Grade = null,
                    Photo = null,
                    HighestQualification = String.Empty,
                    state = trainerPersonalDetails.state,
                    City = trainerPersonalDetails.City,
                    PINCode=trainerPersonalDetails.PINCode

                };

                Trainer trainerObj = new Trainer()
                {
                    TrainerId = Guid.NewGuid().ToString(),
                    UserID = user.Id,
                    //FirstName = null,//TODO: Need to remove since user table already contain firstname 
                    //LastName = null,//TODO: Need to remove since user table already contain lastname
                    CommonDetailID = commonDetailObj.ID,
                    TypeId = null,
                    RatingId = null,
                    StatusId = null,
                    IsVerified = false
                };
                TrainerDetail trainerDetailObj = new TrainerDetail()
                {
                    TrDetailId = Guid.NewGuid().ToString(),
                    TrainerId = trainerObj.TrainerId,
                    Experience = null,
                    Companies = null,
                    SkillSet = null,
                    TeachingExperience = null,
                    TeachingReason = null,
                    SocialMediaId = null
                };
                using (DbContextTransaction transaction =db.Database.BeginTransaction())
                {

                    try
                    {
                        db.CommonDetails.Add(commonDetailObj);
                        db.Trainers.Add(trainerObj);
                        db.TrainerDetails.Add(trainerDetailObj);
                        var result =await db.SaveChangesAsync();
                        transaction.Commit();
                        trainerPersonalDetails.CommonDetailID = commonDetailObj.ID;
                        trainerPersonalDetails.TrainerId = trainerObj.TrainerId;
                        return Ok(trainerPersonalDetails);
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        return InternalServerError(new ApplicationException("Something went wrong in this request. internal exception: " + ex.Message));
                    }
                   
                }
              }
        }

        [HttpPost]
        [ResponseType(typeof(TrainerProfesssionalDTO))]
        [Route("api/Trainers/AddTrainerProfessonalDetail")]
        [WebAPI.Authorize]
        public async Task<IHttpActionResult> PostTrainerProfessionalDetails(TrainerProfesssionalDTO trainerProfessionalDetails)
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            var UserEmail = claims.Select(x => { if (x.Type == "Email") return x.Value; else return null; }).SingleOrDefault(x => x != null);


            var user =  db.Users.Where(x => x.Email == UserEmail).SingleOrDefault();
            if (user == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Not Found, Please perform SignUp/Register"));
            }
            var trainerDb =  db.Trainers.Where(x => x.UserID == user.Id).SingleOrDefault();
            if (trainerDb != null)
            {
                var CommDetail = db.CommonDetails.Where(x => x.ID == trainerDb.CommonDetailID).SingleOrDefault();
                CommDetail.Department = trainerProfessionalDetails.department;
                CommDetail.HighestQualification = trainerProfessionalDetails.highestQualification;
                CommDetail.AcademicYear = Convert.ToDateTime(trainerProfessionalDetails.academicYear);

                var trainerDetail = db.TrainerDetails.Where(x => x.TrainerId == trainerDb.TrainerId).SingleOrDefault();
                trainerDetail.Experience = trainerProfessionalDetails.industrialExp;
                trainerDetail.TeachingExperience = trainerProfessionalDetails.teachingExp;
                trainerDetail.SkillSet = trainerProfessionalDetails.skillSet;
                trainerDetail.SocialMediaId = trainerProfessionalDetails.socialMediaLink;

                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try {
                        db.Entry(CommDetail).State = EntityState.Modified;
                        db.Entry(trainerDetail).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync();
                        transaction.Commit();
                        trainerProfessionalDetails.CommonDetailID = CommDetail.ID;
                        trainerProfessionalDetails.TrainerId = trainerDb.TrainerId;
                        trainerProfessionalDetails.TrainerDetailID = trainerDetail.TrDetailId;
                        return Ok(trainerProfessionalDetails);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
                    }
                }
            }
            else
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Please add user personal information first."));
            }
        }
        
        // DELETE: api/Trainers/5
        [ResponseType(typeof(Trainer))]
        public async Task<IHttpActionResult> DeleteTrainer(string id)
        {
            Trainer trainer = await db.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            db.Trainers.Remove(trainer);
            await db.SaveChangesAsync();

            return Ok(trainer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommonDetailExists(string id)
        {
            return db.CommonDetails.Count(e => e.ID == id) > 0;
        }
        private bool TrainerExists(string id)
        {
            return db.Trainers.Count(e => e.TrainerId == id) > 0;
        }
        private bool TrainerDetailExists(string id)
        {
            return db.TrainerDetails.Count(e => e.TrDetailId == id) > 0;
        }

        private ProfGyanUser IsLoggedInUserExist()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            var UserEmail = claims.Select(x => { if (x.Type == "Email") return x.Value; else return null; }).SingleOrDefault(x => x != null);

            var user = db.Users.SingleOrDefault(x => x.Email == UserEmail);
            return user;
        }
    }
}
