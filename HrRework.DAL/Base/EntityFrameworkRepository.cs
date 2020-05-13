using HrRework.Application.Interfaces;
using HrRework.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HrRework.DAL.Base
{
    public abstract class EntityFrameworkRepository<T> : IRepository<T>
        where T : Entity
    {
        protected readonly DbContext HrReworkContext;

        public EntityFrameworkRepository(DbContext HrReworkContext)
        {
            this.HrReworkContext = HrReworkContext 
                ?? throw new ArgumentNullException(nameof(HrReworkContext));
        }

        public IQueryable<T> AggregateNavigationProperties
            (IQueryable<T> query, IEnumerable<Func<IQueryable<T>, IIncludableQueryable<T, object>>> includes)
        {
            return includes.Aggregate(query, (currentQuery, include) => include(currentQuery));
        }

        public IQueryable<T> Find(params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes)
        {
            return AggregateNavigationProperties(HrReworkContext.Set<T>(), includes);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression,
                                  params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes)
        {
            return Find(includes).Where(expression);
        }

        public T FirstOrDefault(params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes)
        {
            return Find(includes).FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression,
                                params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes)
        {
            return Find(includes).FirstOrDefault(expression);
        }

        public Task SaveOrUpdate(T entity)
        {
            var attachedEntity = HrReworkContext.Set<T>().Find(entity.Id);

            if (attachedEntity != null)
            {
                var attachedEntry = HrReworkContext.Entry(attachedEntity);
                attachedEntry.CurrentValues.SetValues(entity);
            }
            else
            {
                HrReworkContext.Set<T>().Add(entity);
            }

            return HrReworkContext.SaveChangesAsync();
        }

    }
}
