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
    public class TrainerBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Trainer GetTrainer(int id)
        {
            return unitOfWork.TrainerRepository.GetByID(id);
        }

        public Trainer AddTrainer(Trainer trainer)
        {
            var result = unitOfWork.TrainerRepository.Insert(trainer);
            unitOfWork.Save();
            return result;
        }

        public void UpdateTrainer(Trainer trainer)
        {
            unitOfWork.TrainerRepository.Update(trainer);
            unitOfWork.Save();
        }

        public void DeleteTrainer(int id)
        {
            unitOfWork.TrainerRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Trainer> GetAppointment(Expression<Func<Trainer, bool>> filter = null,
            Func<IQueryable<Trainer>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.TrainerRepository.Get(null, null, "");
            return result;
        }
    }
}
