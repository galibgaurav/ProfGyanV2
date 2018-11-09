using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface IPaymentModeBL
    {
        PaymentMode AddPaymentMode(PaymentMode paymentMode);
        void DeletePaymentMode(int id);
        IEnumerable<PaymentMode> GetPaymentMode(Expression<Func<PaymentMode, bool>> filter = null, Func<IQueryable<PaymentMode>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        PaymentMode GetPaymentMode(int id);
        void UpdatePaymentMode(PaymentMode paymentMode);
    }
}