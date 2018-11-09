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
    public class FeedbackBL : IFeedbackBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Feedback GetFeedback(int id)
        {
            return unitOfWork.FeedbackRepository.GetByID(id);
        }

        public Feedback AddFeedback(Feedback feedback)
        {
            var result = unitOfWork.FeedbackRepository.Insert(feedback);
            unitOfWork.Save();
            return result;
        }

        public void UpdateFeedback(Feedback feedback)
        {
            unitOfWork.FeedbackRepository.Update(feedback);
            unitOfWork.Save();
        }

        public void DeleteFeedback(int id)
        {
            unitOfWork.FeedbackRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Feedback> GetFeedback(Expression<Func<Feedback, bool>> filter = null,
            Func<IQueryable<Feedback>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.FeedbackRepository.Get(null, null, "");
            return result;
        }
    }
}

