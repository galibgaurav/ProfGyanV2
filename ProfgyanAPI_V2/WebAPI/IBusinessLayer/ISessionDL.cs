using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface ISessionDL
    {
        Session AddSession(Session session);
        void DeleteSession(int id);
        IEnumerable<Session> GetSession(Expression<Func<Session, bool>> filter = null, Func<IQueryable<Session>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Session GetSession(int id);
        void UpdateSession(Session session);
    }
}