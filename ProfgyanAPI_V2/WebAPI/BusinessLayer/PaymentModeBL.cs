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
    public class PaymentModeBL : IPaymentModeBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public PaymentMode GetPaymentMode(string id)
        {
            return unitOfWork.PaymentModeRepository.GetByID(id);
        }

        public PaymentMode AddPaymentMode(PaymentMode paymentMode)
        {
            var result = unitOfWork.PaymentModeRepository.Insert(paymentMode);
            unitOfWork.Save();
            return result;
        }

        public void UpdatePaymentMode(PaymentMode paymentMode)
        {
            unitOfWork.PaymentModeRepository.Update(paymentMode);
            unitOfWork.Save();
        }

        public void DeletePaymentMode(string id)
        {
            unitOfWork.PaymentModeRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<PaymentMode> GetPaymentMode(Expression<Func<PaymentMode, bool>> filter = null,
            Func<IQueryable<PaymentMode>, IOrderedQueryable<PaymentMode>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.PaymentModeRepository.Get(null, null, "");
            return result;
        }
    }
}
