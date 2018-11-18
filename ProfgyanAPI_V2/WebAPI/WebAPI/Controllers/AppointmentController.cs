using AutoMapper;
using DataModelDTO;
using IBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class AppointmentController : ApiController
    {
        public IAppointmentBL appointmentBL;
        public AppointmentController(IAppointmentBL _appointmentBL)
        {
            appointmentBL = _appointmentBL;
        }

        // GET: api/Appointment
        public IEnumerable<DataModelDTO.Appointment> Get()
        {

            var appointmentList = appointmentBL.GetAppointment(null, null, String.Empty);
            var result = Mapper.Map<IEnumerable<DataModelDTO.Appointment>>(appointmentBL);
            return result;
        }

        // GET: api/Appointment/5
        public Appointment Get(string id)
        {
            var appointment = appointmentBL.GetAppointment(id);
            var result = Mapper.Map<DataModelDTO.Appointment>(appointment);
            return result;
        }

        // POST: api/Appointment
        public Appointment Post(DataModelDTO.Appointment appointment)
        {
            var postData = Mapper.Map<BusinessDataModel.Appointment>(appointment);
            var result = appointmentBL.AddAppointment(postData);
            var resultToReturn = Mapper.Map<DataModelDTO.Appointment>(result);
            return resultToReturn;
        }

        // PUT: api/Appointment
        public void Put(DataModelDTO.Appointment appointment)
        {
            var putData = Mapper.Map<BusinessDataModel.Appointment>(appointment);
            appointmentBL.UpdateAppointment(putData);
        }

        // DELETE: api/Appointment/5
        public void Delete(string id)
        {
            appointmentBL.DeleteAppointment(id);
        }
    }
}
