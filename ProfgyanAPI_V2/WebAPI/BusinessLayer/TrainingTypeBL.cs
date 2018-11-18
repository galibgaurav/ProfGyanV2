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
    public class TrainingTypeBL : ITrainingTypeBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public TrainingType GetTrainingType(string id)
        {
            return unitOfWork.TrainingTypeRepository.GetByID(id);
        }

        public TrainingType AddTrainingType(TrainingType trainingType)
        {
            var result = unitOfWork.TrainingTypeRepository.Insert(trainingType);
            unitOfWork.Save();
            return result;
        }

        public void UpdateTrainingType(TrainingType trainingType)
        {
            unitOfWork.TrainingTypeRepository.Update(trainingType);
            unitOfWork.Save();
        }

        public void DeleteTrainingType(string id)
        {
            unitOfWork.TrainingTypeRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<TrainingType> GetTrainingType(Expression<Func<TrainingType, bool>> filter = null,
            Func<IQueryable<TrainingType>, IOrderedQueryable<TrainingType>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.TrainingTypeRepository.Get(null, null, "");
            return result;
        }
    }
}
