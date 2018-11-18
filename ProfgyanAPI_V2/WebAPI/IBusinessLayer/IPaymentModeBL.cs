using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface IPaymentModeBL
    {
        PaymentMode AddPaymentMode(PaymentMode paymentMode);
        void DeletePaymentMode(string id);
        IEnumerable<PaymentMode> GetPaymentMode(Expression<Func<PaymentMode, bool>> filter = null, Func<IQueryable<PaymentMode>, IOrderedQueryable<PaymentMode>> orderBy = null, string includeProperties = "");
        PaymentMode GetPaymentMode(string id);
        void UpdatePaymentMode(PaymentMode paymentMode);
    }
}