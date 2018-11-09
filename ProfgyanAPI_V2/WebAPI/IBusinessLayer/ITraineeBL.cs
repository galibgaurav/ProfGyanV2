using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface ITraineeBL
    {
        Trainee AddTrainee(Trainee trainee);
        void DeleteTrainee(int id);
        IEnumerable<Trainee> GetTrainee(Expression<Func<Trainee, bool>> filter = null, Func<IQueryable<Trainee>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Trainee GetTrainee(int id);
        void UpdateTrainee(Trainee trainee);
    }
}