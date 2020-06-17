using System;
using System.Collections.Generic;
using SchoolManagementAPI.Repo;
using SchoolManagementAPI.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementAPI.UnitOfWork
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>, IUnitOfWork
        where TContext : DbContext, IDisposable
    {
        private Dictionary<Type, object> _repositories;
        private Dictionary<Type, object> _ReadOnlyrepositories;
        private Dictionary<Type, object> _Asyncrepositories;

        public UnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] =
                    new Repository<TEntity>(Context);
            return (IRepository<TEntity>)_repositories[type];
        }

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class
        {
            if (_Asyncrepositories == null) _Asyncrepositories =
                    new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_Asyncrepositories.ContainsKey(type)) _Asyncrepositories[type] =
                    new RepositoryAsync<TEntity>(Context);
            return (IRepositoryAsync<TEntity>)_Asyncrepositories[type];
        }

        public IRepositoryReadOnly<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : class
        {
            if (_ReadOnlyrepositories == null) _ReadOnlyrepositories =
                    new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_ReadOnlyrepositories.ContainsKey(type)) _ReadOnlyrepositories[type] =
                    new RepositoryReadOnly<TEntity>(Context);
            return (IRepositoryReadOnly<TEntity>)_ReadOnlyrepositories[type];
        }

        public TContext Context { get; }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
