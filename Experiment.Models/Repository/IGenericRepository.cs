using Experiment.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Experiment.Models.Repository
{
    public interface IGenericRepository<TModel> where TModel : BaseModel, new()
    {
        IEnumerable<TModel> Get(
            Expression<Func<TModel, bool>> filter = null,
            string includeProperties = "",
            int selectTop = 0);

        TModel GetByID(object id);

        void Insert(TModel entity);

        void Update(TModel entityToUpdate);
    }
}
