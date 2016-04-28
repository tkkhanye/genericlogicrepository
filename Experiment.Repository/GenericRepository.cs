using Experiment.Models.DomainModels;
using Experiment.Models.Repository;
using Experiment.Repository.Entities;
using Experiment.Repository.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Experiment.Repository
{
    
    public class GenericRepository<TDomainModel, TEntity> : IGenericRepository<TDomainModel> where TDomainModel : BaseModel, new() where TEntity : BaseEntity, new()
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        Dictionary<string, string> _customFieldMappings;

        public GenericRepository<TDomainModel, TEntity> Initialize(DbContext context, Dictionary<string, string> customFieldMappings = null)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
            _customFieldMappings = customFieldMappings;
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>());
            return this;
        }

        public virtual IEnumerable<TDomainModel> GetAllActive() => Get(x => x.Active);

        public virtual IEnumerable<TDomainModel> Get(
            Expression<Func<TDomainModel, bool>> filter = null,
            //Func<IQueryable<TDomainModel>, IOrderedQueryable<TDomainModel>> orderBy = null,
            string includeProperties = "",
            int selectTop = 0)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                var param = Expression.Parameter(typeof(TEntity));
                //visiting body of original expression that gives us body of the new expression
                var body = new Visitor<TEntity>(param).Visit(filter.Body);
                //generating lambda expression form body and parameter 
                //notice that this is what you need to invoke the Method_2
                Expression<Func<TEntity, bool>> entityFilter = Expression.Lambda<Func<TEntity, bool>>(body, param);
                //compilation and execu+tion of generated method just to prove that it works


                query = query.Where(entityFilter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (selectTop > 0)
            {
                query = query.Take(selectTop);
            }

            var entityList = query.ToList();

            return ModelMapper.Mapper.MapEntities<TEntity, TDomainModel>(entityList);
        }

        public virtual TDomainModel GetByID(object id)
        {
            return ModelMapper.Mapper.MapEntity<TEntity, TDomainModel>(dbSet.Find(id));
        }

        public virtual void Insert(TDomainModel domainModel)
        {
            var entity = ModelMapper.Mapper.MapEntity<TDomainModel, TEntity>(domainModel);
            entity.DateCaptured = DateTime.Now;
            entity.DateModified = DateTime.Now;
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            //TEntity entityToDelete = dbSet.Find(id);
            //Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            //if (context.Entry(entityToDelete).State == EntityState.Detached)
            //{
            //    dbSet.Attach(entityToDelete);
            //}
            //dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TDomainModel domainModel)
        {
            var entityToUpdate = ModelMapper.Mapper.MapEntity<TDomainModel, TEntity>(domainModel);
            entityToUpdate.DateModified = DateTime.Now;
            context.Set<TEntity>().AddOrUpdate(entityToUpdate);
        }

        
    }
}
