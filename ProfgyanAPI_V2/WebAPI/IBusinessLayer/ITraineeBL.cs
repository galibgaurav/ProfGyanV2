using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface ITraineeBL
    {
        Trainee AddTrainee(Trainee trainee);
        void DeleteTrainee(string id);
        IEnumerable<Trainee> GetTrainee(Expression<Func<Trainee, bool>> filter = null, Func<IQueryable<Trainee>, IOrderedQueryable<Trainee>> orderBy = null, string includeProperties = "");
        Trainee GetTrainee(string id);
        void UpdateTrainee(Trainee trainee);
    }
}