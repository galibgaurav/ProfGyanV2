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

        // GET: api/ContactUs
        public IEnumerable<DataModelDTO.ContactUs> Get()
        {
           
            var contactUsList = contactUsBL.GetContactUs(null, null, String.Empty);
            var result= Mapper.Map<IEnumerable<DataModelDTO.ContactUs>>(contactUsList);
            return result;
        }

        // GET: api/ContactUs/5
        public ContactUs Get(string id)
        {
            var contactUs = contactUsBL.GetContactUs(id);
            var result = Mapper.Map<DataModelDTO.ContactUs>(contactUs);
            return result;
        }

        // POST: api/ContactUs
        public ContactUs Post(DataModelDTO.ContactUs contactUs)
        {
            var postData = Mapper.Map<BusinessDataModel.ContactUs>(contactUs);
            var result=contactUsBL.AddContactUs(postData);
            var resultToReturn = Mapper.Map<DataModelDTO.ContactUs>(result);
            return resultToReturn;
        }

        // PUT: api/ContactUs
        public void Put(DataModelDTO.ContactUs contactUs)
        {
            var putData = Mapper.Map<BusinessDataModel.ContactUs>(contactUs);
            contactUsBL.UpdateContactUs(putData);
        }

        // DELETE: api/ContactUs/5
        public void Delete(string id)
        {
            contactUsBL.DeleteContactUs(id);
        }
    }
}
