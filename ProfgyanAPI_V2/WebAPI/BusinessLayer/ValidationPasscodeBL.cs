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
    public class ValidationPasscodeBL : IValidationPasscodeBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ValidationPasscode GetValidationPasscode(string id)
        {
            return unitOfWork.ValidationPasscodeRepository.GetByID(id);
        }

        public ValidationPasscode AddValidationPasscode(ValidationPasscode validationPasscode)
        {
            var result = unitOfWork.ValidationPasscodeRepository.Insert(validationPasscode);
            unitOfWork.Save();
            return result;
        }

        public void UpdateValidationPasscode(ValidationPasscode validationPasscode)
        {
            unitOfWork.ValidationPasscodeRepository.Update(validationPasscode);
            unitOfWork.Save();
        }

        public void DeleteValidationPasscode(string id)
        {
            unitOfWork.ValidationPasscodeRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<ValidationPasscode> GetValidationPasscode(Expression<Func<ValidationPasscode, bool>> filter = null,
            Func<IQueryable<ValidationPasscode>, IOrderedQueryable<ValidationPasscode>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.ValidationPasscodeRepository.Get(null, null, "");
            return result;
        }
    }
}
