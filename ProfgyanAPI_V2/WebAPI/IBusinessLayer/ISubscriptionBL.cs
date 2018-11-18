using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface ISubscriptionBL
    {
        Subscription AddSubscription(Subscription subscription);
        void DeleteSubscription(string id);
        IEnumerable<Subscription> GetAppointment(Expression<Func<Subscription, bool>> filter = null, Func<IQueryable<Subscription>, IOrderedQueryable<Subscription>> orderBy = null, string includeProperties = "");
        Subscription GetSubscription(string id);
        void UpdateSubscription(Subscription subscription);
    }
}