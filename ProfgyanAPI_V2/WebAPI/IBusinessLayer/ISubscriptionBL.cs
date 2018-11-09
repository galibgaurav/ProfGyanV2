using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface ISubscriptionBL
    {
        Subscription AddSubscription(Subscription subscription);
        void DeleteSubscription(int id);
        IEnumerable<Subscription> GetAppointment(Expression<Func<Subscription, bool>> filter = null, Func<IQueryable<Subscription>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Subscription GetSubscription(int id);
        void UpdateSubscription(Subscription subscription);
    }
}