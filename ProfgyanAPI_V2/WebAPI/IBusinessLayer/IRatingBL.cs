using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface IRatingBL
    {
        Rating AddRating(Rating rating);
        void DeleteRating(string id);
        IEnumerable<Rating> GetAppointment(Expression<Func<Rating, bool>> filter = null, Func<IQueryable<Rating>, IOrderedQueryable<Rating>> orderBy = null, string includeProperties = "");
        Rating GetRating(string id);
        void UpdateRating(Rating rating);
    }
}