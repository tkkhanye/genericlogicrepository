
using Experiment.Models.DomainModels;
using Experiment.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiment.BusinessLogic
{
    public abstract class GenericLogic<TModel> where TModel : BaseModel, new()
    {
        protected IGenericRepository<TModel> _genericRepository;
        protected IUnitOfWork _unitOfWork;

        public GenericLogic(IUnitOfWork unitOfWork, IGenericRepository<TModel> genericRepository)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public virtual TModel GetByID(int ID) => _genericRepository.GetByID(ID);

        public virtual List<TModel> GetAllActive() => _genericRepository.Get(x => x.Active, "", 200).ToList();

        public virtual void Save(TModel model)
        {
            if (model.ID == 0)
            {
                _genericRepository.Insert(model);
            }
            else
            {
                _genericRepository.Update(model);
            }

            _unitOfWork.Save();
        }
    }
}
