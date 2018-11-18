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
    public class TraineeBL : ITraineeBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Trainee GetTrainee(string id)
        {
            return unitOfWork.TraineeRepository.GetByID(id);
        }

        public Trainee AddTrainee(Trainee trainee)
        {
            var result = unitOfWork.TraineeRepository.Insert(trainee);
            unitOfWork.Save();
            return result;
        }

        public void UpdateTrainee(Trainee trainee)
        {
            unitOfWork.TraineeRepository.Update(trainee);
            unitOfWork.Save();
        }

        public void DeleteTrainee(string id)
        {
            unitOfWork.TraineeRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Trainee> GetTrainee(Expression<Func<Trainee, bool>> filter = null,
            Func<IQueryable<Trainee>, IOrderedQueryable<Trainee>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.TraineeRepository.Get(null, null, "");
            return result;
        }
    }
}
