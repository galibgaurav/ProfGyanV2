using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface IStatusBL
    {
        Status AddStatus(Status status);
        void DeleteStatus(string id);
        IEnumerable<Status> GetSocialMedia(Expression<Func<Status, bool>> filter = null, Func<IQueryable<Status>, IOrderedQueryable<Status>> orderBy = null, string includeProperties = "");
        Status GetStatus(string id);
        void UpdateStatus(Status status);
    }
}