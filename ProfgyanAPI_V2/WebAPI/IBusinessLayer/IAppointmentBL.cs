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
        void DeleteAppointment(int id);
        IEnumerable<Appointment> GetAppointment(Expression<Func<Appointment, bool>> filter = null, Func<IQueryable<BusinessDataModel.Appointment>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Appointment GetAppointment(int id);
        void UpdateAppointment(Appointment appointment);
    }
}