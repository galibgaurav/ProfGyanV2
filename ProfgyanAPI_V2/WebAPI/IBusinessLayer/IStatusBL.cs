using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface IStatusBL
    {
        Status AddStatus(Status status);
        void DeleteStatus(int id);
        IEnumerable<Status> GetSocialMedia(Expression<Func<Status, bool>> filter = null, Func<IQueryable<Status>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Status GetStatus(int id);
        void UpdateStatus(Status status);
    }
}