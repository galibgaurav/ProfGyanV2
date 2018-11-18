using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface IAppointmentBL
    {
        Appointment AddAppointment(Appointment appointment);
        void DeleteAppointment(string id);
        IEnumerable<Appointment> GetAppointment(Expression<Func<Appointment, bool>> filter = null, Func<IQueryable<BusinessDataModel.Appointment>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Appointment GetAppointment(string id);
        void UpdateAppointment(Appointment appointment);
    }
}