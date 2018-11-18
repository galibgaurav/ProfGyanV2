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
    public class SubscriptionBL : ISubscriptionBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Subscription GetSubscription(string id)
        {
            return unitOfWork.SubscriptionRepository.GetByID(id);
        }

        public Subscription AddSubscription(Subscription subscription)
        {
            var result = unitOfWork.SubscriptionRepository.Insert(subscription);
            unitOfWork.Save();
            return result;
        }

        public void UpdateSubscription(Subscription subscription)
        {
            unitOfWork.SubscriptionRepository.Update(subscription);
            unitOfWork.Save();
        }

        public void DeleteSubscription(string id)
        {
            unitOfWork.SubscriptionRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Subscription> GetAppointment(Expression<Func<Subscription, bool>> filter = null,
            Func<IQueryable<Subscription>, IOrderedQueryable<Subscription>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.SubscriptionRepository.Get(null, null, "");
            return result;
        }
    }
}

