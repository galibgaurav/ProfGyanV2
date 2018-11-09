using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface IRatingBL
    {
        Rating AddRating(Rating rating);
        void DeleteRating(int id);
        IEnumerable<Rating> GetAppointment(Expression<Func<Rating, bool>> filter = null, Func<IQueryable<Rating>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Rating GetRating(int id);
        void UpdateRating(Rating rating);
    }
}