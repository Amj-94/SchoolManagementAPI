using System;
namespace SchoolManagementAPI.Repo.Interfaces
{
    public interface IRepositoryReadOnly<T> : IReadRepository<T> where T : class
    {

    }
}
