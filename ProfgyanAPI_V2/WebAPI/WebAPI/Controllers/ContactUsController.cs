using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;
using DataModelDTO;
using AutoMapper;
using IBusinessLayer;

namespace WebAPI.Controllers
{
    public class ContactUsController : ApiController
    {
        public IContactUsBL contactUsBL;
        public ContactUsController(IContactUsBL _contactUsBL)
        {
                   contactUsBL = _contactUsBL;
        }

        //public ContactUsController()//TODO
        //{
        //    contactUsBL = new ContactUsBL();
        //}
        // GET: api/ContactUs
        public IEnumerable<DataModelDTO.ContactUs> Get()
        {
           
            var contactUsList = contactUsBL.GetContactUs(null, null, String.Empty);
            var result= Mapper.Map<IEnumerable<DataModelDTO.ContactUs>>(contactUsList);
            return result;
        }

        // GET: api/ContactUs/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ContactUs
        public void Post(DataModelDTO.ContactUs contactUs)
        {
            var postData = Mapper.Map<BusinessDataModel.ContactUs>(contactUs);
            var result=contactUsBL.AddContactUs(postData);
            
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
