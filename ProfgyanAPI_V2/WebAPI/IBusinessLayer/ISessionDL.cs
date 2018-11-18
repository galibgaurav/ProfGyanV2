using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface ISessionDL
    {
        Session AddSession(Session session);
        void DeleteSession(string id);
        IEnumerable<Session> GetSession(Expression<Func<Session, bool>> filter = null, Func<IQueryable<Session>, IOrderedQueryable<Session>> orderBy = null, string includeProperties = "");
        Session GetSession(string id);
        void UpdateSession(Session session);
    }
}