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
    public class StatusBL : IStatusBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Status GetStatus(string id)
        {
            return unitOfWork.StatusRepository.GetByID(id);
        }

        public Status AddStatus(Status status)
        {
            var result = unitOfWork.StatusRepository.Insert(status);
            unitOfWork.Save();
            return result;
        }

        public void UpdateStatus(Status status)
        {
            unitOfWork.StatusRepository.Update(status);
            unitOfWork.Save();
        }

        public void DeleteStatus(string id)
        {
            unitOfWork.StatusRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Status> GetSocialMedia(Expression<Func<Status, bool>> filter = null,
            Func<IQueryable<Status>, IOrderedQueryable<Status>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.StatusRepository.Get(null, null, "");
            return result;
        }
    }
}


