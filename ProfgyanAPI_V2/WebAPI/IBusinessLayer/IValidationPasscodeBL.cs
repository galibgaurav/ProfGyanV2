using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface IValidationPasscodeBL
    {
        ValidationPasscode AddValidationPasscode(ValidationPasscode validationPasscode);
        void DeleteValidationPasscode(string id);
        IEnumerable<ValidationPasscode> GetValidationPasscode(Expression<Func<ValidationPasscode, bool>> filter = null, Func<IQueryable<ValidationPasscode>, IOrderedQueryable<ValidationPasscode>> orderBy = null, string includeProperties = "");
        ValidationPasscode GetValidationPasscode(string id);
        void UpdateValidationPasscode(ValidationPasscode validationPasscode);
    }
}