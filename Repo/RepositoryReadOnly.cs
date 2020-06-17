using System;
using SchoolManagementAPI.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementAPI.Repo
{
    public class RepositoryReadOnly<T> : BaseRepository<T>, IRepositoryReadOnly<T> where T : class
    {
        public RepositoryReadOnly(DbContext context) : base(context)
        {            
        }        
    }
}
