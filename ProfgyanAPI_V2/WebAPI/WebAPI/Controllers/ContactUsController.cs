using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ContactUsController : ApiController
    {
       

        // GET: api/ContactUs
        public IEnumerable<string> Get()
        {
            //var result=unitOfWork.ContactUsRepository.Get(null, null, "");
            //return result;
            return null;
        }

        // GET: api/ContactUs/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ContactUs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ContactUs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ContactUs/5
        public void Delete(int id)
        {
        }
    }
}
