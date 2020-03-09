using HrRework.Domain.Base;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HrRework.Application.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Find(params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes);

        IQueryable<T> Find(Expression<Func<T, bool>> expression, 
                           params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes);

        T FirstOrDefault(params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes);

        T FirstOrDefault(Expression<Func<T, bool>> expression,
                         params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes);


        void SaveOrUpdate(T entity);
    }
}
