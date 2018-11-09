using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface IFeedbackBL
    {
        Feedback AddFeedback(Feedback feedback);
        void DeleteFeedback(int id);
        IEnumerable<Feedback> GetFeedback(Expression<Func<Feedback, bool>> filter = null, Func<IQueryable<Feedback>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Feedback GetFeedback(int id);
        void UpdateFeedback(Feedback feedback);
    }
}