using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessDataModel;
using IBusinessLayer;

namespace BusinessLayer
{
    public class SessionDL : ISessionDL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Session GetSession(int id)
        {
            return unitOfWork.SessionRepository.GetByID(id);
        }

        public Session AddSession(Session session)
        {
            var result = unitOfWork.SessionRepository.Insert(session);
            unitOfWork.Save();
            return result;
        }

        public void UpdateSession(Session session)
        {
            unitOfWork.SessionRepository.Update(session);
            unitOfWork.Save();
        }

        public void DeleteSession(int id)
        {
            unitOfWork.SessionRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Session> GetSession(Expression<Func<Session, bool>> filter = null,
            Func<IQueryable<Session>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.SessionRepository.Get(null, null, "");
            return result;
        }
    }
}
