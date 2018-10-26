using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;
using DataModelDTO;
using AutoMapper;

namespace WebAPI.Controllers
{
    public class ContactUsController : ApiController
    {
       public IContactUsBL contactUsBL;
       public ContactUsController(IContactUsBL _contactUsBL)//TODO
        {
            contactUsBL = _contactUsBL;
        }

        // GET: api/ContactUs
        public IEnumerable<ContactUs> Get()
        {
           
            var result = contactUsBL.GetContactUs(null, null, String.Empty);
            //TODO use mapper for conversion;
            //result=result.
            return result;
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
