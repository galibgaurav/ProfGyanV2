using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface IFeedbackBL
    {
        Feedback AddFeedback(Feedback feedback);
        void DeleteFeedback(string id);
        IEnumerable<Feedback> GetFeedback(Expression<Func<Feedback, bool>> filter = null, Func<IQueryable<Feedback>, IOrderedQueryable<Feedback>> orderBy = null, string includeProperties = "");
        Feedback GetFeedback(string id);
        void UpdateFeedback(Feedback feedback);
    }
}