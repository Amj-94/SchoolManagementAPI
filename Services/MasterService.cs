using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repo.Paging;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.UnitOfWork;
using Microsoft.EntityFrameworkCore.Query;

namespace SchoolManagementAPI.Services
{
    public class MasterService : IMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MasterService(IUnitOfWork<SchoolDBContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IPaginate<T> GetAll<T>(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int index = 0, int size = 20, bool disableTracking = true) where T : Base
        {
            Expression<Func<T, bool>> expr2 = x => ((!x.Deleted.HasValue) || (x.Deleted.Value == false));
            if (predicate != null)
            {
                //var body = Expression.AndAlso(predicate.Body, Expression.Invoke(expr2, predicate.Parameters[0]));
                //var lambda = Expression.Lambda<Func<T, bool>>(body, predicate.Parameters[0]);
                //return _unitOfWork.GetReadOnlyRepository<T>().GetList(lambda, orderBy, include, index, size, disableTracking);
                return _unitOfWork.GetReadOnlyRepository<T>().GetList(predicate, orderBy, include, index, size, disableTracking);
            }
            return _unitOfWork.GetReadOnlyRepository<T>().GetList(expr2, orderBy, include, index, size, disableTracking);
        }

        public T GetOne<T>(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int index = 0, int size = 20, bool disableTracking = true) where T : Base
        {
            Expression<Func<T, bool>> expr2 = x => ((!x.Deleted.HasValue) || (x.Deleted.Value == false));

            if (predicate != null)
            {
                //var body = Expression.AndAlso(predicate.Body, Expression.Invoke(expr2, predicate.Parameters[0]));
                //var lambda = Expression.Lambda<Func<T, bool>>(body, predicate.Parameters[0]);
                //return _unitOfWork.GetReadOnlyRepository<T>().GetList(lambda, orderBy, include, index, size, disableTracking).Items.FirstOrDefault();
                return _unitOfWork.GetReadOnlyRepository<T>().GetList(predicate, orderBy, include, index, size, disableTracking).Items.FirstOrDefault();
            }
            return _unitOfWork.GetReadOnlyRepository<T>().GetList(expr2, orderBy, include, index, size, disableTracking).Items.FirstOrDefault();
        }

        //public T GetOne<T>(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true) where T : Base
        //{
        //    Expression<Func<T, bool>> expr2 = x => ((!x.Deleted.HasValue) || (x.Deleted.Value == false));

        //    if (predicate != null)
        //    {
        //        var body = Expression.AndAlso(predicate.Body, Expression.Invoke(expr2, predicate.Parameters[0]));
        //        var lambda = Expression.Lambda<Func<T, bool>>(body, predicate.Parameters[0]);
        //        return _unitOfWork.GetReadOnlyRepository<T>().Single(lambda, orderBy, include, disableTracking);
        //    }
        //    return _unitOfWork.GetReadOnlyRepository<T>().Single(expr2, orderBy, include, disableTracking);
        //}
    }
}
