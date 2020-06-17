using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagementAPI.Repo.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace SchoolManagementAPI.Repo.Interfaces
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<T> SingleAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);

        //public T Single(Expression<Func<T, bool>> predicate = null,
        //    Expression<Func<T, object>> orderByASC = null,
        //    Expression<Func<T, object>> orderByDESC = null,
        //    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true);

        IEnumerable<T> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int index = 0,
            int size = 20,
            bool disableTracking = true,
            CancellationToken cancellationToken = default(CancellationToken));

        public ValueTask<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T>> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));

        Task AddAsync(params T[] entities);

        Task AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));

        void UpdateAsync(T entity);
        Task<T> Search(params object[] keyValues);
        void SaveChangesAsync();
    }
}
