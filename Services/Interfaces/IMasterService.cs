using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SchoolManagementAPI.Repo.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface IMasterService
    {
        IPaginate<T> GetAll<T>(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int index = 0,
            int size = 20,
            bool disableTracking = true) where T : Base;

        T GetOne<T>(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int index = 0,
            int size = 20,
            bool disableTracking = true) where T : Base;

        //T GetOne<T>(Expression<Func<T, bool>> predicate = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        //    bool disableTracking = true) where T : Base;

        //Task<T> GetOne<T>(Expression<Func<T, bool>> predicate = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        //    bool disableTracking = true) where T : Base;
    }
}
