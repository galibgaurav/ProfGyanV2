using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface ITrainingTypeBL
    {
        TrainingType AddTrainingType(TrainingType trainingType);
        void DeleteTrainingType(string id);
        IEnumerable<TrainingType> GetTrainingType(Expression<Func<TrainingType, bool>> filter = null, Func<IQueryable<TrainingType>, IOrderedQueryable<TrainingType>> orderBy = null, string includeProperties = "");
        TrainingType GetTrainingType(string id);
        void UpdateTrainingType(TrainingType trainingType);
    }
}